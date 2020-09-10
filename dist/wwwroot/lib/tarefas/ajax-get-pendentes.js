$( () => {
    
    $.get("/Tarefa/GetAllPendentesJson", (dados) => {
        montaListaPendentes(dados.listaTarefas);
        mostrarTotalPendentes(dados.totalTarefasPendentes);
    })
    .fail().always();;

});
