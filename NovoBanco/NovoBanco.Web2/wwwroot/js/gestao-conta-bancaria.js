(function (gestaoConta, $) {
    "use strict";

    $(function () {
        $(".btnAtivarConta").click(function () {
            var idConta = $(this).attr("data-id");
            var ativo = $(this).prop("checked") ? 1 : 0;
            $.ajax({
                type: 'GET',
                url: '../Conta/AtivarDesativarConta',
                data: 'id=' + idConta + '&ativo=' + ativo,
                success: function (resultado) {
                    novoBanco.AdicionarMensagemDeSucesso(resultado);
                }
            });
        });

        $(".btnExcluirConta").button().click(function () {
            var idConta = $(this).attr("data-id");
            $(".Id").val(idConta);

            var form = $("#modalConfirmacao");
            $(".btnConfirmacao").attr('href', '/Conta/ExcluirConta/' + idConta);
            form.modal('show');
        });
    });


})(window.gestaoConta = window.gestaoConta || {}, jQuery)