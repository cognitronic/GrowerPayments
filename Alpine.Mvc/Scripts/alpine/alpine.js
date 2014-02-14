var baseUrl = "http://alpine.localhost/";

function CurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = mm + '/' + dd + '/' + yyyy + " " + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
    return today;
}

function dateToWcf(input) {
    var d = new Date(input);
    if (isNaN(d)) return null;
    return '\/Date(' + d.getTime() + '-0000)\/';
}

//------------ Master Schedule ------------------ 
function loadAssessments()
{
    var cy = "";
    if ($("#ddlcropyears option:selected").text() == "" || $("#ddlcropyears option:selected").text() == 'undefined') {
        cy = new Date().getFullYear();
    }
    else
    {
        cy = $("#ddlcropyears option:selected").text();
    }
    $("#assessmentsContainer").load(baseUrl + 'MasterSchedule/Assessments' + "?cropyear=" + cy);

    this.loadPaymentTemplates();
}



function loadPaymentTemplates() {
    var cy = "";
    if ($("#ddlcropyears option:selected").text() == "" || $("#ddlcropyears option:selected").text() == 'undefined') {
        cy = new Date().getFullYear();
    }
    else {
        cy = $("#ddlcropyears option:selected").text();
    }
    $("#paymentsContainer").load(baseUrl + 'MasterSchedule/Payments' + "?cropyear=" + cy);
}

function loadVarieties()
{
    $("#varietiesContainer").load(baseUrl + 'MasterSchedule/Varieties');
}

function cropYearChanged(e)
{
    //loadAssessments();
}

//------------ End Master Schedule ---------------

//------------ Grower Profile --------------------

function loadGrowerAssessments(cy, gid)
{
    $("#assessments").load(baseUrl + 'GrowerProfile/Assessments' + "?cropyear=" + cy + '&growerid=' + gid);
}

function loadGrowerNotes(cy, gid, status) {
    if (status == "" || status == 'undefined') {
        status = "True";
    }
    else {
        $("#notes").load(baseUrl + 'GrowerProfile/Notes' + "?cropyear=" + cy + '&growerid=' + gid + "&isactive=" + status);
    }
}

function loadGrowerNotesByStatus(cy, gid, status) {
    if (status == "" || status == 'undefined') {
        status = "True";
    }
    else {
        $("#notes").html("");
        $("#notes").load(baseUrl + 'GrowerProfile/Notes' + "?cropyear=" + cy + '&growerid=' + gid + "&status=" + status);
    }
}


function loadGrowerSettings(cy, gid) {
    $("#settings").load(baseUrl + 'GrowerProfile/Settings' + "?cropyear=" + cy + '&growerid=' + gid);
}

function loadGrowerPayments(cy, gid) {
    $("#payments").load(baseUrl + 'GrowerProfile/Payments' + "?cropyear=" + cy + '&growerid=' + gid);
}

function loadGrowerPayees(cy, gid) {
    $("#payees").load(baseUrl + 'GrowerProfile/Payees' + "?cropyear=" + cy + '&growerid=' + gid);
}

function addNewGrowerPayment(cy, gid, pid) {
    var payment = new Payment();
    payment.ID = pid;
    payment.CropYear = cy;
    payment.GrowerID = gid;
    payment.PaymentType = pid;
    $.ajax({
        url: 'http://alpine.localhost/api/Payments/CreateGrowerPayment',
        type: 'POST',
        data: JSON.stringify(payment),
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //window.location = data.split(':')[2];
            loadGrowerPayments(cy, gid);
            
            //alert(notice);
            $("#mainwrapper").before(notice);
            $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
            var notice = "<div class='notice closing'><div class='note note-success'><button type='button' class='close'>×</button><strong>Payment Successfully Created!!</strong></div></div>";
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function addNewPayee(cy, gid, pid) {
    var payee = new Payee();
    payee.CropYear = cy;
    payee.GrowerID = gid;
    $.ajax({
        url: 'http://alpine.localhost/api/GrowerProfile/CreatePayee',
        type: 'POST',
        data: JSON.stringify(payee),
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            //window.location = data.split(':')[2];
            loadGrowerPayees(cy, gid);

            //alert(notice);
            $("#mainwrapper").before(notice);
            $('#mainwrapper').effect("highlight", { color: "#7fd658" }, 1000);
            var notice = "<div class='notice closing'><div class='note note-success'><button type='button' class='close'>×</button><strong>Payee Successfully Created!!</strong></div></div>";
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function Payment() {
    this.ID = 0;
    this.GrowerID = 0;
    this.PaymentType = 0;
    this.Name = "";
    this.Description = "";
    this.PaymentDate = CurrentDate();
    this.CropYear = "";
    this.AccountID = 0;
    this.IsTemplate = false;
    this.TransactionCompleted = false;
    this.Amount = 0.0;
    this.TransactionDate = CurrentDate();
    this.SplitHartley = false;
    this.Note = "";
    this.TemplateID = 0;
}

function PaymentVariety() {
    this.ID = 0;
    this.PaymentID = 0;
    this.VarietyID = 0;
    this.Price = 0.0;
    this.NutwareID = 0;
}

function Payee()
{
    this.ID = 0;
    this.GrowerID = 0;
    this.FirstName = "";
    this.LastName = "";
    this.CheckMadeTo = "";
    this.Address = "";
    this.City = "";
    this.State = "";
    this.Zip = "";
    this.Email = "";
    this.Fax = "";
    this.WorkPhone = "";
    this.CellPhone = "";
    this.SplitPercent = "";
    this.EnteredBy = 0;
    this.ChangedBy = 0;
    this.DateCreated = CurrentDate();
    this.LastUpdated = CurrentDate();
}

function GrowerAssessment()
{
    this.ID = 0;
    this.AssessmentID = 0;
    this.ChangedBy = 0;
    this.CropYear = "";
    this.DateCreated = CurrentDate();
    this.EnteredBy = 0;
    this.GrowerID = 0;
    this.LastUpdated = CurrentDate();
}

function GrowerNote() {
    this.ID = 0;
    this.Note = "";
    this.DateCreated = CurrentDate();
    this.EnteredBy = 0;
    this.GrowerID = 0;
    this.LastUpdated = CurrentDate();
    this.ChangedBy = 0;
    this.IsActive = true;
}

function GrowerProfile() {
    this.ID = 0;
    this.GrowerID = 0;
    this.IsStandardSchedule = true;
}

function Variety()
{
    this.ID = 0;
    this.Name = "";
    this.Description = "";
    this.AccountID = 0;
    this.NutwareID = 0;
}