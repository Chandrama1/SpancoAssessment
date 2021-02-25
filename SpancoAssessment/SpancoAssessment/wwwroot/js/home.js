$(document).ready(function () {

    (function () {
        let today = new Date();

        let date = String(today.getDate()).padStart(2, '0');
        let month = String(today.getMonth() + 1).padStart(2, '0');
        let year = today.getFullYear();

        today = year + '-' + month + '-' + date;
        $("#inpDoB").attr("max", today);
    })();

    $(".checkBoxAdd").change(function () {
        const checkBox = $(this).prop("checked");
        if (checkBox)
            updatePermAdd();
    }); 

    //$("#formPatient").submit(function () {

    //    e.preventDefault();
    //    let jsonToPost = {
    //        FirstName: $('#firstName').val(),
    //        MiddleName: $('#middleName').val(),
    //        LastName: $('#lastName').val(),
    //        Gender: $("input[name*=gender]:checked")[0].value,
    //        DateOfBirth: new Date($("#inpDoB").val()),
    //        CaseType: $("input[name*=case-type]:checked")[0].value,
    //        PoliceEnquiryRemark: $('#policeEnqRemark').val().trim(),
    //        PresentAddress: $("#preAdd").val().trim(),
    //        PermanentAddress: $("#permAdd").val().trim()
    //    }

    //    $.ajax({
    //        url: "https://localhost:44345/api/Home/SavePatientDetails",
    //        type: "POST",
    //        data: jsonToPost,
    //        processData: false,
    //        contentType: false,
    //        success: function (data) {

    //        },
    //        error: function (msg) {
    //        }
    //    });
    //});    
});


function getAge() {
    $("#inpDoB").val();
    let dob = new Date($("#inpDoB").val());
    let today = new Date();
    let difference = today - dob;
    let yearVal = 365.25 * 24 * 60 * 60 * 1000;
    //let monthVal = 30 * 24 * 60 * 60 * 1000;
    let ageInYears = Math.floor(difference / yearVal);
    //difference = difference - (ageInYears * yearVal);
    //let ageInMonths = Math.floor((difference % yearVal) / monthVal);
    //difference = difference - (ageInMonths * monthVal);
    //let ageInDays = Math.floor(difference / (24 * 60 * 60 * 1000));
    //$("#inpAge").val(`${ageInYears} years ${ageInMonths} months ${ageInDays} days`);
    $("#inpAge").val(`${ageInYears} years`);
}

function updatePermAdd() {
    let permAdd = $(".checkBoxAdd").prop("checked") ? $("#preAdd").val().trim() : $("#permAdd").val();
    $("#permAdd").val(permAdd);
}

function updatePreAdd() {
    let preAdd = $(".checkBoxAdd").prop("checked") ? $("#permAdd").val().trim() : $("#preAdd").val();
    $("#preAdd").val(preAdd);
}

function ValidateCaseType() {
    if ($("input[name*=case-type]:checked")[0].value === 'MLC') {
        $('#policeEnqRemark').prop('required', true);
    }
    else {
        $('#policeEnqRemark').prop('required', false);
    }
}