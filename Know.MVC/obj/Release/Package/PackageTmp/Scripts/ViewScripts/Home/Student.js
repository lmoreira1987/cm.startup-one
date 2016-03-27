/// <reference path="../Global/Global.js" />

var LocalAPI = {

    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.OnClickEnviarStudent();
            this.OnEnterEnviarStudent();
        },

        OnClickEnviarStudent: function () {
            $('#btn-enviarSt').off('click');
            $('#btn-enviarSt').on('click', function () {
                LocalAPI.Methods.Enviar();
            });
        },        

        OnEnterEnviarStudent: function () {
            $('#txt-name, #txt-email, #txt-password, #slc-serie').keypress(function (e) {
                var code = e.keyCode || e.which;

                if (code === 13) {
                    e.preventDefault();

                    LocalAPI.Methods.Enviar();
                }
            })
        },
    },

    Methods: {
        Enviar: function () {
            console.log('entroou');

            var name = $('#txt-name').val();
            var email = $('#txt-email').val();
            var serie = $('#slc-serie').val();
            var password = $('#txt-password').val();

            //$.loader.open();

            $.ajax({
                url: GS_Path.GetUrl('/Home/RegisterStudent'),
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: JSON.stringify({ 'name': name, 'email': email, 'serie': serie, 'password': password })
            })
            .done(function (resultado) {
                console.log('teste');
                if (resultado != 'error') {
                    if (resultado == 'student')
                        window.location.href = GS_Path.GetUrl('/Student');
                    else
                        window.location.href = GS_Path.GetUrl('/School');
                }
                else {
                    //$.loader.close();
                    GS_Alert.Simples('Email ou Senha Inválidos!');
                }
            });
        }
    }
}