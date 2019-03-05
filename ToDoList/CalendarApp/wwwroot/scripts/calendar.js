$('.new-event-button').click(function () {
    let eventPane = document.getElementById('schedule-event-pane');
    eventPane.style.display = 'block';
    $.get("../Event/ScheduleNewEvent", function (data) {
        $('#schedule-event-pane').html(data);
    });
});
$('#schedule-event-submit-button').submit(function (e) {
    let formhtmldata = document.querySelector('form');
    let formData = new FormData(formhtmldata);
    let strObj;
    formData.forEach(function (value, key) {
        strObj[key] = value;
    });
    let jsonFormData = JSON.stringify(strObj);
    console.log(jsonFormData);
});
$('#schedule-event-cancel-button').click(function (e) {
    let eventobj = document.getElementById('schedule-event-pane');
    eventobj.removeChild(eventobj.children[0]);
    eventobj.style.display = 'none';
});
//# sourceMappingURL=calendar.js.map