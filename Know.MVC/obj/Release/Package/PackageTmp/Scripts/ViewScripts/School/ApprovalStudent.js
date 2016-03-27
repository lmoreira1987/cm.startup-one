/// <reference path="../Global/Global.js" />

var LocalAPI = {


    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.OnClickApprove();
            this.OnClickDisapprove();
        },

        OnClickApprove: function () {
            //console.log('app');
            $('.img-approve').off('click');
            $('.img-approve').on('click', function () {
                //console.log($(this).attr('data-id'));
                //alert('You Clicked Me');
                LocalAPI.Methods.ApproveDisapprove($(this).attr('data-id'), 'approve');
            });
        },

        OnClickDisapprove: function () {
            //console.log('dis');
            $('.img-disapprove').off('click');
            $('.img-disapprove').on('click', function () {
                //console.log($(this).attr('data-id'));
                //alert('You Clicked Me222');
                LocalAPI.Methods.ApproveDisapprove($(this).attr('data-id'), 'disapprove');
            });
        }

    },

    Methods: {

        ApproveDisapprove: function (id, approveDisapprove) {

            $.loader.open();

            $.ajax({
                url: GS_Path.GetUrl('/School/ApproveDisapproveStudent'),
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: JSON.stringify({ 'id': id, 'approveDisapprove': approveDisapprove })
            })
            .done(function (resultado) {
                if (resultado == 'approve') {
                    GS_Alert.SimplesCallBack('Aprovação efetuada com sucesso!', function () {
                        window.location.href = GS_Path.GetUrl('/School/ApprovalStudent');
                    });
                }
                else if (resultado == 'disapprove') {
                    GS_Alert.SimplesCallBack('Desaprovação efetuada com sucesso!', function () {
                        window.location.href = GS_Path.GetUrl('/School/ApprovalStudent');
                    });
                }
                else {
                    GS_Alert.Simples('Ocorreu um erro ao tentar salvar! <br/> Por favor, entre em contato com a equipe técnica responsável.');
                }

                $.loader.close();
            });
        }
        
    }
}