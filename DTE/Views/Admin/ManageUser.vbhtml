﻿@ModelType List(Of Entities.User)

@Code
    ViewData("Title") = "จัดการข้อมูล-User"
End Code

@section scripts

    <link href="~/Content/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.dataTables.min.js"></script>
    <script src="~/Scripts/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">

        $(function () {

            $('.removebtn').click(function () {
                if (confirm('ต้องการลบ User นี้?')) {
                    $(this).parent('form').submit();
                }
            })

            $('#tableUser').DataTable({'bSort':false});

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
            <table class="table table-bordered table-striped" id="tableUser">
                <thead>
                    <tr>
                        <th class="text-center">Id</th>
                        <th class="text-center">ชื่อผู้ใช้งาน</th>
                        <th class="text-center">หมายเหตุ</th>
                        <th class="text-center">ระดับ</th>
                        <th class="text-center">Station</th>
                        <th class="text-center">วันที่สร้างรายการ</th>

                        @If Helpers.GetCurrentUser.Type = 1 Then
                            @<th Class="text-center">แก้ไข</th>
                        End If

                        <th class="text-center">เปลี่ยนรหัส</th>
                        <th class="text-center">ลบ</th>
                    </tr>
                </thead>
                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td class="text-center">@item.id</td>
                            <td class="text-center">@item.UserName</td>
                            <td>@item.UserDesc</td>
                            <td class="text-center">@Helpers.ConvertUserTypeToText(item.Type)</td>
                            <td class="text-center">@item.Station</td>
                            <td class="text-center">@item.CreateDate.ToString("dd/MM/yyyy HH:mm:ss")</td>
                            @If Helpers.GetCurrentUser.Type = 1 Then
                                @<td Class="text-center">
                                    <a Class="btn btn-sm btn-warning" href="@Url.Action("EditUser", "Admin", New With {.id = item.id, .userName = item.UserName})">
                                        <span Class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                    </a>
                                </td>
                            End If
                            <td Class="text-center">
                                <a Class="btn btn-sm btn-warning" href="@Url.Action("ChangePassword", "Admin", New With {.id = item.id, .userName = item.UserName})">
                                    <span Class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                </a>
                            </td>
                            <td Class="text-center">
                                @Using Html.BeginForm("RemoveUser", "Admin", FormMethod.Post, New With {.role = "form"})
                                    @<input type="hidden" name="id" value="@item.id" />
                                    @<Button Class="btn btn-sm btn-danger removebtn" type="button">
                                        <span Class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                    </Button>
                                End Using
                            </td>
                        </tr>
                    Next
                </tbody>
            </table>
        </div>


    End If

</div>
