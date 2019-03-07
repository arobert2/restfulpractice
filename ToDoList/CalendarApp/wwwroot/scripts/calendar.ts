
$('.new-event-button').click(function () {
    let eventPane = document.getElementById('schedule-new-event-pane');
    eventPane.style.display = 'block';
});

$('#schedule-event-submit-button').click(function (e) {
    let formhtmldata = document.querySelector('form');
    let formDataObj = new FormData(formhtmldata);
    let entries = formDataObj.entries;
    let strObj: KeyValuePair = {};
    for (let entry of formDataObj.entries()) {
        console.log(entry[0] + ', ' + entry[1]);
        strObj[entry[0]] = entry[1].toString();
    }

    let jsonFormData = JSON.stringify(strObj);
    console.log(jsonFormData);
    $.ajax({
        type: "POST",
        url: '../api/event',
        data: strObj,
        success: function (data, textStatus, jqXHR) {
            console.log('succeeded');
        },
        dataType: 'json'
    });
});

$('#schedule-event-cancel-button').click(function (e) {
    let eventPane = document.getElementById('schedule-new-event-pane');
    eventPane.style.display = 'none';
});

interface KeyValuePair {
    [key: string]: string;
}