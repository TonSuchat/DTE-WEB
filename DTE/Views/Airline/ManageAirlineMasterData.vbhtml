@ModelType List(Of Entities.AirlineMasterData)

@Code
    ViewData("Title") = "จัดการข้อมูล-Airline"
End Code

@section scripts

    <link href="~/Content/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">

        $(function () {
            $('#tblAirline').DataTable({ "bSort": false });

            $('.btnremove').click(function () {
                if (confirm('ต้องการลบข้อมูลนี้?')) {
                    $(this).parent('form').submit();
                }
            })
        })

    </script>

End Section

<div class="row">
    <h2>จัดการข้อมูล-Airline</h2>

    @If Helpers.GetCurrentUser.Type = 1 Then
        @<div class="row">
            <a Class="btn btn-lg btn-success" href="@Url.Action("AddAirlineMasterData", "Airline")">เพิ่มข้อมูล Airline</a>
        </div>
    End If

    @If IsNothing(Model) OrElse Model.Count = 0 Then
        @Html.Partial("NotFoundData")
    Else
        @<div Class="row">
            <table id="tblAirline" Class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>ALC2</th>
                        <th>ALC3</th>
                        <th>ALFN</th>
                        <th>ADD1</th>
                        <th>ADD2</th>
                        <th>ADD3</th>
                        <th>ADD4</th>
                        <th>EmailAddress</th>
                        <th>Logo</th>
                        <th>วันที่สร้างรายการ</th>
                        <th>วันที่แก้ไขรายการ</th>
                        @If Helpers.GetCurrentUser.Type = 1 Then
                            @<th>แก้ไข</th>
                            @<th>ลบ</th>
                        End If
                    </tr>
                </thead>
                <tbody>
                    @for Each item In Model
                        @<tr>
                            <td>@item.ALC2</td>
                            <td>@item.ALC3</td>
                            <td>@item.ALFN</td>
                            <td>@item.ADD1</td>
                            <td>@item.ADD2</td>
                            <td>@item.ADD3</td>
                            <td>@item.ADD4</td>
                            <td>@item.EmailAddress</td>
                            <td><img src="@item.ImageLogo" width="150" height="50" /></td>
                            <td>@item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                            <td>@item.UpdateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                            @If Helpers.GetCurrentUser.Type = 1 Then
                                @<td>
                                    <a Class="btn btn-sm btn-warning" href="@Url.Action("EditAirlineMasterData", "Airline", New With {.id = item.Id})">
                                        <span Class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                    </a>
                                </td>
                                @<td>
                                    @using Html.BeginForm("RemoveAirlineMasterData", "Airline", FormMethod.Post, New With {.role = "form"})
                                        @<input type="hidden" value="@item.Id" name="id" />
                                        @<button type="button" class="btn btn-sm btn-danger btnremove">
                                            <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                        </button>
                                    End Using
                                </td>
                            End If
                        </tr>
                    Next
                </tbody>
            </table>
        </div>
    End If

</div>
