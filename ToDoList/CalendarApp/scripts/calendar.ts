
$('.new-event-button').click(function () {
    let eventPane = document.getElementById('schedule-event-pane');
    eventPane.style.display = 'block';

    $.get("../Event/ScheduleNewEvent", function (data: HTMLDivElement) {
        $('#schedule-event-pane').html(data);
    });
});

$('#schedule-event-submit-button').submit(function (e) {
    let formdata = document.getElementsByClassName('form-data');
    let formobj = {};
});

$('#schedule-event-cancel-button').click(function (e) {
    let eventobj = document.getElementById('schedule-event-pane');
    eventobj.removeChild(eventobj.children[0]);
    eventobj.style.display = 'none';
});