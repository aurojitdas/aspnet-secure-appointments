var routeURL = location.protocol + "//" + location.host;                //This will retrieve the host and location.
$(document).ready(function () {
    kendo.culture("en-GB"); // Set the culture to British English for dd/MM/yyyy format
    $("#appointmentDate").kendoDateTimePicker({
        format: "yyyy-MM-dd HH:mm:ss", // Set the desired format
        value: new Date(),
        dateInput: false       
    });

    InitializeCalendar();
});
var calendar;
function InitializeCalendar() {
    try {      
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) { 
            calendar = new FullCalendar.Calendar(calendarEl, {
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
                },
                eventDisplay: 'block',
                events: function (fetchInfo, successCallback, failureCallback) {
                    console.log("Fetching events..."); // Add this line
                    $.ajax({
                        url: routeURL + '/api/Appointment/GetCalendarData?doctorId= '+$("#DoctorId").val(),
                        type: 'GET',
                        dataType: 'JSON',
                        success: function (response) {
                            var events = [];
                            if (response.status === 1) {
                                $.each(response.dataenum, function(i, data) {
                                    events.push({
                                        title:data.title,
                                        description : data.description,
                                        start: data.startDate.replace(" ", "T").replace(/\./g, ":"),
                                        end: data.endDate.replace(" ", "T").replace(/\./g, ":"),
                                        backgroundColor: "#28a745",
                                        borderColor: "#162466",
                                        textColor: "white",
                                        id: data.id
                                    });
                                })
                            }
                            console.log(events); // Log each event to verify
                            successCallback(events);
                        },
                        error: function (xhr) {
                            $.notify("Error", "error");
                        }
                    });
                },
                eventClick: function (info) {
                    getEventDetailsByEventId(info.event);
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
    if (isEventDetails != null) {

        $("#title").val(obj.title);
        $("#description").val(obj.description);
        $("#appointmentDate").val(obj.startDate);
        $("#duration").val(obj.duration);
        $("#DoctorId").val(obj.doctorId);
        $("#patientId").val(obj.patient);
        $("#id").val(obj.id);
    } else {
        $("#appointmentDate").val(obj.startStr +" "+ new moment().format("hh:mm A"));
        $("#id").val(0);
    }
    $("#appointmentInput").modal("show"); 
}
//Hiding Modal on clicking close
function onCloseModal() {
    $("#appointmentForm")[0].reset();
    $("#id").val(0);
    $("#title").val("");
    $("#description").val("");
    $("#appointmentDate").val("");
    $("#duration").val("");
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
                console.log(JSON.stringify(requestData));
                if (response.status === 1 || response.status === 2) {
                    calendar.refetchEvents();
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify(response.message, "error");
                }
            },
            error: function (xhr) {
                console.log(JSON.stringify(requestData));
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

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/Appointment/GetCalendarDataById/' + info.id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {
           
            if (response.status === 1&&response.dataenum!==undefined) {
                onShowModal(response.dataenum,true)
            }
            //console.log(events); // Log each event to verify
            //successCallback(events);
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onDoctorChange() {
    calendar.refetchEvents();
}
