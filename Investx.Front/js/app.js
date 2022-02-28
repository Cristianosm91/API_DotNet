$(document).ready(function() {
    $("#meubotao").click(function(event) {
        alert('Cadastro Enviado');
        event.preventDefault();
        var actionurl = event.currentTarget.action;
        $.ajax({
            url: "https://localhost:5001/investidores",
            type: "POST",
            data: $("form").serialize(),
            sucess: function(data) {
                alert('Sucesso:' + data.responseJSON.ativo);
            },
            error: function(data) {
                alert('ERRO:' + data.responseJSON.ativo);
            }
        });
    });
});