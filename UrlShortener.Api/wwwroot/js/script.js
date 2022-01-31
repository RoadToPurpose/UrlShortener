'use strict';

async function ShowShortedLink(){
    
    const response = await fetch(window.location.origin, {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({Url : $("#Url").val()})
    });
    $("#Url").val("");
    $("#Result").text("");
    if (response.ok === true) {
        const UrlModel = await response.json();
        
        $("#Result").append("<div class=\"alert alert-success\"> " +
            `Original URL: ${UrlModel.originalUrl}<br>` +
            `Shorted URL: <a href=\"${window.location.origin + "/"+ UrlModel.key}\" > ${window.location.origin + "/"+ UrlModel.key} </div>`);
    } else {
        if(response.status === 400){
            $("#Result").append("<div class=\"alert alert-danger\"> Please enter a valid URL to shorten.</div>");
        } else {
            $("#Result").append("<div class=\"alert alert-danger\"> An unknown error has occurred. Please make sure that you have a stable Internet connection and this site is not included in the list of blocked resources.</div>");
        }
    }
    
}

$(document).ready(function() {
    $("#Url").keydown(async function(e) {
        if(e.keyCode === 13) {
            e.preventDefault()
            ShowShortedLink();
        }
    });
    
    $( "#SubmitButton" ).click(ShowShortedLink);
});