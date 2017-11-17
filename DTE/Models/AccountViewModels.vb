Imports System.ComponentModel.DataAnnotations

Public Class LogInViewModel
    <Required()>
    <Display(Name:="ชื่อผู้ใช้งาน")>
    Public Property UserName As String
    <Required()>
    <Display(Name:="รหัสผ่าน")>
    Public Property Password As String
End Class

Public Class ChangePasswordViewModel
    <Required()>
    Public Property Id As String
    <Required(ErrorMessage:="ห้ามเป็นค่าว่าง")>
    <Display(Name:="รหัสผ่านเก่า")>
    Public Property OldPassword As String
    <Required(ErrorMessage:="ห้ามเป็นค่าว่าง")>
    <Display(Name:="รหัสผ่านใหม่")>
    Public Property NewPassword As String
    <Required(ErrorMessage:="ห้ามเป็นค่าว่าง")>
    <Compare("NewPassword", ErrorMessage:="รหัสผ่านต้องตรงกัน")>
    <Display(Name:="ยืนยันรหัสผ่าน")>
    Public Property ConfirmPassword As String
End Class

'Public Class ExternalLoginConfirmationViewModel
'    <Required>
'    <Display(Name:="Email")>
'    Public Property Email As String
'End Class

'Public Class ExternalLoginListViewModel
'    Public Property ReturnUrl As String
'End Class

'Public Class SendCodeViewModel
'    Public Property SelectedProvider As String
'    Public Property Providers As ICollection(Of System.Web.Mvc.SelectListItem)
'    Public Property ReturnUrl As String
'    Public Property RememberMe As Boolean
'End Class

'Public Class VerifyCodeViewModel
'    <Required>
'    Public Property Provider As String

'    <Required>
'    <Display(Name:="Code")>
'    Public Property Code As String

'    Public Property ReturnUrl As String

'    <Display(Name:="Remember this browser?")>
'    Public Property RememberBrowser As Boolean

'    Public Property RememberMe As Boolean
'End Class

'Public Class ForgotViewModel
'    <Required>
'    <Display(Name:="Email")>
'    Public Property Email As String
'End Class

'Public Class LoginViewModel
'    <Required>
'    <Display(Name:="Email")>
'    <EmailAddress>
'    Public Property Email As String

'    <Required>
'    <DataType(DataType.Password)>
'    <Display(Name:="Password")>
'    Public Property Password As String

'    <Display(Name:="Remember me?")>
'    Public Property RememberMe As Boolean
'End Class

'Public Class RegisterViewModel
'    <Required>
'    <EmailAddress>
'    <Display(Name:="Email")>
'    Public Property Email As String

'    <Required>
'    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
'    <DataType(DataType.Password)>
'    <Display(Name:="Password")>
'    Public Property Password As String

'    <DataType(DataType.Password)>
'    <Display(Name:="Confirm password")>
'    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
'    Public Property ConfirmPassword As String
'End Class

'Public Class ResetPasswordViewModel
'    <Required>
'    <EmailAddress>
'    <Display(Name:="Email")>
'    Public Property Email() As String

'    <Required>
'    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
'    <DataType(DataType.Password)>
'    <Display(Name:="Password")>
'    Public Property Password() As String

'    <DataType(DataType.Password)>
'    <Display(Name:="Confirm password")>
'    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
'    Public Property ConfirmPassword() As String

'    Public Property Code() As String
'End Class

'Public Class ForgotPasswordViewModel
'    <Required>
'    <EmailAddress>
'    <Display(Name:="Email")>
'    Public Property Email() As String
'End Class
