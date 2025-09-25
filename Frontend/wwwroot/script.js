async function login() {
    const username = document.getElementById("login-username").value;
    const password = document.getElementById("login-password").value;

    try{
        const response = await fetch("https://localhost:7045/api/Auth/login", {
            method: "POST",
            headers: {   "Content-Type": "application/json" },
            body: JSON.stringify({username, password})
        });

        if (!response.ok) {
            console.log("login faiiled")
            return;
        }
        
        const dados = await response.json();
        localStorage.setItem("token", dados.token)
        console.log("logado com sucesso")
    }
    catch (err) {
        console.log(err)         
    }
}

async function buscarUsuario(){
    
    const username = document.getElementById("username").value;
    const meuUsuario = document.getElementById("resultado");
    const token = localStorage.getItem("token");
    
    if(!token){
        console.log("voce deve estar logado primeiro")
    }
    
    try{
        const response = await fetch(`https://localhost:7045/User/GetUser/${encodeURIComponent(username)}`, {
            method: "GET", 
            headers: {  "Authorization": `Bearer ${token}`},
        });
        
        
        if(!response.ok) throw new Error("Usuario nao encontrado");

        const usuario = await response.json();
        meuUsuario.innerHTML = `
            <p><b>ID:</b> ${usuario.id}</p>
            <p><b>Username:</b> ${usuario.username}</p>
            <p><b>Email:</b> ${usuario.email}</p>
            <p><b>Role:</b> ${usuario.role}</p>
        `;
    }catch(err){
        meuUsuario.textContent = "⚠️ Usuário não encontrado.";
    }
    
}


async function carregarUsuarios(){
    try{
        const resposta = await fetch("https://localhost:7045/User/GetUsers"); 
        if(!resposta.ok) throw new Error();
        
        const usuarios = await resposta.json();
        const lista = document.getElementById("usuarios-body");
        lista.innerHTML = "";
        
        usuarios.forEach(u => {
            const item = document.createElement("tr");

            item.innerHTML = `
            <td>${u.id}</td>
            <td>${u.username}</td>
            <td>${u.email}</td>
            <td>${u.role}</td>
             `;
            
            lista.appendChild(item);
        })
    }
    catch(err){
        const mensagem = document.getElementById("mensagem");
        mensagem.textContent = "⚠️ Ocorreu um erro ao carregar os usuarios.";
    }
}

login();
carregarUsuarios();