$( () => {
    
    $.get("/Tarefa/GetAllPendentesJson", (dados) => {
        montaListaPendentes(dados);
        mostrarTotalPendentes(dados.totalTarefasPendentes);
    })
    .fail().always();;

});
