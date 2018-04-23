Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace NavMVVMSample
    Public Class ViewModel
        Public Property Groups() As ObservableCollection(Of Group)

        Public Sub New()
            Groups = New ObservableCollection(Of Group)()
            Dim group As New Group() With {.Caption = "Group1"}
            group.GroupItems = New ObservableCollection(Of Item)()
            group.GroupItems.Add(New Item() With {.Content = "Item1_1"})
            group.GroupItems.Add(New Item() With {.Content = "Item1_2"})
            group.GroupItems.Add(New Item() With {.Content = "Item1_3"})
            Groups.Add(group)

            group = New Group() With {.Caption = "Group2"}
            group.GroupItems = New ObservableCollection(Of Item)()
            group.GroupItems.Add(New Item() With {.Content = "Item2_1"})
            group.GroupItems.Add(New Item() With {.Content = "Item2_2"})
            Groups.Add(group)

        End Sub
    End Class

    Public Class Item
        Public Property Content() As String
    End Class

    Public Class Group
        Public Property GroupItems() As ObservableCollection(Of Item)

        Public Property Caption() As String
    End Class
End Namespace
