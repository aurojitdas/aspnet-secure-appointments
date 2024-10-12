$(document).ready(function () {

    InitializeCalendar();

});
function InitializeCalendar() {
    try {
        $('#calendar').fullCalendar({
            timezone: true,
            header: {
                left: 'prev,next,today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            selectable: true,
            editable: false,
            initialView: 'dayGridMonth'
        });

    } catch (e) {
        alert(e);
    }
}