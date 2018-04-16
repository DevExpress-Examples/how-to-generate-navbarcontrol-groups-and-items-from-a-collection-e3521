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
Imports DevExpress.Xpf.NavBar
Namespace NavBarExtensions
    Public Class NavBarItemWrapper
        Inherits Control
        Implements IDisposable

        #Region "DP"
        Public Shared ReadOnly ContentProperty As DependencyProperty = DependencyProperty.Register("Content", GetType(Object), GetType(NavBarItemWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly NavBarItemTemplateProperty As DependencyProperty = DependencyProperty.Register("NavBarItemTemplate", GetType(DataTemplate), GetType(NavBarItemWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly ImageSourceProperty As DependencyProperty = DependencyProperty.Register("ImageSource", GetType(ImageSource), GetType(NavBarItemWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly NavBarItemIsVisibleProperty As DependencyProperty = DependencyProperty.Register("NavBarItemIsVisible", GetType(Boolean), GetType(NavBarItemWrapper), New PropertyMetadata(True))

        Public Shared ReadOnly CommandProperty As DependencyProperty = DependencyProperty.Register("Command", GetType(ICommand), GetType(NavBarItemWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly CommandParameterProperty As DependencyProperty = DependencyProperty.Register("CommandParameter", GetType(Object), GetType(NavBarItemWrapper), New PropertyMetadata(Nothing))
        Public Shared ReadOnly CommandTargetProperty As DependencyProperty = DependencyProperty.Register("CommandTarget", GetType(IInputElement), GetType(NavBarItemWrapper), New PropertyMetadata(Nothing))

        Public Property Content() As Object
            Get
                Return DirectCast(GetValue(ContentProperty), Object)
            End Get
            Set(ByVal value As Object)
                SetValue(ContentProperty, value)
            End Set
        End Property
        Public Property NavBarItemTemplate() As DataTemplate
            Get
                Return DirectCast(GetValue(NavBarItemTemplateProperty), DataTemplate)
            End Get
            Set(ByVal value As DataTemplate)
                SetValue(NavBarItemTemplateProperty, value)
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
        Public Property NavBarItemIsVisible() As Boolean
            Get
                Return DirectCast(GetValue(NavBarItemIsVisibleProperty), Boolean)
            End Get
            Set(ByVal value As Boolean)
                SetValue(NavBarItemIsVisibleProperty, value)
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
        #End Region
        Private privateNavBarItem As NavBarItem
        Public Property NavBarItem() As NavBarItem
            Get
                Return privateNavBarItem
            End Get
            Private Set(ByVal value As NavBarItem)
                privateNavBarItem = value
            End Set
        End Property
        Friend Sub New(ByVal style As Style, ByVal navBarItem As NavBarItem, ByVal dataObject As Object)
            NavBarMVVMAttachedBehavior.SetNavBarItemStyler(navBarItem, Me)
            DefaultStyleKey = GetType(NavBarItemWrapper)
            If style IsNot Nothing Then
                Me.Style = style
            End If
            DataContext = dataObject
            Me.NavBarItem = navBarItem
        End Sub
        Friend Sub Init()
            SetProperties()
        End Sub
        Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
            NavBarMVVMAttachedBehavior.SetNavBarItemStyler(NavBarItem, Nothing)
            DataContext = Nothing
            NavBarItem = Nothing
            ClearProperties()
        End Sub

        Private Sub SetProperties()
            BindingOperations.SetBinding(NavBarItem, NavBarItem.ContentProperty, New Binding("Content") With {.Source = Me})
            BindingOperations.SetBinding(NavBarItem, NavBarItem.TemplateProperty, New Binding("NavBarItemTemplate") With {.Source = Me})
            BindingOperations.SetBinding(NavBarItem, NavBarItem.ImageSourceProperty, New Binding("ImageSource") With {.Source = Me})
            BindingOperations.SetBinding(NavBarItem, NavBarItem.IsVisibleProperty, New Binding("NavBarItemIsVisible") With {.Source = Me})
            BindingOperations.SetBinding(NavBarItem, NavBarItem.CommandProperty, New Binding("Command") With {.Source = Me})
            BindingOperations.SetBinding(NavBarItem, NavBarItem.CommandParameterProperty, New Binding("CommandParameter") With {.Source = Me})
            BindingOperations.SetBinding(NavBarItem, NavBarItem.CommandTargetProperty, New Binding("CommandTarget") With {.Source = Me})
        End Sub
        Private Sub ClearProperties()
            NavBarItem.ClearValue(NavBarItem.ContentProperty)
            NavBarItem.ClearValue(NavBarItem.TemplateProperty)
            NavBarItem.ClearValue(NavBarItem.ImageSourceProperty)
            NavBarItem.ClearValue(NavBarItem.IsVisibleProperty)

            NavBarItem.ClearValue(NavBarItem.CommandProperty)
            NavBarItem.ClearValue(NavBarItem.CommandParameterProperty)
            NavBarItem.ClearValue(NavBarItem.CommandTargetProperty)
        End Sub
    End Class
End Namespace