Imports System.ComponentModel
Imports System.Globalization

Public Class CustomBinder
    Inherits DefaultModelBinder

    Protected Overrides Function GetPropertyValue(controllerContext As ControllerContext, bindingContext As ModelBindingContext, propertyDescriptor As PropertyDescriptor, propertyBinder As IModelBinder) As Object
        Dim propertyType = propertyDescriptor.PropertyType
        If propertyType = GetType(DateTime) OrElse propertyType = GetType(System.Nullable(Of DateTime)) Then
            Dim providerValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName)
            If providerValue IsNot Nothing Then
                Dim [date] As DateTime
                If DateTime.TryParseExact(providerValue.AttemptedValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, [date]) Then
                    Return [date]
                End If
            End If
        End If
        Return MyBase.GetPropertyValue(controllerContext, bindingContext, propertyDescriptor, propertyBinder)
    End Function

End Class
