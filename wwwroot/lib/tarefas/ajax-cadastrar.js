
$('.inpt-cadastrar').on("click", () => {
    let valores = {
      NomeTarefa : $('.nome-tarefa').val()  
    };
    $.post("/Tarefa/Cadastrar", valores, (dados) => {
      console.log(dados);
      setTimeout(function(){
          if(dados == "sucesso"){
            $('.feed').css('display','block').addClass('text-success').text("cadastro feito com sucesso");
          }else{
            $('.feed').css('display','block').addClass('text-danger').text("Error! por favor preencha os dados corretamente");
          }
        },1500);
    }).always(
      $('.feed').css('display','block').addClass('text-primary').text("Enviado ...")
    );

});