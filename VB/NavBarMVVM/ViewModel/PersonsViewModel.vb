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
    Public Class PersonsViewModel
        Inherits ObservableCollection(Of PersonViewModel)

        Private privatePersons As Persons
        Public Property Persons() As Persons
            Get
                Return privatePersons
            End Get
            Private Set(ByVal value As Persons)
                privatePersons = value
            End Set
        End Property
        Public Sub New(ByVal persons As Persons)
            Me.Persons = persons
            For Each person As Person In Me.Persons
                Add(New PersonViewModel(person))
            Next person
        End Sub
    End Class
End Namespace
