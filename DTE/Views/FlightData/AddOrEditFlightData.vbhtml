@ModelType FlightDataViewModel

@Code
    ViewData("Title") = "แก้ไขข้อมูล-FlightData"
    Dim type As String = ViewBag.Type.ToString()
    Dim action = If(type = "Add", "AddFlightData", "EditFlightData")
End Code

@section scripts

    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">

        $(function () {
            console.log('@type');
            $('#SelectedDateTxt').datetimepicker({
                format: 'DD/MM/YYYY',
                date: ('@type' == 'Add') ? new Date() : new Date(@Model.STA.Year, @Model.STA.Month - 1, @Model.STA.Day)
            });

            $('#STATimeTxt').datetimepicker({
                format: 'HH:mm',
                date: '@Model.STA' == null ? new Date() : new Date(@Model.STA.Year, @Model.STA.Month - 1, @Model.STA.Day , @Model.STA.Hour, @Model.STA.Minute)
            });

            $('#STDTimeTxt').datetimepicker({
                format: 'HH:mm',
                date: '@Model.STD' == null ? new Date() : new Date(@Model.STD.Year, @Model.STD.Month - 1, @Model.STD.Day , @Model.STD.Hour, @Model.STD.Minute)
            });

            $('#btnOK').click(function(){
                //check validate
                if(CheckValidate()){
                    console.log($('#SelectedDate').val());
                    console.log($('#STDTime').val());
                    console.log($('#STATime').val());
                    $(this).parent('form').submit();
                    console.log('submit');
                }
            })

            function CheckValidate(){
                if(!$('#SelectedDate').val() || $('#SelectedDate').val().length <= 0){
                    alert('ต้องเลือกวันที่');
                    return false;
                }
                if((!$('#STATime').val() || $('#STATime').val().length <= 0) || (!$('#STDTime').val() || $('#STDTime').val().length <= 0)){
                    alert('ต้องตั้งค่าเวลาของ STA/STD');
                    return false;
                }

                return true;
            }

        })

    </script>

End Section

<div class="row">

    <h2>แก้ไขข้อมูล-FlightData</h2>

    <a class="btn btn-primary" href="@Url.Action("ManageFlightData", "FlightData")">ย้อนกลับ</a>

    @Using Html.BeginForm(action, "FlightData", FormMethod.Post)

        @<br />

        @Html.HiddenFor(Function(f) f.CreateDate)

        @<div class="form-group">
             <label>วันที่</label>
             <div class='input-group date' id='SelectedDateTxt'>
                 <input type='text' class="form-control" id="SelectedDate" name="SelectedDate" />
                 <span class="input-group-addon">
                     <span class="glyphicon glyphicon-time"></span>
                 </span>
             </div>
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.FlightNo)
            @Html.TextBoxFor(Function(f) f.FlightNo, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.FlightNo)
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.ACType)
            @Html.TextBoxFor(Function(f) f.ACType, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.ACType)
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.ACCarrier)
            @Html.TextBoxFor(Function(f) f.ACCarrier, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.ACCarrier)
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.ACReg)
            @Html.TextBoxFor(Function(f) f.ACReg, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.ACReg)
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.STA)
            <div class='input-group date' id='STATimeTxt'>
                 <input type='text' class="form-control" id="STATime" name="STATime" />
                 <span class="input-group-addon"> 
                     <span class="glyphicon glyphicon-time"></span>
                 </span>
            </div>
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.STD)
            <div class='input-group date' id='STDTimeTxt'>
                 <input type='text' class="form-control" id="STDTime" name="STDTime" />
                 <span class="input-group-addon">
                     <span class="glyphicon glyphicon-time"></span>
                 </span>
            </div>
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(f) f.GateNo)
            @Html.TextBoxFor(Function(f) f.GateNo, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(f) f.GateNo)
        </div>

        @<button type="button" id="btnOK" class="btn btn-default btn-primary">ตกลง</button>

    End Using


</div>
