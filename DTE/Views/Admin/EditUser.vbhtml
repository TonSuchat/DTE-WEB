@ModelType DTE.Entities.User

@Code
    ViewData("Title") = "แก้ไขผู้ใช้งาน"
    Dim userTypes = Helpers.GetSelectListItemUserTypes(Helpers.GetCurrentUser.Type)
End Code


<div class="row">

    <h2>แก้ไขผู้ใช้งาน</h2>

    <a class="btn btn-primary" href="@Url.Action("ManageUser", "Admin")">ย้อนกลับ</a>
    <hr />
    @Using Html.BeginForm("EditUser", "Admin", FormMethod.Post, New With {.id = "formAdminEditUser"})

        @Html.ValidationSummary(True)

        @Html.Hidden("id", Model.id)
        @Html.Hidden("userName", Model.UserName)
        @Html.Hidden("PWD", Model.PWD)
        @Html.Hidden("CreateDate", Model.CreateDate)

        @<h3>ชื่อผู้ใช้งาน : @Model.UserName</h3>

        @<div Class="form-group">
            <label class="control-label">หมายเหตุ</label>
            @Html.TextBoxFor(Function(modelItem) Model.UserDesc, New With {.class = "form-control", .id = "newPassword"})
        </div>

        @<div Class="form-group">
            <label class="control-label">ระดับ</label>
            @Html.DropDownListFor(Function(modelItem) Model.Type, userTypes, New With {.class = "form-control"})
        </div>

        @<div Class="form-group">
            <label class="control-label">Station</label>
            @Html.TextBoxFor(Function(modelItem) Model.Station, New With {.class = "form-control", .id = "newPassword"})
            @Html.ValidationMessageFor(Function(modelItem) Model.Station)
        </div>

        @<input type="submit" id="btnEditUser" class="btn btn-default btn-primary" value="แก้ไขผู้ใช้งาน" />

    End Using

</div>

