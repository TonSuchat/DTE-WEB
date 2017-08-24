@ModelType IList(Of Entities.TransactionDetail)

@Code
    ViewData("Title") = "จัดการข้อมูล-SO"
End Code

@section scripts

    <link href="~/Content/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#tblSO').DataTable({ "bSort": false });

            $('.btnremove').click(function () {
                if (confirm('ต้องการลบข้อมูลนี้?')) {
                    $(this).parent('form').submit();
                }
            })

        })

    </script>

End Section

<div class="row">
    @If IsNothing(Model) OrElse Model.Count = 0 Then
        @Html.Partial("NotFoundData")
    Else
        @<h2>จัดการข้อมูล-SO</h2>

        @<div Class="row">
            <a Class="btn btn-lg btn-success" href="@Url.Action("ExportExcel", "ServiceOrder")">Export to Excel</a>
        </div>

        @<div class="row">
             <table id="tblSO" class="table table-bordered table-striped">
                 <thead>
                     <tr>
                         <th class="text-center">WONumber</th>
                         <th class="text-center">Station</th>
                         <th class="text-center">Flight No.</th>
                         <th class="text-center">UpdateBy</th>
                         <th class="text-center">CreateBy</th>
                         <th class="text-center">UpdateDate</th>
                         <th class="text-center">CreateDate</th>
                         <th class="text-center">แก้ไข</th>
                         <th class="text-center">ลบ</th>
                     </tr>
                 </thead>
                 <tbody>
                     @For Each item In Model
                         @<tr>
                             <td class="text-center"><a target="_blank" href="@Url.Action("Detail", "ServiceOrder", New With {.id = item.id})">@item.WONumber</a></td>
                             <td class="text-center">@item.Station</td>
                             <td class="text-center">@item.FlightNo</td>
                             <td>@item.UpdatedByName</td>
                             <td>@item.CreatedByName</td>
                             <td>@item.UpdateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                             <td>@item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                             <td class="text-center">
                                 <a href="@Url.Action("EditSO", "ServiceOrder", New With {.id = item.id})" class="btn btn-warning btn-sm">
                                     <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                 </a>
                             </td>
                             <td class="text-center">
                                 @using Html.BeginForm("RemoveSO", "ServiceOrder", FormMethod.Post, New With {.role = "form"})
                                     @<input type="hidden" value="@item.id" name="id" />
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



