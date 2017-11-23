@Code
    ViewData("Title") = "เปลี่ยนรหัส-Admin,SuperUser"
End Code

@section scripts
    <script type="text/javascript">

        $(function () {
            $('#btnChangePassword').click(function () {
                if (!CheckValidate()) return;
                if (confirm('ต้องการเปลี่ยน password?')) {
                    $('#formAdminChangePassword').submit();
                }
            })

            function CheckValidate() {
                if ($('#newPassword').val() && $('#newPassword').val().length > 0) return true;
                else {
                    alert('รหัสผ่านห้ามเป็นค่าว่าง');
                    return false;
                }
            }

        })

    </script>
End Section

<div class="row">

    <h2>เปลี่ยนรหัส-Admin,SuperUser</h2>
    <a class="btn btn-primary" href="@Url.Action("ManageUser", "Admin")">ย้อนกลับ</a>
    <hr />
    @Using Html.BeginForm("ChangePassword", "Admin", FormMethod.Post, New With {.id = "formAdminChangePassword"})

        @Html.ValidationSummary(True)

        @Html.Hidden("id", ViewBag.id)
        @Html.Hidden("userName", ViewBag.userName)

        @<h3>ชื่อผู้ใช้งาน : @ViewBag.userName</h3>

        @<div Class="form-group">
            <label class="control-label">รหัสผ่านใหม่</label>
            @Html.TextBox("newPassword", Nothing, New With {.class = "form-control", .id = "newPassword"})
        </div>

        @<input type="button" id="btnChangePassword" class="btn btn-default btn-primary" value="เปลี่ยนรหัส" />

    End Using

</div>