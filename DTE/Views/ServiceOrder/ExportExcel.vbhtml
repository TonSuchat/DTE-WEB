@ModelType ExportExcelViewModel

@Code
    ViewData("Title") = "Export-ข้อมูล S/O"
End Code

@section scripts
    <link href="~/Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <script src="~/Scripts/moment.min.js"></script>
    <script src="~/Scripts/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#SelectedDateTxt').datetimepicker({
                format: 'DD/MM/YYYY',
                date: new Date()
            });

            $('#btnExport').click(function () {
                $('#frmExport').submit();
            });
        });

    </script>
End Section

@Using Html.BeginForm("ExportExcel", "ServiceOrder", FormMethod.Post, New With {.id = "frmExport"})
    @<div Class="row">
        <h2> Export-ข้อมูล S/O</h2>

        <a Class="btn btn-primary" href="@Url.Action("ManageServiceOrder", "ServiceOrder")">ย้อนกลับ</a>
        
        <br />
        <br />

        @Html.ValidationSummary(True)

        <div class="form-group">
            <label>วันที่สร้างรายการ S/O</label>
            <div class='input-group date' id='SelectedDateTxt'>
                <input type='text' class="form-control" id="SelectedDate" name="SelectedDate" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-time"></span>
                </span>
            </div>
        </div>

        <button type="button" id="btnExport" class="btn btn-default btn-warning">Export-ข้อมูล</button>

    </div>
End Using

