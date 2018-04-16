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
using System.Collections.Specialized;
using DevExpress.Xpf.NavBar;
namespace NavBarExtensions {
    public class NavBarGroupWrapper : Control, IDisposable {
        #region DP
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty ContentTemplateProperty =
            DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(NavBarGroupWrapper), new PropertyMetadata(string.Empty));
		public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(NavBarGroupWrapper), new PropertyMetadata(null));

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty DisplaySourceProperty =
            DependencyProperty.Register("DisplaySource", typeof(DisplaySource), typeof(NavBarGroupWrapper), new PropertyMetadata(DisplaySource.Items));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(NavBarGroupWrapper), new PropertyMetadata(null));

		public static readonly DependencyProperty NavBarGroupIsVisibleProperty =
            DependencyProperty.Register("NavBarGroupIsVisible", typeof(bool), typeof(NavBarGroupWrapper), new PropertyMetadata(true));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(NavBarItem), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
		public static readonly DependencyProperty SelectedItemIndexProperty =
            DependencyProperty.Register("SelectedItemIndex", typeof(int), typeof(NavBarGroupWrapper), new PropertyMetadata(ConstantHelper.InvalidIndex));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(NavBarGroupWrapper), new PropertyMetadata(null));
        
        public object Content {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public DataTemplate ContentTemplate {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }
        public object Header {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public DataTemplate HeaderTemplate {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }
        public ImageSource ImageSource {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public DisplaySource DisplaySource {
            get { return (DisplaySource)GetValue(DisplaySourceProperty); }
            set { SetValue(DisplaySourceProperty, value); }
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
        public bool NavBarGroupIsVisible {
            get { return (bool)GetValue(NavBarGroupIsVisibleProperty); }
            set { SetValue(NavBarGroupIsVisibleProperty, value); }
        }
        public NavBarItem SelectedItem {
            get { return (NavBarItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public int SelectedItemIndex {
            get { return (int)GetValue(SelectedItemIndexProperty); }
            set { SetValue(SelectedItemIndexProperty, value); }
        }
        public IEnumerable ItemsSource {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        #endregion
        public delegate void NavBarItemsCollectionChangedEventHandler(NavBarGroupWrapper groupStyler, NotifyCollectionChangedEventArgs e, bool isDisposing);
        public event NavBarItemsCollectionChangedEventHandler NavBarItemsCollectionChanged;
        public SynchronizedNavBarItemCollection NavBarItems { get { return NavBarGroup.SynchronizedItems; } }
        public NavBarGroup NavBarGroup { get; private set; }

        internal NavBarGroupWrapper(Style style, NavBarGroup navBarGroup, object dataObject) {
            NavBarMVVMAttachedBehavior.SetNavBarGroupStyler(navBarGroup, this);
            DefaultStyleKey = typeof(NavBarGroupWrapper);
            if(style != null) Style = style;
            DataContext = dataObject;
            NavBarGroup = navBarGroup;
        }
        internal void Init() {
            Subscribe();
            SetProperties();
        }
        void IDisposable.Dispose() {
            Unsubscribe();
            if(NavBarItemsCollectionChanged != null) NavBarItemsCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset), true);
            NavBarMVVMAttachedBehavior.SetNavBarGroupStyler(NavBarGroup, null);
            DataContext = null;
            NavBarGroup = null;
            ClearProperties();
        }

        internal object GetNavBarItemDataObject(NavBarItem item) {
            //int index = NavBarItems.IndexOf(item);
            //if(NavBarGroup.Items[index] == item)
            //    return null;
            //return NavBarGroup.Items[index];
#if SILVERLIGHT
            return item.Content;
#else
            return ((DevExpress.Xpf.Core.DXFrameworkContentElement)(item)).DataContext;
#endif
        }
        void OnNavBarItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if(NavBarItemsCollectionChanged != null) NavBarItemsCollectionChanged(this, e, false);
        }

        void Subscribe() {
            NavBarItems.CollectionChanged += OnNavBarItemsCollectionChanged;
        }
        void Unsubscribe() {
            NavBarItems.CollectionChanged -= OnNavBarItemsCollectionChanged;
        }
        void SetProperties() {
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ContentProperty, new Binding("Content") { Source = this });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ContentTemplateProperty, new Binding("ContentTemplate") { Source = this });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.HeaderProperty, new Binding("Header") { Source = this });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.HeaderTemplateProperty, new Binding("HeaderTemplate") { Source = this });

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ImageSourceProperty, new Binding("ImageSource") { Source = this });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.DisplaySourceProperty, new Binding("DisplaySource") { Source = this });

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.CommandProperty, new Binding("Command") { Source = this });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.CommandParameterProperty, new Binding("CommandParameter") { Source = this });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.CommandTargetProperty, new Binding("CommandTarget") { Source = this });

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.IsVisibleProperty, new Binding("NavBarIsVisible") { Source = this, Mode = BindingMode.TwoWay });

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.SelectedItemProperty, new Binding("SelectedItem") { Source = this, Mode = BindingMode.TwoWay });
            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.SelectedItemIndexProperty, new Binding("SelectedItemIndex") { Source = this, Mode = BindingMode.TwoWay });

            BindingOperations.SetBinding(NavBarGroup, NavBarGroup.ItemsSourceProperty, new Binding("ItemsSource") { Source = this });
        }
        void ClearProperties() {
            NavBarGroup.ClearValue(NavBarGroup.ContentProperty);
            NavBarGroup.ClearValue(NavBarGroup.ContentTemplateProperty);
            NavBarGroup.ClearValue(NavBarGroup.HeaderProperty);
            NavBarGroup.ClearValue(NavBarGroup.HeaderTemplateProperty);

            NavBarGroup.ClearValue(NavBarGroup.ImageSourceProperty);
            NavBarGroup.ClearValue(NavBarGroup.DisplaySourceProperty);

            NavBarGroup.ClearValue(NavBarGroup.CommandProperty);
            NavBarGroup.ClearValue(NavBarGroup.CommandParameterProperty);
            NavBarGroup.ClearValue(NavBarGroup.CommandTargetProperty);

            NavBarGroup.ClearValue(NavBarGroup.IsVisibleProperty);

            NavBarGroup.ClearValue(NavBarGroup.SelectedItemProperty);
            NavBarGroup.ClearValue(NavBarGroup.SelectedItemIndexProperty);

            NavBarGroup.ClearValue(NavBarGroup.ItemsSourceProperty);
        }
    }
}