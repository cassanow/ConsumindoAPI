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
        }

        const dados = await response.json();
        localStorage.setItem("token", dados.token)
        console.log("logado com sucesso")
    }
    catch (err) {
        console.log(err)
    }
}

login();