$(document).ready(function () {

    $("#register").show();
    $("#findOpponent").hide();
    $("#waitingForOpponent").hide();
    $("#game").hide();
    $("#findAnotherGame").hide();

    var game = $.connection.HubKnow;

    game.client.waitingForOpponent = function (message) {
        $("#information").html("<strong>Aguarde até que o seu adversário faz um movimento</strong>");
    };

    game.client.waitingForMarkerPlacement = function (message) {
        $("#information").html("<strong>Seu movimento</strong>");
    };

    game.client.foundOpponent = function (message) {
        $("#findAnotherGame").hide();
        $("#waitingForOpponent").hide();
        $("#gameInformation").html("Jogando com o nome: " + message);        

        //$("#game").html('<div id="information" /><br/>');
        //for (var i = 0; i < 9; i++) {
        //    $("#game").append("<span id=" + i + " class='box' />");
        //}

        var warGame = '';
        warGame += '<div class="row"><div class="col-md-12 col-sm-12 col-xs-12"><div class="x_panel"><div class="x_content"><div class="row"><div class="col-md-12 col-sm-12 col-xs-12 text-center"><label>PERGUNTA</label></div></div><div class="row"><div class="col-md-12 col-sm-12 col-xs-12">What is your name?</div><div class="col-md-12 col-sm-12 col-xs-12">&nbsp;</div><div class="col-md-12 col-sm-12 col-xs-12"><input type="radio" name="radAnswer" value="1" />My name is João</div><div class="col-md-12 col-sm-12 col-xs-12"><input type="radio" name="radAnswer" value="2" />The book is on the table</div><div class="col-md-12 col-sm-12 col-xs-12"><input type="radio" name="radAnswer" value="3" />I want to break free</div><div class="col-md-12 col-sm-12 col-xs-12"><input type="radio" name="radAnswer" value="4" />None of above</div><div class="col-md-12 col-sm-12 col-xs-12 text-center"><input type="button" name="btn-send" value="Enviar Resposta" class="btn btn-success" /></div></div></div></div></div></div>';

        //warGame += '<div class="row">';
        //warGame +=    '<div class="col-md-12 col-sm-12 col-xs-12">';
        //warGame +=        '<div class="x_panel">';
        //warGame +=            '<div class="x_content">';
        //warGame +=                '<div class="row">';
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12 text-center">';
        //warGame +=                        '<label>PERGUNTA</label>';
        //warGame +=                    '</div>';
        //warGame +=                '</div>';
        //warGame +=                '<div class="row">';
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12">';
        //warGame +=                        'What is your name?';
        //warGame +=                    '</div>';
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12">&nbsp;</div>';
        //warGame +=
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12">';
        //warGame +=                        '<input type="radio" name="radAnswer" value="1" />';
        //warGame +=                        'My name is João';
        //warGame +=                    '</div>';
        //warGame +=
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12">';
        //warGame +=                        '<input type="radio" name="radAnswer" value="2" />';
        //warGame +=                        'The book is on the table';
        //warGame +=                    '</div>';
        //warGame +=
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12">';
        //warGame +=                        '<input type="radio" name="radAnswer" value="3" />';
        //warGame +=                        'I want to break free';
        //warGame +=                    '</div>';
        //warGame +=
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12">';
        //warGame +=                        '<input type="radio" name="radAnswer" value="4" />';
        //warGame +=                        'None of above';
        //warGame +=                    '</div>';
        //warGame +=
        //warGame +=                    '<div class="col-md-12 col-sm-12 col-xs-12 text-center">';
        //warGame +=                        '<input type="button" name="btn-send" value="Enviar Resposta" class="btn btn-success" />';
        //warGame +=                    '</div>';
        //warGame +=                '</div>';
        //warGame +=            '</div>';
        //warGame +=        '</div>';
        //warGame +=    '</div>';
        //warGame += '</div>';

        $("#game").append(warGame);

        $("#game").show();
    };

    game.client.noOpponents = function (message) {
        $("#information").html("<strong>Estamos à procura de um adversário!</strong>");
    };

    game.client.addMarkerPlacement = function (message) {
        if (message.OpponentName !== $('#gamaName').val()) {
            $("#" + message.MarkerPosition).addClass("mark2");
            $("#" + message.MarkerPosition).addClass("marked");
            $("#information").html("<strong>Seu movimento!</strong>");
        } else {
            $("#" + message.MarkerPosition).addClass("mark1");
            $("#" + message.MarkerPosition).addClass("marked");
            $("#information").html("<strong>Espere o seu adversário para fazer a sua jogada</strong>");
        }
        $('#debug').append('<li>Marker was placed by ' + message.OpponentName + ' at position ' + message.MarkerPosition + '</li>');
    };

    game.client.opponentDisconnected = function (message) {
        $("#gameInformation").html("<strong>você perdeu " + message);
        //$('#debug').append('<li>Your opponent left! Congratulations you won!</li>');

        $("#findAnotherGame").show();
        $("#game").hide();
    };

    game.client.registerComplete = function (message) {
        $('#debug').append('<li>Você pode começar</li>');
    };

    game.client.gameOver = function (message) {
        $("#gameInformation").html("jogar novamente " + message);
        $("#information").html('<strong>o vencedor é ' + message + '</strong>');
        //$('#debug').append('<li>Game is over and We have a Winner!! Congratulations ' + message + '</li>');
        $("#findAnotherGame").show();
    }

    game.client.refreshAmountOfPlayers = function (message) {
        $("#amountOfGames").html(message.amountOfGames);
        $("#amountOfClients").html(message.amountOfClients);
        $("#totalAmountOfGames").html(message.totalGamesPlayed);
    };





    $("#game").on("click", ".box", function (event) {
        if ($(this).hasClass("marked")) return;

        game.server.play(event.target.id);
    });

    $("#registerName").click(function () {
        game.server.registerClient($('#gamaName').val());

        $("#register").hide();
        $("#findOpponent").show();
    });

    $(".findGame").click(function () {
        findGame();
    });

    $("#findAnotherGame").click(function () {
        $("#gameInformation").html("");
        $("#game").hide();
        $("#findAnotherGame").hide();
        game.server.registerClient($('#gamaName').val());

        findGame();
    });

    function findGame() {
        game.server.findOpponent();
        $("#waitingForOpponent").show();
        $("#register").hide();
        $("#findOpponent").hide();
    }

    $.connection.hub.start().done();
});