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

using System.Windows.Interactivity;
using System.Windows;
using System.Collections;
using System.Collections.Specialized;
using System;
using System.Windows.Data;
using DevExpress.Xpf.NavBar;
namespace NavBarExtensions {
    public class NavBarMVVMAttachedBehavior : Behavior<NavBarControl> {
        #region DP
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(NavBarMVVMAttachedBehavior),
            new PropertyMetadata(null, (d,e) => ((NavBarMVVMAttachedBehavior)d).OnItemsSourceChanged((IEnumerable)e.OldValue)));
        public static readonly DependencyProperty GroupStyleProperty =
            DependencyProperty.Register("GroupStyle", typeof(Style), typeof(NavBarMVVMAttachedBehavior), new PropertyMetadata(null));
        public static readonly DependencyProperty ItemStyleProperty =
            DependencyProperty.Register("ItemStyle", typeof(Style), typeof(NavBarMVVMAttachedBehavior), new PropertyMetadata(null));

        public static readonly DependencyProperty NavBarGroupStylerProperty =
            DependencyProperty.RegisterAttached("NavBarGroupStyler", typeof(NavBarGroupWrapper), typeof(NavBarMVVMAttachedBehavior), new PropertyMetadata(null));
        public static readonly DependencyProperty NavBarItemStylerProperty =
            DependencyProperty.RegisterAttached("NavBarItemStyler", typeof(NavBarItemWrapper), typeof(NavBarMVVMAttachedBehavior), new PropertyMetadata(null));
        public static NavBarGroupWrapper GetNavBarGroupStyler(NavBarGroup obj) {
            return (NavBarGroupWrapper)obj.GetValue(NavBarGroupStylerProperty);
        }
        public static void SetNavBarGroupStyler(NavBarGroup obj, NavBarGroupWrapper value) {
            obj.SetValue(NavBarGroupStylerProperty, value);
        }
        public static NavBarItemWrapper GetNavBarItemStyler(NavBarItem obj) {
            return (NavBarItemWrapper)obj.GetValue(NavBarItemStylerProperty);
        }
        public static void SetNavBarItemStyler(NavBarItem obj, NavBarItemWrapper value) {
            obj.SetValue(NavBarItemStylerProperty, value);
        }

        public IEnumerable ItemsSource {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public Style GroupStyle {
            get { return (Style)GetValue(GroupStyleProperty); }
            set { SetValue(GroupStyleProperty, value); }
        }
        public Style ItemStyle {
            get { return (Style)GetValue(ItemStyleProperty); }
            set { SetValue(ItemStyleProperty, value); }
        }
        #endregion
        public NavBarGroup GetNavBarGroupContainerFromItem(object data) {
            if(!IsInitialized) return null;
            foreach(NavBarGroup gr in NavBar.Groups)
                if(gr.DataContext == data) return gr;
            return null;
        }
        public object GetItemFromNavBarGroupContainer(NavBarGroup gr) {
            return gr.DataContext;
        }

        protected NavBarControl NavBar { get { return AssociatedObject; } }
        protected bool IsInitialized { get; private set; }
        
        protected override void OnAttached() {
            base.OnAttached();
            if(!IsInitialized) {
                TryInitialize();
                return;
            }
        }
        protected override void OnDetaching() {
            base.OnDetaching();
            if(ItemsSource is INotifyCollectionChanged) ((INotifyCollectionChanged)ItemsSource).CollectionChanged -= OnItemsSourceCollectionChanged;
            ClearNavBarGroups();
            IsInitialized = false;
        }
        protected virtual void OnItemsSourceChanged(IEnumerable oldSource) {
            if(!IsInitialized) {
                TryInitialize();
                return;
            }
            if(oldSource is INotifyCollectionChanged) ((INotifyCollectionChanged)oldSource).CollectionChanged -= OnItemsSourceCollectionChanged;
            ClearNavBarGroups();
            if(ItemsSource == null) {
                IsInitialized = false;
                return;
            }
            foreach(object obj in ItemsSource) AddNavBarGroup(obj);
            if(ItemsSource is INotifyCollectionChanged) ((INotifyCollectionChanged)ItemsSource).CollectionChanged += OnItemsSourceCollectionChanged;
        }
        void TryInitialize() {
            if(IsInitialized) return;
            if(NavBar == null || ItemsSource == null) return;
            IsInitialized = true;
            foreach(object obj in ItemsSource) AddNavBarGroup(obj);
            if(ItemsSource is INotifyCollectionChanged) ((INotifyCollectionChanged)ItemsSource).CollectionChanged += OnItemsSourceCollectionChanged;
        }
        void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if(e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null) {
                for(int i = 0; i < e.NewItems.Count; i++)
                    if(e.NewStartingIndex == -1) AddNavBarGroup(e.NewItems[i]);
                    else AddNavBarGroup(e.NewItems[i], i + e.NewStartingIndex);
            }
            if(e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null) {
                for(int i = 0; i < e.OldItems.Count; i++) RemoveNavBarGroup(e.OldItems[i]);
            }
            if(e.Action == NotifyCollectionChangedAction.Replace) {
                if(e.OldItems != null)
                    for(int i = 0; i < e.OldItems.Count; i++) RemoveNavBarGroup(e.OldItems[i]);
                if(e.NewItems != null)
                    for(int i = 0; i < e.NewItems.Count; i++) {
                        if(e.NewStartingIndex == -1) AddNavBarGroup(e.NewItems[i]);
                        else AddNavBarGroup(e.NewItems[i], i + e.NewStartingIndex);
                    }
            }
            if(e.Action == NotifyCollectionChangedAction.Reset)
                ClearNavBarGroups();
        }

        void ClearNavBarGroups() {
            if(!IsInitialized) return;
            foreach(NavBarGroup gr in NavBar.Groups)
                RemoveNavBarGroup(gr);
        }
        void AddNavBarGroup(object obj) {
            if(!IsInitialized) return;
            NavBar.Groups.Add(CreateNavBarGroup(obj));
        }
        void AddNavBarGroup(object obj, int index) {
            if(!IsInitialized) return;
            NavBar.Groups.Insert(index, CreateNavBarGroup(obj));
        }
        void RemoveNavBarGroup(object obj) {
            if(!IsInitialized) return;
            RemoveNavBarGroup(GetNavBarGroupContainerFromItem(obj));
        }
        void RemoveNavBarGroup(NavBarGroup gr) {
            NavBarGroupWrapper styler = NavBarMVVMAttachedBehavior.GetNavBarGroupStyler(gr);
            ((IDisposable)styler).Dispose();
            styler.NavBarItemsCollectionChanged -= OnStylerNavBarItemsCollectionChanged;
        }
        NavBarGroup CreateNavBarGroup(object obj) {
            NavBarGroup gr = new NavBarGroup() { DataContext = obj };
            NavBarGroupWrapper styler = new NavBarGroupWrapper(GroupStyle, gr, obj);
            styler.NavBarItemsCollectionChanged += OnStylerNavBarItemsCollectionChanged;
            styler.Init();
            return gr;
        }

        protected virtual void OnGroupItemAdding(NavBarItem item, object dataObject) {
            NavBarItemWrapper styler = new NavBarItemWrapper(ItemStyle, item, dataObject);
            styler.Init();
        }
        protected virtual void OnGroupItemRemoving(NavBarItem item, object dataObject) {
            NavBarItemWrapper styler = NavBarMVVMAttachedBehavior.GetNavBarItemStyler(item);
            ((IDisposable)styler).Dispose();
        }
        
        void OnStylerNavBarItemsCollectionChanged(NavBarGroupWrapper groupStyler, NotifyCollectionChangedEventArgs e, bool isDisposing) {
            if(e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null) {
                foreach(NavBarItem item in e.NewItems)
                    OnGroupItemAdding(item, groupStyler.GetNavBarItemDataObject(item));
            }
            if(e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null) {
                foreach(NavBarItem item in e.OldItems)
                    OnGroupItemRemoving(item, groupStyler.GetNavBarItemDataObject(item));
            }
            if(e.Action == NotifyCollectionChangedAction.Replace) {
                if(e.OldItems != null) {
                    foreach(NavBarItem item in e.OldItems)
                        OnGroupItemRemoving(item, groupStyler.GetNavBarItemDataObject(item));
                }
                if(e.NewItems != null) {
                    foreach(NavBarItem item in e.NewItems)
                        OnGroupItemAdding(item, groupStyler.GetNavBarItemDataObject(item));
                }
            }
            if(e.Action == NotifyCollectionChangedAction.Reset) {
                foreach(NavBarItem item in groupStyler.NavBarItems)
                    OnGroupItemRemoving(item, groupStyler.GetNavBarItemDataObject(item));
                if(!isDisposing) {
                    foreach(NavBarItem item in groupStyler.NavBarItems)
                        OnGroupItemAdding(item, groupStyler.GetNavBarItemDataObject(item));
                }
            }
        }
    }
}