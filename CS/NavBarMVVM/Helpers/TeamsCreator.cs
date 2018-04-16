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
    public static class TeamsCreator {
        public static readonly Teams Teams;
        static TeamsCreator() {
            Teams = new Teams();
            Teams.Add(TeamCreator.Team[0]);
            Teams.Add(TeamCreator.Team[1]);
        }
    }
}