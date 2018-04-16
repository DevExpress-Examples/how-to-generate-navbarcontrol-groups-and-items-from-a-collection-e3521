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

Imports System.Windows.Interactivity
Imports System.Windows
Imports System.Collections
Imports System.Collections.Specialized
Imports System
Imports System.Windows.Data
Imports DevExpress.Xpf.NavBar
Namespace NavBarExtensions
    Public Class NavBarMVVMAttachedBehavior
        Inherits Behavior(Of NavBarControl)

        #Region "DP"
        Public Shared ReadOnly ItemsSourceProperty As DependencyProperty = DependencyProperty.Register("ItemsSource", GetType(IEnumerable), GetType(NavBarMVVMAttachedBehavior), New PropertyMetadata(Nothing, Sub(d,e) CType(d, NavBarMVVMAttachedBehavior).OnItemsSourceChanged(DirectCast(e.OldValue, IEnumerable))))
        Public Shared ReadOnly GroupStyleProperty As DependencyProperty = DependencyProperty.Register("GroupStyle", GetType(Style), GetType(NavBarMVVMAttachedBehavior), New PropertyMetadata(Nothing))
        Public Shared ReadOnly ItemStyleProperty As DependencyProperty = DependencyProperty.Register("ItemStyle", GetType(Style), GetType(NavBarMVVMAttachedBehavior), New PropertyMetadata(Nothing))

        Public Shared ReadOnly NavBarGroupStylerProperty As DependencyProperty = DependencyProperty.RegisterAttached("NavBarGroupStyler", GetType(NavBarGroupWrapper), GetType(NavBarMVVMAttachedBehavior), New PropertyMetadata(Nothing))
        Public Shared ReadOnly NavBarItemStylerProperty As DependencyProperty = DependencyProperty.RegisterAttached("NavBarItemStyler", GetType(NavBarItemWrapper), GetType(NavBarMVVMAttachedBehavior), New PropertyMetadata(Nothing))
        Public Shared Function GetNavBarGroupStyler(ByVal obj As NavBarGroup) As NavBarGroupWrapper
            Return CType(obj.GetValue(NavBarGroupStylerProperty), NavBarGroupWrapper)
        End Function
        Public Shared Sub SetNavBarGroupStyler(ByVal obj As NavBarGroup, ByVal value As NavBarGroupWrapper)
            obj.SetValue(NavBarGroupStylerProperty, value)
        End Sub
        Public Shared Function GetNavBarItemStyler(ByVal obj As NavBarItem) As NavBarItemWrapper
            Return CType(obj.GetValue(NavBarItemStylerProperty), NavBarItemWrapper)
        End Function
        Public Shared Sub SetNavBarItemStyler(ByVal obj As NavBarItem, ByVal value As NavBarItemWrapper)
            obj.SetValue(NavBarItemStylerProperty, value)
        End Sub

        Public Property ItemsSource() As IEnumerable
            Get
                Return DirectCast(GetValue(ItemsSourceProperty), IEnumerable)
            End Get
            Set(ByVal value As IEnumerable)
                SetValue(ItemsSourceProperty, value)
            End Set
        End Property
        Public Property GroupStyle() As Style
            Get
                Return CType(GetValue(GroupStyleProperty), Style)
            End Get
            Set(ByVal value As Style)
                SetValue(GroupStyleProperty, value)
            End Set
        End Property
        Public Property ItemStyle() As Style
            Get
                Return CType(GetValue(ItemStyleProperty), Style)
            End Get
            Set(ByVal value As Style)
                SetValue(ItemStyleProperty, value)
            End Set
        End Property
        #End Region
        Public Function GetNavBarGroupContainerFromItem(ByVal data As Object) As NavBarGroup
            If Not IsInitialized Then
                Return Nothing
            End If
            For Each gr As NavBarGroup In NavBar.Groups
                If gr.DataContext Is data Then
                    Return gr
                End If
            Next gr
            Return Nothing
        End Function
        Public Function GetItemFromNavBarGroupContainer(ByVal gr As NavBarGroup) As Object
            Return gr.DataContext
        End Function

        Protected ReadOnly Property NavBar() As NavBarControl
            Get
                Return AssociatedObject
            End Get
        End Property
        Private privateIsInitialized As Boolean
        Protected Property IsInitialized() As Boolean
            Get
                Return privateIsInitialized
            End Get
            Private Set(ByVal value As Boolean)
                privateIsInitialized = value
            End Set
        End Property

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            If Not IsInitialized Then
                TryInitialize()
                Return
            End If
        End Sub
        Protected Overrides Sub OnDetaching()
            MyBase.OnDetaching()
            If TypeOf ItemsSource Is INotifyCollectionChanged Then
                RemoveHandler DirectCast(ItemsSource, INotifyCollectionChanged).CollectionChanged, AddressOf OnItemsSourceCollectionChanged
            End If
            ClearNavBarGroups()
            IsInitialized = False
        End Sub
        Protected Overridable Sub OnItemsSourceChanged(ByVal oldSource As IEnumerable)
            If Not IsInitialized Then
                TryInitialize()
                Return
            End If
            If TypeOf oldSource Is INotifyCollectionChanged Then
                RemoveHandler DirectCast(oldSource, INotifyCollectionChanged).CollectionChanged, AddressOf OnItemsSourceCollectionChanged
            End If
            ClearNavBarGroups()
            If ItemsSource Is Nothing Then
                IsInitialized = False
                Return
            End If
            For Each obj As Object In ItemsSource
                AddNavBarGroup(obj)
            Next obj
            If TypeOf ItemsSource Is INotifyCollectionChanged Then
                AddHandler DirectCast(ItemsSource, INotifyCollectionChanged).CollectionChanged, AddressOf OnItemsSourceCollectionChanged
            End If
        End Sub
        Private Sub TryInitialize()
            If IsInitialized Then
                Return
            End If
            If NavBar Is Nothing OrElse ItemsSource Is Nothing Then
                Return
            End If
            IsInitialized = True
            For Each obj As Object In ItemsSource
                AddNavBarGroup(obj)
            Next obj
            If TypeOf ItemsSource Is INotifyCollectionChanged Then
                AddHandler DirectCast(ItemsSource, INotifyCollectionChanged).CollectionChanged, AddressOf OnItemsSourceCollectionChanged
            End If
        End Sub
        Private Sub OnItemsSourceCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.Action = NotifyCollectionChangedAction.Add AndAlso e.NewItems IsNot Nothing Then
                For i As Integer = 0 To e.NewItems.Count - 1
                    If e.NewStartingIndex = -1 Then
                        AddNavBarGroup(e.NewItems(i))
                    Else
                        AddNavBarGroup(e.NewItems(i), i + e.NewStartingIndex)
                    End If
                Next i
            End If
            If e.Action = NotifyCollectionChangedAction.Remove AndAlso e.OldItems IsNot Nothing Then
                For i As Integer = 0 To e.OldItems.Count - 1
                    RemoveNavBarGroup(e.OldItems(i))
                Next i
            End If
            If e.Action = NotifyCollectionChangedAction.Replace Then
                If e.OldItems IsNot Nothing Then
                    For i As Integer = 0 To e.OldItems.Count - 1
                        RemoveNavBarGroup(e.OldItems(i))
                    Next i
                End If
                If e.NewItems IsNot Nothing Then
                    For i As Integer = 0 To e.NewItems.Count - 1
                        If e.NewStartingIndex = -1 Then
                            AddNavBarGroup(e.NewItems(i))
                        Else
                            AddNavBarGroup(e.NewItems(i), i + e.NewStartingIndex)
                        End If
                    Next i
                End If
            End If
            If e.Action = NotifyCollectionChangedAction.Reset Then
                ClearNavBarGroups()
            End If
        End Sub

        Private Sub ClearNavBarGroups()
            If Not IsInitialized Then
                Return
            End If
            For Each gr As NavBarGroup In NavBar.Groups
                RemoveNavBarGroup(gr)
            Next gr
        End Sub
        Private Sub AddNavBarGroup(ByVal obj As Object)
            If Not IsInitialized Then
                Return
            End If
            NavBar.Groups.Add(CreateNavBarGroup(obj))
        End Sub
        Private Sub AddNavBarGroup(ByVal obj As Object, ByVal index As Integer)
            If Not IsInitialized Then
                Return
            End If
            NavBar.Groups.Insert(index, CreateNavBarGroup(obj))
        End Sub
        Private Sub RemoveNavBarGroup(ByVal obj As Object)
            If Not IsInitialized Then
                Return
            End If
            RemoveNavBarGroup(GetNavBarGroupContainerFromItem(obj))
        End Sub
        Private Sub RemoveNavBarGroup(ByVal gr As NavBarGroup)
            Dim styler As NavBarGroupWrapper = NavBarMVVMAttachedBehavior.GetNavBarGroupStyler(gr)
            DirectCast(styler, IDisposable).Dispose()
            RemoveHandler styler.NavBarItemsCollectionChanged, AddressOf OnStylerNavBarItemsCollectionChanged
        End Sub
        Private Function CreateNavBarGroup(ByVal obj As Object) As NavBarGroup
            Dim gr As New NavBarGroup() With {.DataContext = obj}
            Dim styler As New NavBarGroupWrapper(GroupStyle, gr, obj)
            AddHandler styler.NavBarItemsCollectionChanged, AddressOf OnStylerNavBarItemsCollectionChanged
            styler.Init()
            Return gr
        End Function

        Protected Overridable Sub OnGroupItemAdding(ByVal item As NavBarItem, ByVal dataObject As Object)
            Dim styler As New NavBarItemWrapper(ItemStyle, item, dataObject)
            styler.Init()
        End Sub
        Protected Overridable Sub OnGroupItemRemoving(ByVal item As NavBarItem, ByVal dataObject As Object)
            Dim styler As NavBarItemWrapper = NavBarMVVMAttachedBehavior.GetNavBarItemStyler(item)
            DirectCast(styler, IDisposable).Dispose()
        End Sub

        Private Sub OnStylerNavBarItemsCollectionChanged(ByVal groupStyler As NavBarGroupWrapper, ByVal e As NotifyCollectionChangedEventArgs, ByVal isDisposing As Boolean)
            If e.Action = NotifyCollectionChangedAction.Add AndAlso e.NewItems IsNot Nothing Then
                For Each item As NavBarItem In e.NewItems
                    OnGroupItemAdding(item, groupStyler.GetNavBarItemDataObject(item))
                Next item
            End If
            If e.Action = NotifyCollectionChangedAction.Remove AndAlso e.OldItems IsNot Nothing Then
                For Each item As NavBarItem In e.OldItems
                    OnGroupItemRemoving(item, groupStyler.GetNavBarItemDataObject(item))
                Next item
            End If
            If e.Action = NotifyCollectionChangedAction.Replace Then
                If e.OldItems IsNot Nothing Then
                    For Each item As NavBarItem In e.OldItems
                        OnGroupItemRemoving(item, groupStyler.GetNavBarItemDataObject(item))
                    Next item
                End If
                If e.NewItems IsNot Nothing Then
                    For Each item As NavBarItem In e.NewItems
                        OnGroupItemAdding(item, groupStyler.GetNavBarItemDataObject(item))
                    Next item
                End If
            End If
            If e.Action = NotifyCollectionChangedAction.Reset Then
                For Each item As NavBarItem In groupStyler.NavBarItems
                    OnGroupItemRemoving(item, groupStyler.GetNavBarItemDataObject(item))
                Next item
                If Not isDisposing Then
                    For Each item As NavBarItem In groupStyler.NavBarItems
                        OnGroupItemAdding(item, groupStyler.GetNavBarItemDataObject(item))
                    Next item
                End If
            End If
        End Sub
    End Class
End Namespace