<!-- default file list -->
*Files to look at*:

* [NavBarGroupWrapper.cs](./CS/DevExpress.Xpf.NavBar.Extensions/NavBarGroupWrapper.cs) (VB: [NavBarGroupWrapper.vb](./VB/DevExpress.Xpf.NavBar.Extensions/NavBarGroupWrapper.vb))
* [NavBarItemWrapper.cs](./CS/DevExpress.Xpf.NavBar.Extensions/NavBarItemWrapper.cs) (VB: [NavBarItemWrapper.vb](./VB/DevExpress.Xpf.NavBar.Extensions/NavBarItemWrapper.vb))
* [NavBarMVVMAttachedBehavior.cs](./CS/DevExpress.Xpf.NavBar.Extensions/NavBarMVVMAttachedBehavior.cs) (VB: [NavBarMVVMAttachedBehavior.vb](./VB/DevExpress.Xpf.NavBar.Extensions/NavBarMVVMAttachedBehavior.vb))
* [Generic.xaml](./CS/DevExpress.Xpf.NavBar.Extensions/Themes/Generic.xaml) (VB: [Generic.xaml](./VB/DevExpress.Xpf.NavBar.Extensions/Themes/Generic.xaml))
* [PersonCreator.cs](./CS/NavBarMVVM/Helpers/PersonCreator.cs) (VB: [PersonCreator.vb](./VB/NavBarMVVM/Helpers/PersonCreator.vb))
* [TeamCreator.cs](./CS/NavBarMVVM/Helpers/TeamCreator.cs) (VB: [TeamCreator.vb](./VB/NavBarMVVM/Helpers/TeamCreator.vb))
* [TeamsCreator.cs](./CS/NavBarMVVM/Helpers/TeamsCreator.cs) (VB: [TeamsCreator.vb](./VB/NavBarMVVM/Helpers/TeamsCreator.vb))
* [MainPage.xaml](./CS/NavBarMVVM/MainPage.xaml) (VB: [MainPage.xaml](./VB/NavBarMVVM/MainPage.xaml))
* [MainPage.xaml.cs](./CS/NavBarMVVM/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/NavBarMVVM/MainPage.xaml.vb))
* [MainWindow.xaml](./CS/NavBarMVVM/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/NavBarMVVM/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/NavBarMVVM/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/NavBarMVVM/MainWindow.xaml.vb))
* [Person.cs](./CS/NavBarMVVM/Model/Person.cs) (VB: [Persons.vb](./VB/NavBarMVVM/Model/Persons.vb))
* [Persons.cs](./CS/NavBarMVVM/Model/Persons.cs) (VB: [Persons.vb](./VB/NavBarMVVM/Model/Persons.vb))
* [Team.cs](./CS/NavBarMVVM/Model/Team.cs) (VB: [Team.vb](./VB/NavBarMVVM/Model/Team.vb))
* [Teams.cs](./CS/NavBarMVVM/Model/Teams.cs) (VB: [Teams.vb](./VB/NavBarMVVM/Model/Teams.vb))
* [MainView.SL.xaml](./CS/NavBarMVVM/View/MainView.SL.xaml) (VB: [MainView.SL.xaml](./VB/NavBarMVVM/View/MainView.SL.xaml))
* [MainView.xaml](./CS/NavBarMVVM/View/MainView.xaml) (VB: [MainView.xaml](./VB/NavBarMVVM/View/MainView.xaml))
* [MainView.xaml.cs](./CS/NavBarMVVM/View/MainView.xaml.cs) (VB: [MainView.xaml.vb](./VB/NavBarMVVM/View/MainView.xaml.vb))
* [PersonsViewModel.cs](./CS/NavBarMVVM/ViewModel/PersonsViewModel.cs) (VB: [PersonsViewModel.vb](./VB/NavBarMVVM/ViewModel/PersonsViewModel.vb))
* [PersonViewModel.cs](./CS/NavBarMVVM/ViewModel/PersonViewModel.cs) (VB: [PersonViewModel.vb](./VB/NavBarMVVM/ViewModel/PersonViewModel.vb))
* [TeamsViewModel.cs](./CS/NavBarMVVM/ViewModel/TeamsViewModel.cs) (VB: [TeamsViewModel.vb](./VB/NavBarMVVM/ViewModel/TeamsViewModel.vb))
* [TeamViewModel.cs](./CS/NavBarMVVM/ViewModel/TeamViewModel.cs) (VB: [TeamViewModel.vb](./VB/NavBarMVVM/ViewModel/TeamViewModel.vb))
* [ViewModelBase.cs](./CS/NavBarMVVM/ViewModel/ViewModelBase.cs) (VB: [ViewModelBase.vb](./VB/NavBarMVVM/ViewModel/ViewModelBase.vb))
<!-- default file list end -->
# How to: Generate NavBarControl Groups and Items from a Collection


<p>In MVVM scenarios, it's often necessary to generate elements from a collection. <a href="https://documentation.devexpress.com/WPF/clsDevExpressXpfNavBarNavBarControltopic.aspx">NavBarControl</a> provides such a capability via the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfNavBarNavBarControl_ItemsSourcetopic">ItemsSource</a> property. In this example, each object corresponding to NavBarGroup contains a sub-collection of items which will be visualized by <a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfNavBarNavBarItemtopic">NavBarItems</a>. This is sub-collection is bound to the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfNavBarNavBarGroup_ItemsSourcetopic">NavBarGroup.ItemsSource</a> property. <br><br>If you wish to group items without specifying NavBarGroup.ItemsSource, use the approach demonstrated at <a href="https://www.devexpress.com/Support/Center/p/T329230">How to: Generate NavBarControl Items from a Collection and Automatically Group Them Depending on a Field Value</a>.</p>

<br/>


