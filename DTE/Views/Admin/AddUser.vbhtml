@ModelType Entities.User

@Code
    ViewData("Title") = "เพิ่ม User"
    Dim userTypes = Helpers.GetSelectListItemUserTypes(Helpers.GetCurrentUser.Type)
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
            @Html.LabelFor(Function(u) u.Type)
            @Html.DropDownList("Type", userTypes, New With {.class = "form-control"})
        </div>

        @<div Class="form-group">
            @Html.LabelFor(Function(u) u.Station)
            @Html.TextBoxFor(Function(u) u.Station, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(u) u.Station)
        </div>

        @<Button Class="btn btn-primary">ตกลง</Button>
    End Using

</div>
