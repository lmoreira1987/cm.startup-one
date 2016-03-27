var GlobalAPI = {

    Init: function () {
        this.Events.Init();
    },

    Events: {

        Init: function () {
            this.OnClickLogout();
        },

        OnClickLogout: function () {
            $('.mnu-logout').off('click');
            $('.mnu-logout').on('click', function () {
                
                GlobalAPI.Methods.Logout();
            });


                
        },   
    },

    Methods: {

        Logout: function () {

            GS_Ajax.Ajax(GS_Path.GetUrl('/Home/Logout'), 'POST', 'json', null, function () {

                $.loader.open();

                window.location.href = GS_Path.GetUrl('/Home');
                
                $.loader.close();
            });
        }

    }
}
