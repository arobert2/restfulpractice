
$('.new-event-button').on('click', function () {
    let eventPane = document.getElementById('schedule-event-pane');
    if (eventPane.style.display === 'none')
        eventPane.style.display = 'block';
    else
        eventPane.style.display = 'none';

    $.get("../Event/ScheduleNewEvent", function (data: HTMLDivElement) {
        $('#schedule-event-pane').html(data);
    });
});