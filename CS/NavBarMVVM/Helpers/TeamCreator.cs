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

namespace NavBarMVVM.Helpers {
    public static class TeamCreator {
        public static readonly Team[] Team;

        static TeamCreator() {
            Team = new Team[2];
            Team[0] = new Team() {
                Caption = "Documentation Team",
            };
            Team[0].Persons.Add(PersonCreator.Person[0]);
            Team[0].Persons.Add(PersonCreator.Person[1]);

            Team[1] = new Team() {
                Caption = "Management Team",
            };
            Team[1].Persons.Add(PersonCreator.Person[2]);
            Team[1].Persons.Add(PersonCreator.Person[3]);
        }
    }
}
