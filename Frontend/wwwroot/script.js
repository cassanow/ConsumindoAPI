async function carregarProdutos(){
    try{
        const resposta = await fetch("https://localhost:7045/User/GetUsers"); 
        if(!resposta.ok) throw new Error();
        
        const produtos = await resposta.json();
        const lista = document.getElementById("usuarios-body");
        lista.innerHTML = "";
        
        produtos.forEach(p => {
            const item = document.createElement("tr");

            item.innerHTML = `
            <td>${p.id}</td>
            <td>${p.username}</td>
            <td>${p.email}</td>
            <td>${p.role}</td>
             `;
            
            lista.appendChild(item);
        })
    }
    catch(err){
        const mensagem = document.getElementById("mensagem");
        mensagem.textContent = "⚠️ Ocorreu um erro ao carregar os produtos.";
    }
}

carregarProdutos();