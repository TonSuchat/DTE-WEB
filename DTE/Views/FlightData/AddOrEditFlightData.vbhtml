@ModelType FlightDataViewModel

@Code
    Dim type As String = ViewBag.Type.ToString()
    Dim action = If(type = "Add", "AddFlightData", "EditFlightData")
    ViewData("Title") = If(type = "Add", "เพิ่มข้อมูล-FlightData", "แก้ไขข้อมูล-FlightData")
End Code

@section scripts

    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#SelectedDateTxt').datetimepicker({
                format: 'DD/MM/YYYY',
                date: ('@type' == 'Add') ? new Date() : new Date(@Model.STA.Year, @Model.STA.Month - 1, @Model.STA.Day)
            });

            $('#STATimeTxt').datetimepicker({
                format: 'HH:mm',
                date: '@Model.STA' == null ? new Date() : new Date(@Model.STA.Year, @Model.STA.Month - 1, @Model.STA.Day , @Model.STA.Hour, @Model.STA.Minute)
            });

            $('#btnOK').click(function(){
                //check validate
                if(CheckValidate()){
                    $(this).parent('form').submit();
                }
            })

            function CheckValidate(){
                if(!$('#SelectedDate').val() || $('#SelectedDate').val().length <= 0){
                    alert('ต้องเลือกวันที่');
                    return false;
                }
                if((!$('#STATime').val() || $('#STATime').val().length <= 0)){
                    alert('ต้องตั้งค่าเวลาของ STA/STD');
                    return false;
                }

                return true;
            }

        })

    </script>

    @If IsNothing(Model.STD) OrElse Not Model.STD.HasValue Then
        @<script type="text/javascript">
            $(function(){$('#STDTimeTxt').datetimepicker({format: 'HH:mm'});})
        </script>
    Else
        @<script type="text/javascript">
            $(function(){
                $('#STDTimeTxt').datetimepicker({
                    format: 'HH:mm',
                    date : '@Model.STD' == null ? new Date() : new Date(@CDate(Model.STD).Year, @CDate(Model.STD).Month - 1, @CDate(Model.STD).Day , @CDate(Model.STD).Hour, @CDate(Model.STD).Minute)
                });
            })
        </script>
    End If


End Section

<div class="row">

    @If type = "Add" Then
        @<h2>เพิ่มข้อมูล-FlightData</h2>
    Else
        @<h2>แก้ไขข้อมูล-FlightData</h2>
    End If
    

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
