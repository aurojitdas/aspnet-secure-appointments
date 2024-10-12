$(document).ready(function () {

    InitializeCalendar();

});
function InitializeCalendar() {
    try {      
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) { 
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                editable: false,
                select: function (event) {  //Creating onclick event
                    onShowModal(event, null);
                }
            })
            calendar.render();
        }
    } catch (e) {
        alert(e.stack);
    }
}
//Showing Modal on click
function onShowModal(obj, isEventDetails) {
    $("#appointmentInput").modal("show"); 
}
//Hiding Modal on clicking close
function onCloseModal() {
    $("#appointmentInput").modal("hide");
}