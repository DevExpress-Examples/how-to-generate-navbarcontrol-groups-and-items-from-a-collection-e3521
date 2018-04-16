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
Imports System.Collections.ObjectModel
Imports NavBarMVVM.Model

Namespace NavBarMVVM.ViewModel
    Public Class TeamsViewModel
        Inherits ObservableCollection(Of TeamViewModel)

        Private privateTeams As Teams
        Public Property Teams() As Teams
            Get
                Return privateTeams
            End Get
            Private Set(ByVal value As Teams)
                privateTeams = value
            End Set
        End Property
        Public Sub New(ByVal teams As Teams)
            Me.Teams = teams
            For Each team As Team In Me.Teams
                Add(New TeamViewModel(team))
            Next team
        End Sub
    End Class
End Namespace
