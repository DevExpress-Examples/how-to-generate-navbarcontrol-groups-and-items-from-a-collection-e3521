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

Namespace NavBarMVVM.ViewModel
    Public Class TeamViewModel
        Inherits ViewModelBase

        Public Property Caption() As String
            Get
                Return Team.Caption
            End Get
            Set(ByVal value As String)
                If Team.Caption = value Then
                    Return
                End If
                Team.Caption = value
                OnPropertyChanged("Caption")
            End Set
        End Property
        Private privatePersonsViewModel As PersonsViewModel
        Public Property PersonsViewModel() As PersonsViewModel
            Get
                Return privatePersonsViewModel
            End Get
            Private Set(ByVal value As PersonsViewModel)
                privatePersonsViewModel = value
            End Set
        End Property
        Private privateTeam As Team
        Public Property Team() As Team
            Get
                Return privateTeam
            End Get
            Private Set(ByVal value As Team)
                privateTeam = value
            End Set
        End Property
        Public Sub New(ByVal team As Team)
            Me.Team = team
            PersonsViewModel = New PersonsViewModel(Me.Team.Persons)
        End Sub
    End Class
End Namespace
