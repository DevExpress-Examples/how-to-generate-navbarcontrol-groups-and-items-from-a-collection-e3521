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
    Public NotInheritable Class TeamsCreator

        Private Sub New()
        End Sub

        Public Shared ReadOnly Teams As Teams
        Shared Sub New()
            Teams = New Teams()
            Teams.Add(TeamCreator.Team(0))
            Teams.Add(TeamCreator.Team(1))
        End Sub
    End Class
End Namespace