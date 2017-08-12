@ModelType DTE.Entities.ServiceOrder.InputSPInsertSO

@Code
    ViewData("Title") = "CreateServiceOrder"
    Dim insertResult = If(IsNothing(ViewData("result")), Nothing, DirectCast(ViewData("result"), Entities.ServiceOrder.OutputSPInsertSO))
    Dim success As Integer = If(IsNothing(insertResult), 99, insertResult.Success)
End Code

@section scripts

    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script src="~/Scripts/bootbox.min.js"></script>
    <script src="~/Scripts/helpers.js"></script>
    <script type="text/javascript">

        $(function () {
 
            if(@success != null && @success == 0) bootbox.alert("บันทึกข้อมูลแล้ว");

            $('#STADTPicker').datetimepicker({format : 'D/MM/YYYY HH:mm:ss'});
            $('#STADTPicker').on('dp.change', function (e) {
                $('#ETA').val(GetStringFormatByDate(new Date(e.date)));
            })
            $('#ETDDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#ETDDTPicker').on('dp.change', function (e) {
                $('#ETD').val(GetStringFormatByDate(new Date(e.date)));
            })

            //PCA
            $('#PCAStartDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#PCAStopDTPicker').datetimepicker({ useCurrent: false, format: 'D/MM/YYYY HH:mm:ss' });
            $("#PCAStartDTPicker").on("dp.change", function (e) {
                $('#PCAStart').val(GetStringFormatByDate(new Date(e.date)));
                $('#PCAStopDTPicker').data("DateTimePicker").minDate(e.date);
                //diff total time
                DiffStartStopDate(e.date, $('#PCAStopDTPicker').data("DateTimePicker").date(), 'txtTotalPCA');
            });
            $("#PCAStopDTPicker").on("dp.change", function (e) {
                $('#PCAEnd').val(GetStringFormatByDate(new Date(e.date)));
                $('#PCAStartDTPicker').data("DateTimePicker").maxDate(e.date);
                //diff total time
                DiffStartStopDate($('#PCAStartDTPicker').data("DateTimePicker").date(), e.date, 'txtTotalPCA');
            });

            //GPU
            $('#GPUStartDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#GPUStopDTPicker').datetimepicker({ useCurrent: false, format: 'D/MM/YYYY HH:mm:ss' });
            $("#GPUStartDTPicker").on("dp.change", function (e) {
                $('#GPUStart').val(GetStringFormatByDate(new Date(e.date)));
                $('#GPUStopDTPicker').data("DateTimePicker").minDate(e.date);
                //diff total time
                DiffStartStopDate(e.date, $('#GPUStopDTPicker').data("DateTimePicker").date(), 'txtTotalGPU');
            });
            $("#GPUStopDTPicker").on("dp.change", function (e) {
                $('#GPUEnd').val(GetStringFormatByDate(new Date(e.date)));
                $('#GPUStartDTPicker').data("DateTimePicker").maxDate(e.date);
                //diff total time
                DiffStartStopDate($('#GPUStartDTPicker').data("DateTimePicker").date(), e.date, 'txtTotalGPU');
            });

            function DiffStartStopDate(startDate, stopDate, elemId) {
                if (startDate == null || stopDate == null || elemId == null) return;

                startDate = new Date(startDate);
                stopDate = new Date(stopDate);

                var diff = (stopDate - startDate);
                var diffMins = Math.round(diff / 60000);
                $('#' + elemId).val(diffMins);
            }

            $('#btnCreate').click(function(){
                bootbox.confirm("ยืนยันสร้าง Service-Order?",function(result){
                    if(result) $('form').submit();
                });
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

@Using Html.BeginForm("CreateServiceOrder", "ServiceOrder", FormMethod.Post)

    @<div Class="row">
        <div Class="col-md-12 text-center">
            <h2> PCA/GPU SERVICE ORDER</h2>
        </div>
    </div>

    @If Not IsNothing(insertResult) Then
        @<div class="row">
            <div class="col-md-offset-2 col-md-8">
                @If insertResult.Success = 0 Then
                    @<div class="alert alert-success" role="alert">@insertResult.RetMsg</div>
                Else
                    @<div class="alert alert-danger" role="alert">@insertResult.RetMsg</div>
                End If
            </div>
        </div>
    End If

    @<div Class="row">

        <div Class="col-md-offset-2 col-md-8 border">

            <div Class="form-group">
                <Label>Date</Label>
                <input type="text" Class="form-control" value="@Model.DateNow" disabled />
            </div>

            <div class="form-group">
                <label>Station</label>
                @Html.TextBoxFor(Function(model) model.Station, New With {.class = "form-control", .Value = "HKT"})
                @Html.ValidationMessageFor(Function(model) model.Station)
            </div>

            <div class="form-group">
                <label>Air Carrier</label>
                @Html.TextBoxFor(Function(model) model.AircraftCarrier, New With {.class = "form-control", .Value = "ACR"})
                @Html.ValidationMessageFor(Function(model) model.AircraftCarrier)
            </div>

            <div class="form-group">
                <label>Flight No.</label>
                @Html.TextBoxFor(Function(model) model.FlightNo, New With {.class = "form-control", .Value = "TG123"})
                @Html.ValidationMessageFor(Function(model) model.FlightNo)
            </div>

            <div class="form-group">
                <label>Aircraft Type</label>
                @Html.TextBoxFor(Function(model) model.AircraftType, New With {.class = "form-control", .Value = "A380"})
                @Html.ValidationMessageFor(Function(model) model.AircraftType)
            </div>

            <div class="form-group">
                <label>Aircraft Reg</label>
                @Html.TextBoxFor(Function(model) model.AircraftReg, New With {.class = "form-control", .Value = "HSAAB"})
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
                @Html.TextBoxFor(Function(model) model.GateNo, New With {.class = "form-control", .Value = "A1"})
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
            </div>

        </div>

    </div>

    @<div Class="row">
        <div Class="col-md-offset-2 col-md-8 ">
            <input type="button" id="btnCreate" Class="btn btn-block btn-primary btn-lg" value="ตกลง" />
        </div>
    </div>

End Using
