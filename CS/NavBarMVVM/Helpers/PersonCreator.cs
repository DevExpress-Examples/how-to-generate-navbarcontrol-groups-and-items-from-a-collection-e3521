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
using NavBarMVVM.Model;
using System.Windows.Media.Imaging;

namespace NavBarMVVM.Helpers {
    public static class PersonCreator {
        public static readonly Person[] Person;

        static PersonCreator() {
            Person = new Person[4];
            Person[0] = new Person() {
                Name = "Anne Dodsworth",
                Photo = new Uri("/NavBarMVVM;component/Images/AnneDodsworth.jpg", UriKind.Relative),
            };
            Person[1] = new Person() {
                Name = "Nancy Davolio",
                Photo = new Uri("/NavBarMVVM;component/Images/NancyDavolio.jpg", UriKind.Relative),
            };
            Person[2] = new Person() {
                Name = "Robert King",
                Photo = new Uri("/NavBarMVVM;component/Images/RobertKing.jpg", UriKind.Relative),
            };
            Person[3] = new Person() {
                Name = "Steven Buchanan",
                Photo = new Uri("/NavBarMVVM;component/Images/StevenBuchanan.jpg", UriKind.Relative),
            };
        }
    }
}
