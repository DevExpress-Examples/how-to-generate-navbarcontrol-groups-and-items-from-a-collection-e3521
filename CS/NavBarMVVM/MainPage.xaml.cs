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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.NavBar;
using System.Collections.ObjectModel;
using NavBarMVVM.ViewModel;
using NavBarMVVM.Helpers;

namespace NavBarMVVM {
    public partial class MainPage : UserControl {
        public MainPage() {
            DataContext = new TeamsViewModel(TeamsCreator.Teams);
            InitializeComponent();
        }
    }
}
