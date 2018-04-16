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

namespace NavBarMVVM.Model {
    public class Team {
        public string Caption = string.Empty;
        public readonly Persons Persons;
        public Team() {
            Persons = new Persons();
        }
    }
}
