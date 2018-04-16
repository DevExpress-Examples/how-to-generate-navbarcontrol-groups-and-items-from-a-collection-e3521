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

Imports System.Windows.Controls
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media
Imports System
Imports System.Reflection
Imports System.Windows.Data
Imports System.Collections
Imports System.Collections.Specialized
Imports DevExpress.Xpf.NavBar
Namespace NavBarExtensions
    Public Class NavBarGroupWrapper
        Inherits Control
        Implements IDisposable

        #Region "DP"
        Public Shared ReadOnly ContentProperty As DependencyProperty = DependencyProperty.Register("Content", GetType(Object), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly ContentTemplateProperty As DependencyProperty = DependencyProperty.Register("ContentTemplate", GetType(DataTemplate), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly HeaderProperty As DependencyProperty = DependencyProperty.Register("Header", GetType(Object), GetType(NavBarGroupWrapper), New PropertyMetadata(String.Empty))
        Public Shared ReadOnly HeaderTemplateProperty As DependencyProperty = DependencyProperty.Register("HeaderTemplate", GetType(DataTemplate), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))

        Public Shared ReadOnly ImageSourceProperty As DependencyProperty = DependencyProperty.Register("ImageSource", GetType(ImageSource), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly DisplaySourceProperty As DependencyProperty = DependencyProperty.Register("DisplaySource", GetType(DisplaySource), GetType(NavBarGroupWrapper), New PropertyMetadata(DisplaySource.Items))

        Public Shared ReadOnly CommandProperty As DependencyProperty = DependencyProperty.Register("Command", GetType(ICommand), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly CommandParameterProperty As DependencyProperty = DependencyProperty.Register("CommandParameter", GetType(Object), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly CommandTargetProperty As DependencyProperty = DependencyProperty.Register("CommandTarget", GetType(IInputElement), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))

        Public Shared ReadOnly NavBarGroupIsVisibleProperty As DependencyProperty = DependencyProperty.Register("NavBarGroupIsVisible", GetType(Boolean), GetType(NavBarGroupWrapper), New PropertyMetadata(True))

        Public Shared ReadOnly SelectedItemProperty As DependencyProperty = DependencyProperty.Register("SelectedItem", GetType(NavBarItem), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly SelectedItemIndexProperty As DependencyProperty = DependencyProperty.Register("SelectedItemIndex", GetType(Integer), GetType(NavBarGroupWrapper), New PropertyMetadata(ConstantHelper.InvalidIndex))

        Public Shared ReadOnly ItemsSourceProperty As DependencyProperty = DependencyProperty.Register("ItemsSource", GetType(IEnumerable), GetType(NavBarGroupWrapper), New PropertyMetadata(Nothing))

        Public Property Content() As Object
            Get
                Return DirectCast(GetValue(ContentProperty), Object)
            End Get
            Set(ByVal value As Object)
                SetValue(ContentProperty, value)
            End Set
        End Property
        Public Property ContentTemplate() As DataTemplate
            Get
                Return DirectCast(GetValue(ContentTemplateProperty), DataTemplate)
            End Get
            Set(ByVal value As DataTemplate)
                SetValue(ContentTemplateProperty, value)
            End Set
        End Property
        Public Property Header() As Object
            Get
                Return DirectCast(GetValue(HeaderProperty), Object)
            End Get
            Set(ByVal value As Object)
                SetValue(HeaderProperty, value)
            End Set
        End Property
        Public Property HeaderTemplate() As DataTemplate
            Get
                Return DirectCast(GetValue(HeaderTemplateProperty), DataTemplate)
            End Get
            Set(ByVal value As DataTemplate)
                SetValue(HeaderTemplateProperty, value)
            End Set
        End Property
        Public Property ImageSource() As ImageSource
            Get
                Return DirectCast(GetValue(ImageSourceProperty), ImageSource)
            End Get
            Set(ByVal value As ImageSource)
                SetValue(ImageSourceProperty, value)
            End Set
        End Property
        Public Property DisplaySource() As DisplaySource
            Get
                Return DirectCast(GetValue(DisplaySourceProperty), DisplaySource)
            End Get
            Set(ByVal value As DisplaySource)
                SetValue(DisplaySourceProperty, value)
            End Set
        End Property
        Public Property Command() As ICommand
            Get
                Return DirectCast(GetValue(CommandProperty), ICommand)
            End Get
            Set(ByVal value As ICommand)
                SetValue(CommandProperty, value)
            End Set
        End Property
        Public Property CommandParameter() As Object
            Get
                Return DirectCast(GetValue(CommandParameterProperty), Object)
            End Get
            Set(ByVal value As Object)
                SetValue(CommandParameterProperty, value)
            End Set
        End Property
        Public Property CommandTarget() As IInputElement
            Get
                Return DirectCast(GetValue(CommandTargetProperty), IInputElement)
            End Get
            Set(ByVal value As IInputElement)
                SetValue(CommandTargetProperty, value)
            End Set
        End Property
        Public Property NavBarGroupIsVisible() As Boolean
            Get
                Return DirectCast(GetValue(NavBarGroupIsVisibleProperty), Boolean)
            End Get
            Set(ByVal value As Boolean)
                SetValue(NavBarGroupIsVisibleProperty, value)
            End Set
        End Property
        Public Property SelectedItem() As NavBarItem
            Get
                Return DirectCast(GetValue(SelectedItemProperty), NavBarItem)
            End Get
            Set(ByVal value As NavBarItem)
                SetValue(SelectedItemProperty, value)
            End Set
        End Property
        Public Property SelectedItemIndex() As Integer
            Get
                Return DirectCast(GetValue(SelectedItemIndexProperty), Integer)
            End Get
            Set(ByVal value As Integer)
                SetValue(SelectedItemIndexProperty, value)
            End Set
        End Property
        Public Property ItemsSource() As IEnumerable
            Get
                Return DirectCast(GetValue(ItemsSourceProperty), IEnumerable)
            End Get
            Set(ByVal value As IEnumerable)
                SetValue(ItemsSourceProperty, value)
            End Set
        End Property
        #End Region
        Public Delegate Sub NavBarItemsCollectionChangedEventHandler(ByVal groupStyler As NavBarGroupWrapper, ByVal e As NotifyCollectionChangedEventArgs, ByVal isDisposing As Boolean)
        Public Event NavBarItemsCollectionChanged As NavBarItemsCollectionChangedEventHandler
        Public ReadOnly Property NavBarItems() As SynchronizedNavBarItemCollection
            Get
                Return NavBarGroup.SynchronizedItems
            End Get
        End Property
        Private privateNavBarGroup As NavBarGroup
        Public Property NavBarGroup() As NavBarGroup
            Get
                Return privateNavBarGroup
            End Get
            Private Set(ByVal value As NavBarGroup)
                privateNavBarGroup = value
            End Set
        End Property

        Friend Sub New(ByVal style As Style, ByVal navBarGroup As NavBarGroup, ByVal dataObject As Object)
            NavBarMVVMAttachedBehavior.SetNavBarGroupStyler(navBarGroup, Me)
            DefaultStyleKey = GetType(NavBarGroupWrapper)
            If style IsNot Nothing Then
                Me.Style = style
            End If
            DataContext = dataObject
            Me.NavBarGroup = navBarGroup
        End Sub
        Friend Sub Init()
            Subscribe()
            SetProperties()
        End Sub
        Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
            Unsubscribe()
            RaiseEvent NavBarItemsCollectionChanged(Me, New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset), True)
            NavBarMVVMAttachedBehavior.SetNavBarGroupStyler(NavBarGroup, Nothing)
            DataContext = Nothing
            NavBarGroup = Nothing
            ClearProperties()
        End Sub

        Friend Function GetNavBarItemDataObject(ByVal item As NavBarItem) As Object
            'int index = NavBarItems.IndexOf(item);
            'if(NavBarGroup.Items[index] == item)
            '    return null;
            'return NavBarGroup.Items[index];
#If SILVERLIGHT Then
            Return item.Content
#Else
            Return CType(item, DevExpress.Xpf.Core.DXFrameworkContentElement).DataContext
#End If
        End Function
        Private Sub OnNavBarItemsCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            RaiseEvent NavBarItemsCollectionChanged(Me, e, False)
        End Sub

        Private Sub Subscribe()
            AddHandler NavBarItems.CollectionChanged, AddressOf OnNavBarItemsCollectionChanged
        End Sub
        Private Sub Unsubscribe()
            RemoveHandler NavBarItems.CollectionChanged, AddressOf OnNavBarItemsCollectionChanged
        End Sub
        Private Sub SetProperties()
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ContentProperty, New Binding("Content") With {.Source = Me})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ContentTemplateProperty, New Binding("ContentTemplate") With {.Source = Me})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.HeaderProperty, New Binding("Header") With {.Source = Me})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.HeaderTemplateProperty, New Binding("HeaderTemplate") With {.Source = Me})

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ImageSourceProperty, New Binding("ImageSource") With {.Source = Me})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.DisplaySourceProperty, New Binding("DisplaySource") With {.Source = Me})

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.CommandProperty, New Binding("Command") With {.Source = Me})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.CommandParameterProperty, New Binding("CommandParameter") With {.Source = Me})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.CommandTargetProperty, New Binding("CommandTarget") With {.Source = Me})

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.IsVisibleProperty, New Binding("NavBarIsVisible") With {.Source = Me, .Mode = BindingMode.TwoWay})

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.SelectedItemProperty, New Binding("SelectedItem") With {.Source = Me, .Mode = BindingMode.TwoWay})
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.SelectedItemIndexProperty, New Binding("SelectedItemIndex") With {.Source = Me, .Mode = BindingMode.TwoWay})

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ItemsSourceProperty, New Binding("ItemsSource") With {.Source = Me})
        End Sub
        Private Sub ClearProperties()
            NavBarGroup.ClearValue(NavBarGroup.ContentProperty)
            NavBarGroup.ClearValue(NavBarGroup.ContentTemplateProperty)
            NavBarGroup.ClearValue(NavBarGroup.HeaderProperty)
            NavBarGroup.ClearValue(NavBarGroup.HeaderTemplateProperty)

            NavBarGroup.ClearValue(NavBarGroup.ImageSourceProperty)
            NavBarGroup.ClearValue(NavBarGroup.DisplaySourceProperty)

            NavBarGroup.ClearValue(NavBarGroup.CommandProperty)
            NavBarGroup.ClearValue(NavBarGroup.CommandParameterProperty)
            NavBarGroup.ClearValue(NavBarGroup.CommandTargetProperty)

            NavBarGroup.ClearValue(NavBarGroup.IsVisibleProperty)

            NavBarGroup.ClearValue(NavBarGroup.SelectedItemProperty)
            NavBarGroup.ClearValue(NavBarGroup.SelectedItemIndexProperty)

            NavBarGroup.ClearValue(NavBarGroup.ItemsSourceProperty)
        End Sub
    End Class
End Namespace