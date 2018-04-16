// Developer Express Code Central Example:
// How to use the DXNavBar in a MVVM application
// 
// This example demonstrates how to use the DXNavBar with MVVM patter using special
// attached behavior.
// See http://www.devexpress.com/scid=K18540 for more
// information.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3521

using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.Reflection;
using System.Windows.Data;
using System.Collections;
using DevExpress.Xpf.NavBar;
namespace NavBarExtensions {
    public class NavBarItemWrapper : Control, IDisposable {
        #region DP
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(NavBarItemWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty NavBarItemTemplateProperty =
            DependencyProperty.Register("NavBarItemTemplate", typeof(DataTemplate), typeof(NavBarItemWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavBarItemWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty NavBarItemIsVisibleProperty =
            DependencyProperty.Register("NavBarItemIsVisible", typeof(bool), typeof(NavBarItemWrapper), new PropertyMetadata(true));
        
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(NavBarItemWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(NavBarItemWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(NavBarItemWrapper), new PropertyMetadata(null));

        public object Content {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public DataTemplate NavBarItemTemplate {
            get { return (DataTemplate)GetValue(NavBarItemTemplateProperty); }
            set { SetValue(NavBarItemTemplateProperty, value); }
        }
        public ImageSource ImageSource {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public bool NavBarItemIsVisible {
            get { return (bool)GetValue(NavBarItemIsVisibleProperty); }
            set { SetValue(NavBarItemIsVisibleProperty, value); }
        }
        public ICommand Command {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public object CommandParameter {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public IInputElement CommandTarget {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }
        #endregion
        public NavBarItem NavBarItem { get; private set; }
        internal NavBarItemWrapper(Style style, NavBarItem navBarItem, object dataObject) {
            NavBarMVVMAttachedBehavior.SetNavBarItemStyler(navBarItem, this);
            DefaultStyleKey = typeof(NavBarItemWrapper);
            if(style != null) Style = style;
            DataContext = dataObject;
            NavBarItem = navBarItem;
        }
        internal void Init() {
            SetProperties();
        }
        void IDisposable.Dispose() {
            NavBarMVVMAttachedBehavior.SetNavBarItemStyler(NavBarItem, null);
            DataContext = null;
            NavBarItem = null;
            ClearProperties();
        }

        void SetProperties() {
            BindingOperations.SetBinding(NavBarItem, NavBarItem.ContentProperty, new Binding("Content") { Source = this });
            BindingOperations.SetBinding(NavBarItem, NavBarItem.TemplateProperty, new Binding("NavBarItemTemplate") { Source = this });
            BindingOperations.SetBinding(NavBarItem, NavBarItem.ImageSourceProperty, new Binding("ImageSource") { Source = this });
            BindingOperations.SetBinding(NavBarItem, NavBarItem.IsVisibleProperty, new Binding("NavBarItemIsVisible") { Source = this });
            BindingOperations.SetBinding(NavBarItem, NavBarItem.CommandProperty, new Binding("Command") { Source = this });
            BindingOperations.SetBinding(NavBarItem, NavBarItem.CommandParameterProperty, new Binding("CommandParameter") { Source = this });
            BindingOperations.SetBinding(NavBarItem, NavBarItem.CommandTargetProperty, new Binding("CommandTarget") { Source = this });
        }
        void ClearProperties() {
            NavBarItem.ClearValue(NavBarItem.ContentProperty);
            NavBarItem.ClearValue(NavBarItem.TemplateProperty);
            NavBarItem.ClearValue(NavBarItem.ImageSourceProperty);
            NavBarItem.ClearValue(NavBarItem.IsVisibleProperty);

            NavBarItem.ClearValue(NavBarItem.CommandProperty);
            NavBarItem.ClearValue(NavBarItem.CommandParameterProperty);
            NavBarItem.ClearValue(NavBarItem.CommandTargetProperty);
        }
    }
}