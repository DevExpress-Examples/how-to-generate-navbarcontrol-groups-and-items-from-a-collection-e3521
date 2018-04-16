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
using System.Text;
using NavBarMVVM.Model;

namespace NavBarMVVM.ViewModel {
    public class TeamViewModel : ViewModelBase {
        public String Caption {
            get { return Team.Caption; }
            set {
                if(Team.Caption == value) return;
                Team.Caption = value;
                OnPropertyChanged("Caption");
            }
        }
        public PersonsViewModel PersonsViewModel { get; private set; }
        public Team Team { get; private set; }
        public TeamViewModel(Team team) {
            Team = team;
            PersonsViewModel = new PersonsViewModel(Team.Persons);
        }
    }
}
