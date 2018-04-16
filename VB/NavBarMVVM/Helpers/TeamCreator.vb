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
Imports NavBarMVVM.Model

Namespace NavBarMVVM.Helpers
    Public NotInheritable Class TeamCreator

        Private Sub New()
        End Sub
        Public Shared ReadOnly Team() As Team

        Shared Sub New()
            Team = New Team(1){}
            Team(0) = New Team() With {.Caption = "Documentation Team"}
            Team(0).Persons.Add(PersonCreator.Person(0))
            Team(0).Persons.Add(PersonCreator.Person(1))

            Team(1) = New Team() With {.Caption = "Management Team"}
            Team(1).Persons.Add(PersonCreator.Person(2))
            Team(1).Persons.Add(PersonCreator.Person(3))
        End Sub
    End Class
End Namespace
