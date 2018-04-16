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
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging

Namespace NavBarMVVM.ViewModel
    Public Class PersonViewModel
        Inherits ViewModelBase

        Public Property Name() As String
            Get
                Return Person.Name
            End Get
            Set(ByVal value As String)
                If Person.Name = value Then
                    Return
                End If
                Person.Name = value
                OnPropertyChanged("Name")
            End Set
        End Property
        Public Property Photo() As Uri
            Get
                Return Person.Photo
            End Get
            Set(ByVal value As Uri)
                If Person.Photo = value Then
                    Return
                End If
                Person.Photo = value
                OnPropertyChanged("Photo")
                OnPropertyChanged("PhotoImageSource")
            End Set
        End Property
        Public ReadOnly Property PhotoImageSource() As ImageSource
            Get
#If SILVERLIGHT Then
                Dim conv As New ImageSourceConverter()
                Return DirectCast(conv.ConvertFrom(Photo), ImageSource)
#Else
                Return New BitmapImage(Photo)
#End If
            End Get
        End Property
        Private privatePerson As Person
        Public Property Person() As Person
            Get
                Return privatePerson
            End Get
            Private Set(ByVal value As Person)
                privatePerson = value
            End Set
        End Property

        Public Sub New(ByVal person As Person)
            Me.Person = person
        End Sub
    End Class
End Namespace
