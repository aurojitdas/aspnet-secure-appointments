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
            select: function (event) {  //Creating onclick event
                onShowModal(event, null);   
            }
        });

    } catch (e) {
        alert(e);
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