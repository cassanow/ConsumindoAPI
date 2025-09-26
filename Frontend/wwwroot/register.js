async function register() {
    const username = document.getElementById("register-username").value;
    const email = document.getElementById("register-email").value;
    const password = document.getElementById("register-password").value;
    const role = parseInt(document.getElementById("register-role").value);

    try{
        const response = await fetch("https://localhost:7045/api/Auth/register", {
            method: "POST",
            headers: {   "Content-Type": "application/json" },
            body: JSON.stringify({username, email, password, role})
        })

        if (!response.ok) {
            console.log("register failed")
        }

        const dados = await response.json();
        console.log(dados); 
    }
    catch (err){
        console.log(err)
    }
}

register();
