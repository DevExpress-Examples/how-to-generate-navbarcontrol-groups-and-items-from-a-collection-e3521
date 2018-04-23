# How to: Generate NavBarControl Groups and Items from a Collection


<p>In MVVM scenarios, it's often necessary to generate elements from a collection. <a href="https://documentation.devexpress.com/WPF/clsDevExpressXpfNavBarNavBarControltopic.aspx">NavBarControl</a> provides such a capability via the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfNavBarNavBarControl_ItemsSourcetopic">ItemsSource</a> property. In this example, each object corresponding to NavBarGroup contains a sub-collection of items which will be visualized by <a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfNavBarNavBarItemtopic">NavBarItems</a>. This is sub-collection is bound to the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfNavBarNavBarGroup_ItemsSourcetopic">NavBarGroup.ItemsSource</a> property. <br><br>If you wish to group items without specifying NavBarGroup.ItemsSource, use the approach demonstrated at <a href="https://www.devexpress.com/Support/Center/p/T329230">How to: Generate NavBarControl Items from a Collection and Automatically Group Them Depending on a Field Value</a>.</p>

<br/>


