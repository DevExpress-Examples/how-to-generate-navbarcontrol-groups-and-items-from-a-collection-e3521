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
Imports NavBarMVVM.Model
Imports System.Windows.Media.Imaging

Namespace NavBarMVVM.Helpers
    Public NotInheritable Class PersonCreator

        Private Sub New()
        End Sub
        Public Shared ReadOnly Person() As Person

        Shared Sub New()
            Person = New Person(3){}
            Person(0) = New Person() With {.Name = "Anne Dodsworth", .Photo = New Uri("/NavBarMVVM;component/Images/AnneDodsworth.jpg", UriKind.Relative)}
            Person(1) = New Person() With {.Name = "Nancy Davolio", .Photo = New Uri("/NavBarMVVM;component/Images/NancyDavolio.jpg", UriKind.Relative)}
            Person(2) = New Person() With {.Name = "Robert King", .Photo = New Uri("/NavBarMVVM;component/Images/RobertKing.jpg", UriKind.Relative)}
            Person(3) = New Person() With {.Name = "Steven Buchanan", .Photo = New Uri("/NavBarMVVM;component/Images/StevenBuchanan.jpg", UriKind.Relative)}
        End Sub
    End Class
End Namespace
