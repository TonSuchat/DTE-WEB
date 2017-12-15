@ModelType Entities.Transaction

@Code
    ViewData("Title") = "แก้ไข-S/O"
End Code

@section scripts

    <style type="text/css">
        input,
        select,
        textarea,
        .input-group {
            max-width: 100% !important;
        }
    </style>

    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script src="~/Scripts/bootbox.min.js"></script>
    <script src="~/Scripts/helpers.js"></script>
    <script type="text/javascript">

        $(function () {

            $('#btnEdit').click(function () {
                $('#formEditSO').submit();
            });

            //assign pca,gpu totaltime to text input
            $('#txtTotalPCA').val(@Model.PCATotalMin);
            $('#txtTotalGPU').val(@Model.GPUTotalMin);

            //datepicker
            InitialDateTimePicker("STADTPicker", GetDateFromServerDate('@Model.ETA'));
            $('#STADTPicker').on('dp.change', function (e) {
                $('#ETA').val(GetStringFormatByDate(new Date(e.date)));
            });
            InitialDateTimePicker("ETDDTPicker", GetDateFromServerDate('@Model.ETD'));
            $('#ETDDTPicker').on('dp.change', function (e) {
                console.log(e);
                if (!e.date) $('#ETD').val(null);
                else $('#ETD').val(GetStringFormatByDate(new Date(e.date)));
            });

            //PCA
            InitialDateTimePicker("PCAStartDTPicker", GetDateFromServerDate('@Model.PCAStart'));
            InitialDateTimePicker("PCAStopDTPicker", GetDateFromServerDate('@Model.PCAEnd'));
            $("#PCAStartDTPicker").on("dp.change", function (e) {
                if (!e.date) $('#PCAStart').val(null);
                else $('#PCAStart').val(GetStringFormatByDate(new Date(e.date)));
                $('#PCAStopDTPicker').data("DateTimePicker").minDate(e.date);
                //diff total time
                DiffStartStopDate(e.date, $('#PCAStopDTPicker').data("DateTimePicker").date(), 'txtTotalPCA');
                $('#PCATotalMin').val($('#txtTotalPCA').val());
            });
            $("#PCAStopDTPicker").on("dp.change", function (e) {
                if (!e.date) $('#PCAEnd').val(null);
                else $('#PCAEnd').val(GetStringFormatByDate(new Date(e.date)));
                $('#PCAStartDTPicker').data("DateTimePicker").maxDate(e.date);
                //diff total time
                DiffStartStopDate($('#PCAStartDTPicker').data("DateTimePicker").date(), e.date, 'txtTotalPCA');
                $('#PCATotalMin').val($('#txtTotalPCA').val());
            });

            //GPU
            InitialDateTimePicker("GPUStartDTPicker", GetDateFromServerDate('@Model.GPUStart'));
            InitialDateTimePicker("GPUStopDTPicker", GetDateFromServerDate('@Model.GPUEnd'));
            $("#GPUStartDTPicker").on("dp.change", function (e) {
                if (!e.date) $('#GPUStart').val(null);
                else $('#GPUStart').val(GetStringFormatByDate(new Date(e.date)));
                $('#GPUStopDTPicker').data("DateTimePicker").minDate(e.date);
                //diff total time
                DiffStartStopDate(e.date, $('#GPUStopDTPicker').data("DateTimePicker").date(), 'txtTotalGPU');
                $('#GPUTotalMin').val($('#txtTotalGPU').val());
            });
            $("#GPUStopDTPicker").on("dp.change", function (e) {
                if (!e.date) $('#GPUEnd').val(null);
                else $('#GPUEnd').val(GetStringFormatByDate(new Date(e.date)));
                $('#GPUStartDTPicker').data("DateTimePicker").maxDate(e.date);
                //diff total time
                DiffStartStopDate($('#GPUStartDTPicker').data("DateTimePicker").date(), e.date, 'txtTotalGPU');
                $('#GPUTotalMin').val($('#txtTotalGPU').val());
            });


        });

    </script>

    <style type="text/css">
        .border {
            padding: 20px;
            border: 1px solid #cccccc;
            border-radius: 6px;
        }

        .row {
            margin-top: 10px;
        }
    </style>

End Section

@Using Html.BeginForm("EditSO", "ServiceOrder", FormMethod.Post, New With {.id = "formEditSO"})

    @<div Class="row">
        <div Class="col-md-12 text-center">
            <h2>แก้ไข PCA/GPU SERVICE ORDER</h2>
            @Html.ValidationSummary(True)
        </div>
    </div>

    @Html.HiddenFor(Function(model) model.id)
    @Html.HiddenFor(Function(model) model.WONumber)
    @Html.HiddenFor(Function(model) model.Valid)
    @Html.HiddenFor(Function(model) model.Printed)
    @Html.HiddenFor(Function(model) model.CreateBy)
    @Html.HiddenFor(Function(model) model.CustIDStart)
    @Html.HiddenFor(Function(model) model.CustSignStart)
    @Html.HiddenFor(Function(model) model.CustIDStop)
    @Html.HiddenFor(Function(model) model.CustSignStop)
    @Html.HiddenFor(Function(model) model.CondOfCharge)
    @Html.HiddenFor(Function(model) model.Logo)
    @Html.HiddenFor(Function(model) model.UpdateBy)
    @Html.HiddenFor(Function(model) model.IsActive)
    @Html.HiddenFor(Function(model) model.CreateDate)

    @<div Class="row">

        <div Class="col-md-offset-2 col-md-8 border">

            <div class="form-group">
                <label>Service-Rate</label>
                <input type="text" class="form-control" value="@Model.ServiceRate" disabled />
            </div>

            <div class="form-group">
                <label>Station</label>
                @Html.TextBoxFor(Function(model) model.Station, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Station)
            </div>

            <div class="form-group">
                <label>Airline</label>
                @Html.TextBoxFor(Function(model) model.AircraftCarrier, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.AircraftCarrier)
            </div>

            <div class="form-group">
                <label>Flight No.</label>
                @Html.TextBoxFor(Function(model) model.FlightNo, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.FlightNo)
            </div>

            <div class="form-group">
                <label>Aircraft Type</label>
                @Html.TextBoxFor(Function(model) model.AircraftType, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.AircraftType)
            </div>

            <div class="form-group">
                <label>Aircraft Reg</label>
                @Html.TextBoxFor(Function(model) model.AircraftReg, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.AircraftReg)
            </div>

            <div class="form-group">
                <label>STA</label>
                <div class="input-group date" id="STADTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("ETA")
            </div>

            <div class="form-group">
                <label>STD</label>
                <div class="input-group date" id="ETDDTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("ETD")
            </div>

            <div class="form-group">
                <label>Gate No.</label>
                @Html.TextBoxFor(Function(model) model.GateNo, New With {.class = "form-control"})
            </div>

        </div>

    </div>

    @<div Class="row">

        <div Class="col-md-offset-2 col-md-8 border">

            <div Class="form-group">
                <Label>PCA&nbsp;&nbsp;</Label>
                @Html.CheckBoxFor(Function(model) model.PCA1)
                @Html.LabelFor(Function(model) model.PCA1) &nbsp;&nbsp;
                @Html.CheckBoxFor(Function(model) model.PCA2)
                @Html.LabelFor(Function(model) model.PCA2)
            </div>

            <div Class="form-group">
                <Label> Start</Label>
                <div class="input-group date" id="PCAStartDTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("PCAStart")
            </div>

            <div Class="form-group">
                <Label>Stop</Label>
                <div class="input-group date" id="PCAStopDTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("PCAEnd")
            </div>

            <div Class="form-group">
                <Label> TotalTime(Minute)</Label>
                <input type="hidden" id="PCATotalMin" name="PCATotalMin" value="@Model.PCATotalMin" />
                <input type="text" id="txtTotalPCA" Class="form-control" disabled />
            </div>

            <div Class="form-group">
                <Label> GPU&nbsp;&nbsp;</Label>
                @Html.CheckBoxFor(Function(model) model.GPU1)
                @Html.LabelFor(Function(model) model.GPU1)&nbsp;&nbsp;
                @Html.CheckBoxFor(Function(model) model.GPU2)
                @Html.LabelFor(Function(model) model.GPU2)
            </div>

            <div Class="form-group">
                <Label> Start</Label>
                <div class="input-group date" id="GPUStartDTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("GPUStart")
            </div>

            <div Class="form-group">
                <Label>Stop</Label>
                <div class="input-group date" id="GPUStopDTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("GPUEnd")
            </div>

            <div Class="form-group">
                <Label> TotalTime(Minute)</Label>
                <input type="hidden" id="GPUTotalMin" name="GPUTotalMin" value="@Model.GPUTotalMin" />
                <input type="text" id="txtTotalGPU" Class="form-control" disabled />
            </div>

        </div>

    </div>

    @<div Class="row">
        <div Class="col-md-offset-2 col-md-8 border">
            <div class="form-group">
                <label>Remark</label>
                @Html.TextBoxFor(Function(model) model.Remark, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Remark)
            </div>
        </div>
    </div>

    @<div Class="row">
        <div Class="col-md-offset-2 col-md-8 ">
            <input type="button" id="btnEdit" Class="btn btn-block btn-primary btn-lg" value="ตกลง" />
        </div>
    </div>

End Using
