@ModelType List(Of Entities.User)

@Code
    ViewData("Title") = "จัดการข้อมูล-User"
End Code

@section scripts
    <script type="text/javascript">

        $(function () {
            $('.removebtn').click(function () {
                if (confirm('ต้องการลบ User นี้?')) {
                    $(this).parent('form').submit();
                }
            })
        })

    </script>
End Section

<div class="row">
    <h2>จัดการข้อมูล-User</h2>

    <div class="row">
        <a class="btn btn-lg btn-success" href="@Url.Action("AddUser", "Admin")">เพิ่ม User</a>
    </div>

    @If IsNothing(Model) OrElse Model.Count = 0 Then
        @Html.Partial("NotFoundData")
    Else
        @<div class="row">
            <table class="table table-bordered table-striped">
                <tr>
                    <th class="text-center">Id</th>
                    <th class="text-center">UserName</th>
                    <th class="text-center">UserDesc</th>
                    <th class="text-center">IsAdmin</th>
                    <th class="text-center">Station</th>
                    <th class="text-center">CreateDate</th>
                    @*<th class="text-center">แก้ไข</th>*@
                    <th class="text-center">ลบ</th>
                </tr>
                @For Each item In Model
                    @<tr>
                        <td class="text-center">@item.id</td>
                        <td class="text-center">@item.UserName</td>
                        <td>@item.UserDesc</td>
                        <td class="text-center">@item.IsAdmin</td>
                         <td class="text-center">@item.Station</td>
                        <td class="text-center">@item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                        @*<td class="text-center">
                            <a class="btn btn-sm btn-warning" href="@Url.Action("EditUser", "Admin")">
                                <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                            </a>
                        </td>*@
                        <td class="text-center">
                            @using Html.BeginForm("RemoveUser", "Admin", FormMethod.Post, New With {.role = "form"})
                                @<input type="hidden" name="id" value="@item.id" />
                                @<Button Class="btn btn-sm btn-danger removebtn" type="button">
                                    <span Class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                </Button>
                            End Using
                        </td>
                    </tr>
                Next
            </table>
        </div>


    End If

</div>
