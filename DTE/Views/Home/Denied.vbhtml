@Code
    ViewData("Title") = "Denied"
End Code

<div class="jumbotron">
    <h1>ไม่มีสิทธิ์ใช้งานส่วนนี้</h1>
    @Html.ActionLink("กลับหน้าหลัก", "Index", "Home", Nothing, New With {.class = "btn btn-danger btn-lg"})
</div>

