jQuery(function ($) {
    $('.datepicker').datepicker({
        format: "dd/mm/yyyy",
        language: "pt-BR"
    });

    $('.datepicker').datepicker();
    $('.datepicker').datepicker('update');

    $('.mask-date').mask("99/99/9999");

    $(".mask-number").keypress(function (e) {
        if (String.fromCharCode(e.keyCode).match(/[^0-9]/g))
            return false;
    });

    $('.mask-tel').focusout(function () {
        var phone, element;
        element = $(this);
        element.unmask();
        phone = element.val().replace(/\D/g, '');
        if (phone.length > 11) {
            element.mask("(99) 99999-999?9");
        } else {
            element.mask("(99) 9999-9999?9");
        }
    }).trigger('focusout');
});

var LocalMask = {
    Init: function () {
        $('.datepicker').datepicker({
            format: "dd/mm/yyyy",
            language: "pt-BR"
        });

        $('.datepicker').datepicker();
        $('.datepicker').datepicker('update');

        $('.mask-date').mask("99/99/9999");

        $(".mask-number").keypress(function (e) {
            if (String.fromCharCode(e.keyCode).match(/[^0-9]/g))
                return false;
        });

        $('.mask-tel').focusout(function () {
            var phone, element;
            element = $(this);
            element.unmask();
            phone = element.val().replace(/\D/g, '');
            if (phone.length > 11) {
                element.mask("(99) 99999-999?9");
            } else {
                element.mask("(99) 9999-9999?9");
            }
        }).trigger('focusout');
    }
}