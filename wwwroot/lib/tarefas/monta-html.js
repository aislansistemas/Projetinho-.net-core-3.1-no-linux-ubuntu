function montaListaPendentes(dados){

    for(let i = 0; i < dados.listaTarefas.length; i++){
        console.log(dados.listaTarefas[i])
        let dadosTarefas = dados.listaTarefas[i];
        let tdId = $('<td>').addClass('td-id').text(dadosTarefas.id);
        let tdNome = $('<td>').addClass('td-nome').text(dadosTarefas.nomeTarefa);
        let dataFormatada = formataData(dadosTarefas.dataCadastrada);
        let tdData = $('<td>').addClass('td-data').text(dataFormatada);

        let tdButtaoEdit = $('<td>');
        let buttaoEdit = $('<button>').addClass('btn btn-primary botao-edit').text('Editar');
        
        buttaoEdit.on("click", () => { 
            let form = $('<form>').attr("action","/Tarefa/EditarTarefa").attr("method","post");
            let btnEnvia = $('<button>').addClass('btn btn-success botao-Envia').text('Salvar');
            let inpId = $('<input>').attr('type','hidden').attr("name","Id").addClass('form-control').val(tdId.text());
            let inptEdit = $('<input>').attr('type','text').attr("name","NomeTarefa").addClass('form-control').val(tdNome.text());
            form.append(inpId);
            form.append(inptEdit);
            form.append(btnEnvia);
            tdNome.text('');
            tdNome.append(form); 
        });

        tdButtaoEdit.append(buttaoEdit);

        let tdLink = $('<td>');
        let linkConcluirTarefa = $('<a>').addClass('btn btn-light text-dark').attr('href','/Tarefa/ConcluirTarefa?id='+dadosTarefas.id).text('Concluir')
        tdLink.append(linkConcluirTarefa);

        let tr = $('<tr>').addClass('tr-tarefas');
        tr.append(tdId);
        tr.append(tdNome);
        tr.append(tdData);
        tr.append(tdButtaoEdit);
        tr.append(tdLink);

        $('.lista').append(tr);
    }

}

function mostrarTotalPendentes(total){
    $('.total-pendentes').text(total);
}