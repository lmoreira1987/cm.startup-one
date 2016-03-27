/// <reference path="../Global/Global.js" />

var LocalAPI = {

    ObjetoPreenchido: new Array(),

    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.OnClickCancelar();
            this.OnClickCadastrar();
            this.OnClickFinalizar();
        },

        OnClickCancelar: function () {
            $('#btn-cancelar').off('click');
            $('#btn-cancelar').on('click', function () {
                LocalAPI.Methods.CancelarPergunta();
            });
        },

        OnClickCadastrar: function () {
            $('#btn-cadastrar').off('click');
            $('#btn-cadastrar').on('click', function () {
                LocalAPI.Methods.CadastrarPergunta();
            });
        },

        OnClickFinalizar: function () {
            $('#btn-finalizar').off('click');
            $('#btn-finalizar').on('click', function () {
                LocalAPI.Methods.FinalizarCadastroPergunta();
            });
        }

    },

    Methods: {

        CancelarPergunta: function () {
            $.loader.open();
            LocalAPI.Methods.LimparCampos();

            LocalAPI.ObjetoPreenchido = new Array(),

            $('#tbl-respostas').empty();

            $.loader.close();
        },

        LimparCampos: function () {

            $('#slc-idioma').val('');
            $('#slc-disciplina').val('');
            $('#slc-serie').val('');
            $('#slc-dificuldade').val('');
            $('#txt-pergunta').val('');

            $('#txt-resposta1').val('');
            $('#txt-explicacao1').val('');
            $('#chk-resposta1').val('cheked');
            $('#chk-resposta1').parent().addClass('checked');

            $('#txt-resposta2').val('');
            $('#txt-explicacao2').val('');
            $('#chk-resposta2').parent().removeClass('checked');

            $('#txt-resposta3').val('');
            $('#txt-explicacao3').val('');
            $('#chk-resposta3').parent().removeClass('checked');

            $('#txt-resposta4').val('');
            $('#txt-explicacao4').val('');
            $('#chk-resposta4').parent().removeClass('checked');
        },

        FinalizarCadastroPergunta: function () {

            var objeto = new Array();
            objeto = LocalAPI.ObjetoPreenchido;

            GS_Ajax.Ajax(GS_Path.GetUrl('/School/AddQuestionFinalizar'), 'POST', 'json', objeto, function (resultado) {
                if (resultado) {
                    GS_Alert.SimplesCallBack('Cadastro efetuado com sucesso!', function () {
                        LocalAPI.Methods.LimparCampos();
                        LocalAPI.ObjetoPreenchido = new Array(),
                        $('#tbl-respostas').empty();
                        console.log('teste');
                        window.location.href = GS_Path.GetUrl('/School/AddQuestion');
                    });
                }
                else {
                    GS_Alert.Simples('Ocorreu um erro ao tentar salvar! <br/> Por favor, entre em contato com a equipe técnica responsável.');
                }

                $.loader.close();
            });
        },

        CadastrarPergunta: function () {
            $.loader.open();

            var mensagem = LocalAPI.Methods.ValidaTela();

            if (mensagem == '') {

                var objeto = new Object();
                objeto = LocalAPI.Methods.PreencherObjetoCadastrar();

                LocalAPI.ObjetoPreenchido.push(objeto);
                var conteudo = LocalAPI.Methods.CriarConteudoTabela(objeto);

                $('#tbl-respostas').append(conteudo);

                LocalAPI.Methods.LimparCampos();

                GS_Alert.Simples('Pergunta e respostas adionadas com sucesso. <br> Para finalizar e completar o cadastro clique em Finalizar!');

            }
            else {
                var erro = 'Foram encontrados os seguintes erros: <br><br>';
                GS_Alert.Simples(erro + '<ul>' + mensagem + '</ul>');
            }

            $.loader.close();
        },

        ValidaTela: function () {
            var mensagem = '';

            if ($('#slc-idioma').val() == '') {
                mensagem += '<li>O campo Idioma é obrigatório!</li>';
                $('#slc-idioma').parent().addClass('has-error');
            }
            else {
                $('#slc-idioma').parent().removeClass('has-error');
            }

            if ($('#slc-disciplina').val() == '') {
                mensagem += '<li>O campo Disciplina é obrigatório!</li>';
                $('#slc-disciplina').parent().addClass('has-error');
            }
            else {
                $('#slc-disciplina').parent().removeClass('has-error');
            }

            if ($('#slc-serie').val() == '') {
                mensagem += '<li>O campo Série é obrigatório!</li>';
                $('#slc-serie').parent().addClass('has-error');
            }
            else {
                $('#slc-serie').parent().removeClass('has-error');
            }

            if ($('#slc-dificuldade').val() == '') {
                mensagem += '<li>O campo Dificuldade é obrigatório!</li>';
                $('#slc-dificuldade').parent().addClass('has-error');
            }
            else {
                $('#slc-dificuldade').parent().removeClass('has-error');
            }

            if ($('#txt-pergunta').val() == '') {
                mensagem += '<li>O campo Pergunta é obrigatório!</li>';
                $('#txt-pergunta').parent().addClass('has-error');
            }
            else {
                $('#txt-pergunta').parent().removeClass('has-error');
            }

            // ---- Respostas

            if ($('#txt-resposta1').val() == '') {
                mensagem += '<li>O campo Resposta 1 é obrigatório!</li>';
                $('#txt-resposta1').parent().addClass('has-error');
            }
            else {
                $('#txt-resposta1').parent().removeClass('has-error');
            }

            if ($('#txt-resposta2').val() == '') {
                mensagem += '<li>O campo Resposta 2 é obrigatório!</li>';
                $('#txt-resposta2').parent().addClass('has-error');
            }
            else {
                $('#txt-resposta2').parent().removeClass('has-error');
            }

            if ($('#txt-resposta3').val() == '') {
                mensagem += '<li>O campo Resposta 3 é obrigatório!</li>';
                $('#txt-resposta3').parent().addClass('has-error');
            }
            else {
                $('#txt-resposta3').parent().removeClass('has-error');
            }

            if ($('#txt-resposta4').val() == '') {
                mensagem += '<li>O campo Resposta 4 é obrigatório!</li>';
                $('#txt-resposta4').parent().addClass('has-error');
            }
            else {
                $('#txt-resposta4').parent().removeClass('has-error');
            }

            return mensagem;
        },

        CriarConteudoTabela: function (objeto) {
            var conteudoTabela = '';

            conteudoTabela += '<tr>';            
            conteudoTabela += '<td>' + objeto.nomeIdioma + '</td>';
            conteudoTabela += '<td>' + objeto.nomeDisciplina + '</td>';
            conteudoTabela += '<td>' + objeto.nomeSerie + '</td>';
            conteudoTabela += '<td>' + objeto.nomeDificuldade + '</td>';
            conteudoTabela += '<td>' + objeto.nome + '</td>';
            conteudoTabela += '</tr>';

            conteudoTabela += '<tr>';
            conteudoTabela += '<td>&nbsp;</td>';
            conteudoTabela += '<td colspan=4><table id="tbl-respostas-nao-finalizadas" class="table table-bordered">';
            conteudoTabela += '<thead>';
            conteudoTabela += '<tr>';
            conteudoTabela += '<th>Resposta</th>';
            conteudoTabela += '<th>Explicação</th>';
            conteudoTabela += '<th width="50px">Correta?</th>';
            conteudoTabela += '</tr>';
            conteudoTabela += '</thead>';
            conteudoTabela += '<tbody>';

            for (var i = 0; i < objeto.respostas.length; i++) {
                conteudoTabela += '<tr>';
                conteudoTabela += '<td>' + objeto.respostas[i].nome + '</td>';
                conteudoTabela += '<td>' + objeto.respostas[i].explicacao + '</td>';
                var correta = '';
                if (objeto.respostas[i].correta == true) correta = 'Sim'; else correta = 'Não';
                conteudoTabela += '<td>' + correta + '</td>';
                conteudoTabela += '</tr>';
            }

            conteudoTabela += '</tbody>';
            conteudoTabela += '</table></td></tr>';

            return conteudoTabela;
        },

        PreencherObjetoCadastrar: function () {
            var objeto = new Object();
            var date = new Date();

            objeto.idIdioma = $('#slc-idioma').val();
            objeto.nomeIdioma = $('#slc-idioma option:selected').text();

            objeto.idDisciplina = $('#slc-disciplina').val();
            objeto.nomeDisciplina = $('#slc-disciplina option:selected').text();

            objeto.idSerie = $('#slc-serie').val();
            objeto.nomeSerie = $('#slc-serie option:selected').text();

            objeto.idDificuldade = $('#slc-dificuldade').val();
            objeto.nomeDificuldade = $('#slc-dificuldade option:selected').text();

            objeto.nome = $('#txt-pergunta').val();
            objeto.ativo = true;
            objeto.dataCriacao = date;
            objeto.respostas = new Array();

            // Resposta 1
            var resposta1 = new Object();
            resposta1.nome = $('#txt-resposta1').val();
            resposta1.explicacao = $('#txt-explicacao1').val();
            resposta1.idIdioma = $('#slc-idioma').val();
            resposta1.nomeIdioma = $('#slc-idioma option:selected').text();
            resposta1.ativo = true;
            resposta1.dataCriacao = date;
            if ($('#chk-resposta1').is(':checked')) {
                resposta1.correta = true;
            } else {
                resposta1.correta = false;
            }

            objeto.respostas.push(resposta1);

            // Resposta 2
            var resposta2 = new Object();
            resposta2.nome = $('#txt-resposta2').val();
            resposta2.explicacao = $('#txt-explicacao2').val();
            resposta2.idIdioma = $('#slc-idioma').val();
            resposta2.nomeIdioma = $('#slc-idioma option:selected').text();
            resposta2.ativo = true;
            resposta2.dataCriacao = date;
            if ($('#chk-resposta2').is(':checked')) {
                resposta2.correta = true;
            } else {
                resposta2.correta = false;
            }

            objeto.respostas.push(resposta2);

            // Resposta 3
            var resposta3 = new Object();
            resposta3.nome = $('#txt-resposta3').val();
            resposta3.explicacao = $('#txt-explicacao3').val();
            resposta3.idIdioma = $('#slc-idioma').val();
            resposta3.nomeIdioma = $('#slc-idioma option:selected').text();
            resposta3.ativo = true;
            resposta3.dataCriacao = date;
            if ($('#chk-resposta3').is(':checked')) {
                resposta3.correta = true;
            } else {
                resposta3.correta = false;
            }

            objeto.respostas.push(resposta3);

            // Resposta 4
            var resposta4 = new Object();
            resposta4.nome = $('#txt-resposta4').val();
            resposta4.explicacao = $('#txt-explicacao4').val();
            resposta4.idIdioma = $('#slc-idioma').val();
            resposta4.nomeIdioma = $('#slc-idioma option:selected').text();
            resposta4.ativo = true;
            resposta4.dataCriacao = date;
            if ($('#chk-resposta4').is(':checked')) {
                resposta4.correta = true;
            } else {
                resposta4.correta = false;
            }

            objeto.respostas.push(resposta4);

            return objeto;
        },
    }
}