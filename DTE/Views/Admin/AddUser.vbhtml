@ModelType Entities.User

@Code
    ViewData("Title") = "เพิ่ม User"
End Code

<div class="row">
    <h2>เพิ่ม User</h2>

    <a class="btn btn-primary" href="@Url.Action("ManageUser", "Admin")">ย้อนกลับ</a>

    @Using Html.BeginForm("AddUser", "Admin", FormMethod.Post)
        @<div Class="form-group">
            @Html.LabelFor(Function(u) u.UserName)
            @Html.TextBoxFor(Function(u) u.UserName, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(u) u.UserName)
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(u) u.PWD)
            @Html.PasswordFor(Function(u) u.PWD, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(u) u.PWD)
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(u) u.UserDesc)
            @Html.TextBoxFor(Function(u) u.UserDesc, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(u) u.UserDesc)
        </div>

        @<div Class="form-group">
            @Html.CheckBoxFor(Function(u) u.IsAdmin)
            @Html.LabelFor(Function(u) u.IsAdmin)
        </div>

        @<Button Class="btn btn-primary">ตกลง</Button>
    End Using

</div>
