// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var gameToDeleteId;
var gameToDeleteTitle;

function Test()
{
    alert("Hij doet 't em");
}

function ClosePopup(){

    $('.popup').removeClass('show');
}

function OpenPopup()
{
    $('#game-to-delete').html(gameToDeleteTitle);
    $('.popup').addClass('show');
}

function DeleteGame(id)
{

    $.ajax({
        url: '/Games/DeleteGame',
        data: { gameId: id }
     }).done(function() {
        ClosePopup();
        location.reload(); 
    });

}

function AddGameToDelete(id, title)
{
    gameToDeleteId = id;
    gameToDeleteTitle = title;
}

function GetGameToDeleteId()
{
    return gameToDeleteId;
}

$( document ).ready(function() 
{

});