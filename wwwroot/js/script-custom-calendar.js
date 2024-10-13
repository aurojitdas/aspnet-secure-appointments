var routeURL = location.protocol + "//" + location.host;                //This will retrieve the host and location.
$(document).ready(function () {
    kendo.culture("en-GB"); // Set the culture to British English for dd/MM/yyyy format
    $("#appointmentDate").kendoDateTimePicker({
        format: "dd/MM/yyyy h:mm tt", // Set the desired format
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
                                        backgroundColor: data.isDoctorApproved === "True" ? "#28a745" : "#dc3545",
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
        $("#DoctorId").val(obj.DoctorId);
        $("#patientId").val(obj.patient);
        $("#id").val(obj.id);
    }
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

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/Appointment/GetCalendarDataById/' + info.id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {
           
            if (response.status === 1&&response.dataenum!==undefined) {
                onShowModal(response.dataenum,true)
            }
            console.log(events); // Log each event to verify
            successCallback(events);
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}
