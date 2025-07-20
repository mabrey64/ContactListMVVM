using System;
using System.Collections.ObjectModel;

namespace ContactListMVVM
{
    public partial class App : Application
    {
        /*
         * The SharedContacts collection is used to store contacts that can be accessed
         * throughout the application. It is initialized in the App constructor.
         * This allows different pages and view models to share the same contact list.
         * Having it here ensures that the contact list is available globally
         * And a good note of what to do with anything that should be shared globally.
         */
        public static ObservableCollection<Classes.Contact> SharedContacts { get; private set; }
        public App()
        {
            InitializeComponent();
            SharedContacts = new ObservableCollection<Classes.Contact>();
            MainPage = new AppShell();
        }
    }
}