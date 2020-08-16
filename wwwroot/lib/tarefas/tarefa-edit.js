var tr = document.querySelectorAll(".tr-tarefas-pendentes");

for (var i = 0; i < tr.length; i++) {
    var trList = tr[i];
    var tdNome = trList.querySelector(".tarefa-nome");
    tdNome.addEventListener("click", () => {
        console.log(this);
    })

}