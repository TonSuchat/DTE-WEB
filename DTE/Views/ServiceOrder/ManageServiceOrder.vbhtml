﻿@ModelType  ManageServiceOrderViewModel

@Code
    ViewData("Title") = "จัดการข้อมูล-SO"
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

            $('#SelectedDateTxt').datetimepicker({
                format: 'DD/MM/YYYY',
                date: new Date(@Model.SelectedDate.Year,@Model.SelectedDate.Month - 1,@Model.SelectedDate.Day)
            });

            //$('#SelectedDateTxt').on('dp.change',function(e){
            //    $('#ExcelSelectedDate').val(e.date);
            //});

            $('#ExcelSelectedDate').val($('#SelectedDate').val());
            //$('#removeSelectedDate').val($('#SelectedDate').val());
        })

    </script>

End Section

<div class="row">

    <div class="row">
        <h2>จัดการข้อมูล-SO</h2>
        <a class="btn btn-lg btn-success" href="@Url.Action("AddServiceOrder", "ServiceOrder")">เพิ่มข้อมูล SO +</a>
        <br />
        <hr />
        @Using Html.BeginForm("ManageServiceOrder", "ServiceOrder", FormMethod.Post)
        @<div Class="form-inline">
            <div Class="form-group">
                <Label> วันที่</Label>
                <div Class='input-group date' id='SelectedDateTxt'>
                    <input type='text' class="form-control" id="SelectedDate" name="SelectedDate" />
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
            @<input type="hidden" name="ExcelSelectedDate" id="ExcelSelectedDate" />
        End Using
        @*<a Class="btn btn-lg btn-success" href="@Url.Action("ExportExcel", "ServiceOrder")">Export to Excel</a>*@
    </div>

    @<div class="row">
        <table id="tblSO" class="table table-bordered table-striped">
            <thead>
                <tr>
                    <th class="text-center">WONumber</th>
                    <th class="text-center">Station</th>
                    <th class="text-center">Flight No.</th>
                    <th class="text-center">Service-Rate</th>
                    <th class="text-center">UpdateBy</th>
                    <th class="text-center">CreateBy</th>
                    <th class="text-center">UpdateDate</th>
                    <th class="text-center">CreateDate</th>
                    @*<th class="text-center">แก้ไข</th>*@
                    <th class="text-center">ลบ</th>
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
                        <td class="text-center">
                            @using Html.BeginForm("RemoveSO", "ServiceOrder", FormMethod.Post, New With {.role = "form"})
                            @<input type="hidden" value="@item.id" name="id" />
                            @<input type="hidden" value="@Model.SelectedDate" name="removeSelectedDate" />
                            @<button type="button" class="btn btn-sm btn-danger btnremove">
                                <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                            </button>
                            End Using
                        </td>
                    </tr>
                Next
            </tbody>
        </table>
    </div>
    End If
</div>


