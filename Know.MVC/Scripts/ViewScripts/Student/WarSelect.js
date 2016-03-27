/// <reference path="../Global/Global.js" />

var LocalAPI = {

    ObjetoPreenchido: new Array(),
    chat: new Object(),

    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.Configuration();
            this.OnClickNewWar();            
        },

        Configuration: function () {
            chat = $.connection.chatHub;
            $.connection.hub.start();
        },

        OnClickNewWar: function () {
            $('#btn-new-war').off('click');
            $('#btn-new-war').on('click', function () {
                LocalAPI.Methods.NewWar();
            });
        }
    },

    Methods: {

        NewWar: function () {
            $.loader.open();

            GS_Ajax.AjaxVoid(GS_Path.GetUrl('/Student/AddUserToWarRoomStage'), 'POST', 'json', function (resultado) {

                chat.server.connect(resultado);

                $.loader.close();
            });
        }

    }
}