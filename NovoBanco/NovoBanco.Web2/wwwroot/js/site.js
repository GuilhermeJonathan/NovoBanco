(function (novoBanco, $) {
    "use strict";

    novoBanco.AdicionarMensagemDeSucesso = function (mensagem) {
        toastr.options = {
            "closeButton": true,
            "progressBar": true,
            "positionClass": "toast-top-right"
        };

        toastr.success(mensagem, "Sucesso");
    };

    novoBanco.AdicionarMensagemDeErro = function (mensagem) {
        toastr.options = {
            "closeButton": true,
            "progressBar": true,
            "positionClass": "toast-top-right"
        };
        toastr.error(mensagem, "OPS! Algo deu errado");
    };

})(window.novoBanco = window.novoBanco || {}, jQuery)