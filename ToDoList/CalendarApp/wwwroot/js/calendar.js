var clicked;

$('.calender-cell').click(function (event) {
    if (clicked)
        clicked.css('background-color', 'blue');
    $('.current-day > .day-header').css('background-color', 'darkblue');
    clicked = event.target;
    clicked.css('background-color', 'yellow');

});