$(function () {

    $("#btnSave").click(function () {
        
    });

});


function Validate() {

    var FirstName = document.getElementById("FirstName").value;
    var LastName = document.getElementById("LastName").value;
    var EmailID = document.getElementById("EmailID").value;
    var PhoneNumber = document.getElementById("PhoneNumber").value;
    var Address = document.getElementById("Address").value;
    var DepartmentID = document.getElementById("DepartmentID").value;
    var Qualification = document.getElementById("Qualification").value;


    if (FirstName == "") {
        jAlert("Please Enter First Name");
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }

    if (LastName == "") {
        jAlert("Please Enter Last Name");
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }

    if (EmailID == "") {
        jAlert("Please Enter Email Address);
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }

    if (PhoneNumber == "") {
        jAlert("Please Enter Phone Number");
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }
    if (Address == "") {
        jAlert("Please Enter Address");
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }
    if (DepartmentID == "0") {
        jAlert("Please Select The Department");
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }
    if (Qualification == "0") {
        jAlert("Please Enter The Qualification");
        $('#screen').css({ "display": "block", "width": "", "height": "" });
        return false;
    }
}
