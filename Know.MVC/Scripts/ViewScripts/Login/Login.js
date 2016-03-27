/// <reference path="../Global/Global.js" />

var LocalAPI = {

    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.OnClickLogin();
            this.OnEnterLogin();

            this.OnClickEnviarStudent();
            this.OnEnterEnviarStudent();

            this.OnClickEnviarSchool();
            this.OnEnterEnviarSchool();

            this.OnClickEnviarSchoolSuccessful();
        },

        OnClickLogin: function () {
            $('#btn-enviar').off('click');
            $('#btn-enviar').on('click', function () {
                LocalAPI.Methods.Enviar();
            });
        },        

        OnEnterLogin: function () {
            $('#txt-email, #txt-password').keypress(function (e) {
                var code = e.keyCode || e.which;

                if (code === 13) {
                    e.preventDefault();

                    LocalAPI.Methods.Enviar();
                }
            })
        },

        OnClickEnviarStudent: function () {
            $('#btn-enviarStudent').off('click');
            $('#btn-enviarStudent').on('click', function () {
                LocalAPI.Methods.EnviarStudent();
            });
        },

        OnEnterEnviarStudent: function () {
            $('#txt-name-student, #txt-email-student, #txt-password-student, #slc-serie-student').keypress(function (e) {
                var code = e.keyCode || e.which;

                if (code === 13) {
                    e.preventDefault();

                    LocalAPI.Methods.EnviarStudent();
                }
            })
        },

        OnClickEnviarSchool: function () {
            $('#btn-school-enviar').off('click');
            $('#btn-school-enviar').on('click', function () {
                LocalAPI.Methods.EnviarSchool();
            });
        },

        OnEnterEnviarSchool: function () {
            $('#txt-school-name, #txt-school-email, #txt-school-password, #slc-serie-student').keypress(function (e) {
                var code = e.keyCode || e.which;

                if (code === 13) {
                    e.preventDefault();

                    LocalAPI.Methods.EnviarSchool();
                }
            })
        },

        OnClickEnviarSchoolSuccessful: function () {
            $('#btn-school-enviar-final').off('click');
            $('#btn-school-enviar-final').on('click', function () {
                LocalAPI.Methods.EnviarSchoolSuccessful();
            });
        }
        
    },

    Methods: {
        Enviar: function () {
            var email = $('#txt-email').val();
            var password = $('#txt-password').val();

            $.loader.open();

            $.ajax({
                url: GS_Path.GetUrl('/Home/Signin'),
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: JSON.stringify({ 'email': email, 'password': password })
            })
            .done(function (resultado) {
                $.loader.close();
                if (resultado != 'error') {
                    if (resultado == 'student')
                        window.location.href = GS_Path.GetUrl('/Student');
                    else if (resultado == 'teacher')
                        window.location.href = GS_Path.GetUrl('/Teacher');
                    else 
                        window.location.href = GS_Path.GetUrl('/School');
                }
                else {
                    
                    GS_Alert.Simples('Email ou Senha Inválidos!');
                }
            });
        },

        EnviarStudent: function () {

            var name = $('#txt-name-student').val();
            var email = $('#txt-email-student').val();
            var serie = $('#slc-serie-student').val();
            var password = $('#txt-password-student').val();

            $.loader.open();

            $.ajax({
                url: GS_Path.GetUrl('/Home/RegisterStudent'),
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: JSON.stringify({ 'name': name, 'email': email, 'serie': serie, 'password': password })
            })
            .done(function (resultado) {
                $.loader.close();
                if (resultado == 'success') {
                    window.location.href = GS_Path.GetUrl('/Student');
                }
                else {
                    GS_Alert.Simples(resultado);
                }
            });
        },

        EnviarSchool: function () {

            var name = $('#txt-school-name').val();
            var email = $('#txt-school-email').val();
            var password = $('#txt-school-password').val();

            $.loader.open();

            $.ajax({
                url: GS_Path.GetUrl('/Home/SchoolRegister'),
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: JSON.stringify({ 'name': name, 'email': email, 'password': password })
            })
            .done(function (resultado) {
                $.loader.close();
                if (resultado == 'success') {
                    window.location.href = GS_Path.GetUrl('/Home/SchoolRegisterSuccessful');
                }
                else {
                    GS_Alert.Simples(resultado);
                }
            });
        },

        EnviarSchoolSuccessful: function () {
            
            window.location.href = GS_Path.GetUrl('/School');
               
        }
    }
}