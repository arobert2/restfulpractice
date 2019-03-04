// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.new-event-button').on('click', function() {
    $.get("../Event/ScheduleNewEvent", function (data) {
        $(".schedule-event-pane").html(data);
    });
});