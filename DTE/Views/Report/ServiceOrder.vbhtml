@ModelType List(Of ReportViewModels.ServiceOrder)

@Code
    ViewData("Title") = "Report"
End Code

@section Scripts

    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script src="~/Scripts/helpers.js"></script>
    <script type="text/javascript">

        $(function () {

            $('#StartDTPicker').datetimepicker({ format: 'D/MM/YYYY HH:mm:ss' });
            $('#EndDTPicker').datetimepicker({ useCurrent: false, format: 'D/MM/YYYY HH:mm:ss' });
            $("#StartDTPicker").on("dp.change", function (e) {
                $('#startDate').val(GetStringFormatByDate(new Date(e.date)));
                $('#EndDTPicker').data("DateTimePicker").minDate(e.date);
            });
            $("#EndDTPicker").on("dp.change", function (e) {
                $('#endDate').val(GetStringFormatByDate(new Date(e.date)));
                $('#StartDTPicker').data("DateTimePicker").maxDate(e.date);
            });

            $('#btnSearch').click(function () {
                if (CheckValidate()) $('form').submit();
                else alert('ต้องเลือกช่วงวันที่');
            });

            function CheckValidate() {
                var startDate = $('#startDate').val();
                var endDate = $('#endDate').val();
                if (startDate == null || !startDate) return false;
                if (endDate == null || !endDate) return false;
                return true;
            }

        });

    </script>

    <style type="text/css">
        .row {
            margin-top: 10px;
        }
        .table{
            max-width: none;
            table-layout: fixed;
            word-wrap: break-word;
        }
    </style>

End Section


@Using Html.BeginForm("ServiceOrder", "Report", FormMethod.Post)

    @<div Class="row">
        <div Class="form-group">
            <Label> StartDate</Label>
            <div Class="input-group date" id="StartDTPicker">
                <input type="text" Class="form-control" />
                <span Class="input-group-addon">
                    <span Class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
            @Html.Hidden("startDate")
        </div>
        <div Class="form-group">
            <Label> EndDate</Label>
            <div Class="input-group date" id="EndDTPicker">
                <input type="text" Class="form-control" />
                <span Class="input-group-addon">
                    <span Class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
            @Html.Hidden("endDate")
        </div>

        <button type="button" id="btnSearch" class="btn btn-default">ค้นหาข้อมูล</button>
    </div>


End Using

<div class="row">
    @If IsNothing(Model) OrElse Model.Count = 0 Then
        @<div class="jumbotron">
            <h1>ไม่พบข้อมูล</h1>
        </div>
    Else
        @<table class="table table-bordered table-striped">
            <tr>
                <th class="text-center">หมายเลข</th>
                <th class="text-center">Station</th>
                <th class="text-center">Air Carrier</th>
                <th class="text-center">Flight No</th>
                <th class="text-center">Aircraft Type</th>
                <th class="text-center">Aircraft Reg</th>
                <th class="text-center">STA</th>
                <th class="text-center">STD</th>
                <th class="text-center">Gate No.</th>
                <th class="text-center">PCA 1 House</th>
                <th class="text-center">PCA 2 House</th>
                <th class="text-center">PCA-Start</th>
                <th class="text-center">PCA-Stop</th>
                <th class="text-center">PCA-TotalMinute</th>
                <th class="text-center">GPU 1 Plug</th>
                <th class="text-center">GPU 2 Plug</th>
                <th class="text-center">GPU-Start</th>
                <th class="text-center">GPU-Stop</th>
                <th class="text-center">GPU-TotalMinute</th>
            </tr>
            @For Each item In Model
                @<tr>
                    <td class="text-center">@item.WONumber</td>
                    <td class="text-center">@item.Station</td>
                    <td class="text-center">@item.AircraftCarrier</td>
                    <td class="text-center">@item.FlightNo</td>
                    <td class="text-center">@item.AircraftType</td>
                    <td class="text-center">@item.AircraftReg</td>
                    <td class="text-center">@item.ETADate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                    <td class="text-center">@item.ETDDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                    <td class="text-center">@item.GateNo</td>
                    <td class="text-center">@item.PCA1</td>
                    <td class="text-center">@item.PCA2</td>
                    <td class="text-center">@item.PCAStartDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                    <td class="text-center">@item.PCAEndDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                    <td class="text-center">@item.PCATotalMin</td>
                    <td class="text-center">@item.GPU1</td>
                    <td class="text-center">@item.GPU2</td>
                    <td class="text-center">@item.GPUStartDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                    <td class="text-center">@item.GPUEndDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                    <td class="text-center">@item.GPUTotalMin</td>
                </tr>
            Next
        </table>
    End If
</div>
