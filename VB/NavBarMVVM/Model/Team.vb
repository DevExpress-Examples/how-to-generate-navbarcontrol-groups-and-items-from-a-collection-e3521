' Developer Express Code Central Example:
' How to use the DXNavBar in a MVVM application
' 
' This example demonstrates how to use the DXNavBar with MVVM patter using special
' attached behavior.
' See http://www.devexpress.com/scid=K18540 for more
' information.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3521

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace NavBarMVVM.Model
    Public Class Team
        Public Caption As String = String.Empty
        Public ReadOnly Persons As Persons
        Public Sub New()
            Persons = New Persons()
        End Sub
    End Class
End Namespace
