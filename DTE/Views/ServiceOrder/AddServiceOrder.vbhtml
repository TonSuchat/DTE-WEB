@ModelType Entities.Transaction

@Code
    ViewData("Title") = "เพิ่มข้อมูล-SO"
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

            $('#btnCreate').click(function () {
                $('#formAddSO').submit();
            });

            //datepicker
            $('#STADTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#STADTPicker').on('dp.change', function (e) {
                $('#ETA').val(GetStringFormatByDate(new Date(e.date)));
            })
            $('#ETDDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#ETDDTPicker').on('dp.change', function (e) {
                $('#ETD').val(GetStringFormatByDate(new Date(e.date)));
            })

            //PCA
            $('#PCAStartDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#PCAStopDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $("#PCAStartDTPicker").on("dp.change", function (e) {
                $('#PCAStart').val(GetStringFormatByDate(new Date(e.date)));
                $('#PCAStopDTPicker').data("DateTimePicker").minDate(e.date);
                //diff total time
                DiffStartStopDate(e.date, $('#PCAStopDTPicker').data("DateTimePicker").date(), 'txtTotalPCA');
                $('#PCATotalMin').val($('#txtTotalPCA').val());
            });
            $("#PCAStopDTPicker").on("dp.change", function (e) {
                $('#PCAEnd').val(GetStringFormatByDate(new Date(e.date)));
                $('#PCAStartDTPicker').data("DateTimePicker").maxDate(e.date);
                //diff total time
                DiffStartStopDate($('#PCAStartDTPicker').data("DateTimePicker").date(), e.date, 'txtTotalPCA');
                $('#PCATotalMin').val($('#txtTotalPCA').val());
            });

            //GPU
            $('#GPUStartDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#GPUStopDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $("#GPUStartDTPicker").on("dp.change", function (e) {
                $('#GPUStart').val(GetStringFormatByDate(new Date(e.date)));
                $('#GPUStopDTPicker').data("DateTimePicker").minDate(e.date);
                //diff total time
                DiffStartStopDate(e.date, $('#GPUStopDTPicker').data("DateTimePicker").date(), 'txtTotalGPU');
                $('#GPUTotalMin').val($('#txtTotalGPU').val());
            });
            $("#GPUStopDTPicker").on("dp.change", function (e) {
                $('#GPUEnd').val(GetStringFormatByDate(new Date(e.date)));
                $('#GPUStartDTPicker').data("DateTimePicker").maxDate(e.date);
                //diff total time
                DiffStartStopDate($('#GPUStartDTPicker').data("DateTimePicker").date(), e.date, 'txtTotalGPU');
                $('#GPUTotalMin').val($('#txtTotalGPU').val());
            });

            //preview image
            $("#uploadImg").change(function () {
                readURL(this);
            });

            function readURL(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('#imgPreview').attr('src', e.target.result);
                        $('#hdUploadImage').val(e.target.result);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            }

            function DiffStartStopDate(startDate, stopDate, elemId) {
                if (startDate == null || stopDate == null || elemId == null) return;

                startDate = new Date(startDate);
                stopDate = new Date(stopDate);

                var diff = (stopDate - startDate);
                var diffMins = Math.round(diff / 60000);
                $('#' + elemId).val(diffMins);
            }

        });

    </script>

End Section

@Using Html.BeginForm("AddServiceOrder", "ServiceOrder", FormMethod.Post, New With {.id = "formAddSO"})

    @<div Class="row">
        <div Class="col-md-12 text-center">
            <h2> PCA/GPU SERVICE ORDER</h2>
            @Html.ValidationSummary(True)
        </div>
    </div>

    @<div Class="row">

        <div Class="col-md-offset-2 col-md-8 border">

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
                <label>Aircraft STA</label>
                <div class="input-group date" id="STADTPicker">
                    <input type="text" class="form-control" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
                @Html.Hidden("ETA")
            </div>

            <div class="form-group">
                <label>Aircraft STD</label>
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
                <input type="text" id="txtTotalPCA" Class="form-control" disabled />
                <input type="hidden" id="PCATotalMin" name="PCATotalMin" value="0" />
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
                <input type="text" id="txtTotalGPU" Class="form-control" disabled />
                <input type="hidden" id="GPUTotalMin" name="GPUTotalMin" value="0" />
            </div>

        </div>

    </div>

    @<div Class="row">
        <div Class="col-md-offset-2 col-md-8 border">
            <div class="form-group">
                <label>StartSignature By</label>
                @Html.TextBoxFor(Function(model) model.CustIDStart, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CustIDStart)
            </div>
            <div class="form-group">
                <label>StopSignature By</label>
                @Html.TextBoxFor(Function(model) model.CustIDStop, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CustIDStop)
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
        <div Class="col-md-offset-2 col-md-8 border">
            <input type='file' id="uploadImg" accept=".jpg" />
            <br />
            <img id="imgPreview" src="#" alt="your image" width="250" height="250" />
            <input type="hidden" id="hdUploadImage" name="hdUploadImage" value="" />
        </div>
    </div>

    @<div Class="row">
        <div Class="col-md-offset-2 col-md-8 ">
            <input type="button" id="btnCreate" Class="btn btn-block btn-primary btn-lg" value="ตกลง" />
        </div>
    </div>

End Using
