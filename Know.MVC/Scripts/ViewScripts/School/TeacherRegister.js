/// <reference path="../Global/Global.js" />

var LocalAPI = {

    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.OnClickCancelar();
            this.OnClickCadastrar();
        },

        OnClickCancelar: function () {
            $('#btn-cancelar').off('click');
            $('#btn-cancelar').on('click', function () {
                LocalAPI.Methods.Cancelar();
            });
        },

        OnClickCadastrar: function () {
            $('#btn-cadastrar').off('click');
            $('#btn-cadastrar').on('click', function () {
                LocalAPI.Methods.Cadastrar();
            });
        }

    },

    Methods: {

        Cancelar: function () {
            $.loader.open();
            LocalAPI.Methods.LimparCampos();
            $.loader.close();
        },

        LimparCampos: function () {

            $('#txt-name').val('');
            $('#txt-email').val('');
            $('#txt-birthday').val('');
            $('#slc-genre').val('');
            $('#txt-document').val('');
            $('#txt-phone').val('');
            $('#txt-mobile').val('');
        },

        Cadastrar: function () {
            $.loader.open();

            var mensagem = LocalAPI.Methods.ValidaTela();

            if (mensagem == '') {

                var objeto = new Object();
                objeto = LocalAPI.Methods.PreencherObjetoCadastrar();

                GS_Ajax.Ajax(GS_Path.GetUrl('/School/TeacherRegister'), 'POST', 'json', objeto, function (resultado) {
                    if (resultado) {
                        GS_Alert.SimplesCallBack('Cadastro efetuado com sucesso!', function () {
                            LocalAPI.Methods.LimparCampos();
                            window.location.href = GS_Path.GetUrl('/School/TeacherRegister');
                        });
                    }
                    else {
                        GS_Alert.Simples('Ocorreu um erro ao tentar salvar! <br/> Por favor, entre em contato com a equipe técnica responsável.');
                    }

                    $.loader.close();
                });
            }
            else {
                var erro = 'Foram encontrados os seguintes erros: <br><br>';
                GS_Alert.Simples(erro + '<ul>' + mensagem + '</ul>');
            }

            $.loader.close();
        },

        ValidaTela: function () {
            var mensagem = '';

            if ($('#txt-name').val() == '') {
                mensagem += '<li>O campo Nome é obrigatório!</li>';
                $('#txt-name').parent().addClass('has-error');
            }
            else {
                $('#txt-name').parent().removeClass('has-error');
            }

            if ($('#txt-email').val() == '') {
                mensagem += '<li>O campo E-mail é obrigatório!</li>';
                $('#txt-email').parent().addClass('has-error');
            }
            else {
                $('#txt-email').parent().removeClass('has-error');
            }

            if ($('#txt-document').val() == '') {
                mensagem += '<li>O campo CPF é obrigatório!</li>';
                $('#txt-document').parent().addClass('has-error');
            }
            else {
                $('#txt-document').parent().removeClass('has-error');
            }

            return mensagem;
        },

        PreencherObjetoCadastrar: function () {
            var objeto = new Object();
            var date = new Date();

            objeto.Usuario = new Object();
            objeto.Usuario.nome = $('#txt-name').val();
            objeto.Usuario.email = $('#txt-email').val();
            objeto.Usuario.documento = $('#txt-document').val();
            objeto.Usuario.telefone = $('#txt-phone').val();
            objeto.Usuario.celular = $('#txt-mobile').val();
            objeto.Usuario.ativo = true;
            objeto.Usuario.dataCriacao = date;

            objeto.dataNascimento = $('#txt-birthday').val();
            objeto.idSexo = $('#slc-genre option:selected').val();
            objeto.ativo = true;
            objeto.dataCriacao = date;



            //objeto.nome = $('#txt-name').val();
            //objeto.email = $('#txt-email').val();
            //objeto.dataNascimento = $('#txt-birthday').val();
            //objeto.idSexo = $('#slc-genre option:selected').val();
            //objeto.cpf = $('#txt-document').val();
            //objeto.telefone = $('#txt-phone').val();
            //objeto.celular = $('#txt-mobile').val();
            //objeto.ativo = true;
            //objeto.dataCriacao = date;

            return objeto;
        }
    }
}