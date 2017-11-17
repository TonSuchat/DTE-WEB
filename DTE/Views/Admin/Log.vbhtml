@ModelType List(Of Entities.VW_Log)

@Code
    ViewData("Title") = "Log"
End Code

@section scripts
    <link href="~/Content/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#tblLog').DataTable({ "bSort": false });
        })

    </script>
End Section

<div class="row">
    <h2>Log</h2>

    @If IsNothing(Model) OrElse Model.Count = 0 Then
    @Html.Partial("NotFoundData")
    Else
    @<table id="tblLog" class="table table-bordered table-striped">
        <thead>
            <tr>
                <th class="text-center">ประเภท</th>
                <th class="text-center">Id อ้างอิง</th>
                <th class="text-center">Model</th>
                <th class="text-center">ชื่อผู้ใช้งาน</th>
                <th class="text-center">หมายเหตุ</th>
                <th class="text-center">วันที่สร้างรายการ</th>
            </tr>
        </thead>
        <tbody>
            @for Each item In Model
                @<tr>
                    <td class="text-center">@item.logdescription</td>
                    <td class="text-center">@item.ReferenceId</td>
                    <td class="text-center">@item.Model</td>
                    <td class="text-center">@item.UserName</td>
                    <td>@item.Remark</td>
                    <td class="text-center">@item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                </tr>
            Next
        </tbody>
    </table>
    End If

</div>
