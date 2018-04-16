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
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NavBarMVVM.ViewModel {
    public class PersonViewModel : ViewModelBase {
        public String Name {
            get { return Person.Name; }
            set {
                if(Person.Name == value) return;
                Person.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public Uri Photo {
            get { return Person.Photo; }
            set {
                if(Person.Photo == value) return;
                Person.Photo = value;
                OnPropertyChanged("Photo");
                OnPropertyChanged("PhotoImageSource");
            }
        }
        public ImageSource PhotoImageSource {
            get {
#if SILVERLIGHT
                ImageSourceConverter conv = new ImageSourceConverter();
                return (ImageSource)conv.ConvertFrom(Photo);
#else
                return new BitmapImage(Photo);
#endif
            }
        }
        public Person Person { get; private set; }

        public PersonViewModel(Person person) {
            Person = person;
        }
    }
}
