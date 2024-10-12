var routeURL = location.protocol + "//" + location.host;                //This will retrieve the host and location.
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });

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

function onSubmitForm() {
    if (checkValidation()) {
        //Getting all the appointment data from the form using ID for passing it to the controller
       
        var requestData = {
            Id: parseInt($("#id").val()),
            Title: $("#title").val(),
            Description: $("#description").val(),
            StartDate: $("#appointmentDate").val(),
            EndDate: null,
            Duration: $("#duration").val(),
            DoctorId: $("#DoctorId").val(),
            Patient: $("#patientId").val(),
            IsDoctorApproved: "false",
            AdminId: "",
            DoctorName: "",
            PatientName: "",
            AdminName: "",
            IsForClient: null
        };

        $.ajax({
            url: routeURL + '/api/Appointment/SaveCalendarData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status === 1 || response.status === 2) {
                    //calendar.refetchEvents();
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify(response.message, "error");
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }
        });
    }
}

function checkValidation() {
    var isValid = true;
    if ($("#title").val() === undefined || $("#title").val() === "") {
        isValid = false;
        $("#title").addClass('error');
    }
    else {
        $("#title").removeClass('error');
    }

    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
        isValid = false;
        $("#appointmentDate").addClass('error');
    }
    else {
        $("#appointmentDate").removeClass('error');
    }

    return isValid;

}

