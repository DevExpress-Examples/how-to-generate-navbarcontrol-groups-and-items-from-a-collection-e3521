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
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.NavBar
Imports System.Collections.ObjectModel
Imports NavBarMVVM.ViewModel
Imports NavBarMVVM.Helpers

Namespace NavBarMVVM
    Partial Public Class MainPage
        Inherits UserControl

        Public Sub New()
            DataContext = New TeamsViewModel(TeamsCreator.Teams)
            InitializeComponent()
        End Sub
    End Class
End Namespace
