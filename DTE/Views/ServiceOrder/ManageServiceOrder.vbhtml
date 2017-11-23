@ModelType  ManageServiceOrderViewModel

@Code
    ViewData("Title") = "จัดการข้อมูล-S/O"
End Code

@section scripts

    <link href="~/Content/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/dataTables.bootstrap.min.js"></script>
    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#tblSO').DataTable({ "bSort": false });

            $('.btnremove').click(function () {
                if (confirm('ต้องการลบข้อมูลนี้?')) {
                    $(this).parent('form').submit();
                }
            })

            //initial date-picker
            $('#SelectedStartDateTxt').datetimepicker({
                format: 'DD/MM/YYYY',
                date: new Date(@Model.SelectedStartDate.Year,@Model.SelectedStartDate.Month - 1,@Model.SelectedStartDate.Day)
            });
            $('#SelectedEndDateTxt').datetimepicker({ format: 'DD/MM/YYYY', date: new Date(@Model.SelectedEndDate.Year,@Model.SelectedEndDate.Month - 1,@Model.SelectedEndDate.Day) });
            $('#SelectedEndDateTxt').data("DateTimePicker").minDate(new Date(@Model.SelectedEndDate.Year,@Model.SelectedEndDate.Month - 1,@Model.SelectedEndDate.Day));

            $("#SelectedStartDateTxt").on("dp.change", function (e) {
                $('#SelectedEndDateTxt').data("DateTimePicker").minDate(e.date);
            });
            //initial date-picker


            $('#ExcelSelectedStartDate').val($('#SelectedStartDate').val());
            $('#ExcelSelectedEndDate').val($('#SelectedEndDate').val());

        })

    </script>

End Section

<div class="row">

    <div class="row">
        <h2>จัดการข้อมูล-S/O</h2>
        @If Helpers.GetCurrentUser.Type = 1 OrElse Helpers.GetCurrentUser.Type = 2 Then
            @<a Class="btn btn-lg btn-success" href="@Url.Action("AddServiceOrder", "ServiceOrder")">เพิ่มข้อมูล S/O +</a>
        End If
        <br />
        <hr />
        @Using Html.BeginForm("ManageServiceOrder", "ServiceOrder", FormMethod.Post)
        @<div Class="form-inline">
            <div Class="form-group">
                <Label> วันที่เริ่มต้น</Label>
                <div Class='input-group date' id='SelectedStartDateTxt'>
                    <input type='text' class="form-control" id="SelectedStartDate" name="SelectedStartDate" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-time"></span>
                    </span>
                </div>
            </div>
            <div class="form-group" style="margin-left:10px;">
                <Label> วันที่สิ้นสุด</Label>
                <div Class='input-group date' id='SelectedEndDateTxt'>
                    <input type='text' class="form-control" id="SelectedEndDate" name="SelectedEndDate" />
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-time"></span>
                    </span>
                </div>
            </div>
            <Button type="submit" style="vertical-align:bottom;" Class="btn btn-default btn-warning">ค้นหา</Button>
        </div>
        End Using
    </div>

    @If IsNothing(Model.TransactionsDetail) OrElse Model.TransactionsDetail.Count = 0 Then
    @<div class="row">
        @Html.Partial("NotFoundData")
    </div>
    Else

    @<div Class="row">
        @using Html.BeginForm("ExportExcel", "ServiceOrder", FormMethod.Post)
            @<button type="submit" class="btn btn-lg btn-success">Export to Excel</button>
            @<input type="hidden" name="ExcelSelectedStartDate" id="ExcelSelectedStartDate" />
            @<input type="hidden" name="ExcelSelectedEndDate" id="ExcelSelectedEndDate" />
        End Using
        @*<a Class="btn btn-lg btn-success" href="@Url.Action("ExportExcel", "ServiceOrder")">Export to Excel</a>*@
    </div>

    @<div class="row">
        <table id="tblSO" class="table table-bordered table-striped">
            <thead>
                <tr>
                    <th class="text-center">S/O Number</th>
                    <th class="text-center">Station</th>
                    <th class="text-center">Flight No.</th>
                    <th class="text-center">Service-Rate</th>
                    <th class="text-center">แก้ไขโดย</th>
                    <th class="text-center">สร้างรายการโดย</th>
                    <th class="text-center">วันที่แก้ไข</th>
                    <th class="text-center">วันที่สร้างรายการ</th>
                    @*<th class="text-center">แก้ไข</th>*@
                    @If Helpers.GetCurrentUser.Type = 1 OrElse Helpers.GetCurrentUser.Type = 2 Then
                        @<th Class="text-center">ลบ</th>
                    End If
                </tr>
            </thead>
            <tbody>
                @For Each item In Model.TransactionsDetail
                    @<tr>
                        <td class="text-center"><a target="_blank" href="@Url.Action("Detail", "ServiceOrder", New With {.id = item.id})">@item.WONumber</a></td>
                        <td class="text-center">@item.Station</td>
                        <td class="text-center">@item.FlightNo</td>
                        <td class="text-center">@item.ServiceRate</td>
                        <td class="text-center">@item.UpdatedByName</td>
                        <td class="text-center">@item.CreatedByName</td>
                        <td class="text-center">@item.UpdateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                        <td class="text-center">@item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                        @*<td class="text-center">
                            <a href="@Url.Action("EditSO", "ServiceOrder", New With {.id = item.id})" class="btn btn-warning btn-sm">
                                <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                            </a>
                        </td>*@
                        @If Helpers.GetCurrentUser.Type = 1 OrElse Helpers.GetCurrentUser.Type = 2 Then
                            @<td Class="text-center">
                                @Using Html.BeginForm("RemoveSO", "ServiceOrder", FormMethod.Post, New With {.role = "form"})
                                    @<input type="hidden" value="@item.id" name="id" />
                                    @<input type="hidden" value="@Model.SelectedStartDate" name="removeSelectedStartDate" />
                                    @<input type="hidden" value="@Model.SelectedEndDate" name="removeSelectedEndDate" />
                                    @<button type="button" class="btn btn-sm btn-danger btnremove">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                    </button>
                                End Using
                            </td>
                        End if  
                    </tr>
                Next
            </tbody>
        </table>
    </div>
    End If
</div>


