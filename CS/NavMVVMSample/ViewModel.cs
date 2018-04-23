using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavMVVMSample
{
    public class ViewModel
    {
        public ObservableCollection<Group> Groups
        {
            get;
            set;
        }

        public ViewModel()
        {
            Groups = new ObservableCollection<Group>();
            Group group = new Group() { Caption = "Group1" };
            group.GroupItems = new ObservableCollection<Item>();
            group.GroupItems.Add(new Item() { Content = "Item1_1" });
            group.GroupItems.Add(new Item() { Content = "Item1_2" });
            group.GroupItems.Add(new Item() { Content = "Item1_3" });
            Groups.Add(group);

            group = new Group() { Caption = "Group2" };
            group.GroupItems = new ObservableCollection<Item>();
            group.GroupItems.Add(new Item() { Content = "Item2_1" });
            group.GroupItems.Add(new Item() { Content = "Item2_2" });
            Groups.Add(group);

        }
    }

    public class Item
    {
        public string Content
        {
            get;
            set;
        }
    }

    public class Group
    {
        public ObservableCollection<Item> GroupItems
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }
    }
}
