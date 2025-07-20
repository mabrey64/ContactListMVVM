using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactListMVVM.Classes;
using System.Collections.ObjectModel;
using AppContact = ContactListMVVM.Classes.Contact;


namespace ContactListMVVM.ViewModels
{
    public partial class ContactListViewModel : ObservableObject
    {
        private ObservableCollection<AppContact> sharedContacts;

        public ContactListViewModel(ObservableCollection<AppContact> contacts)
        {
            this.sharedContacts = contacts;
        }

        public ObservableCollection<AppContact> SharedContacts => sharedContacts;

        [ObservableProperty]
        private AppContact contact = new AppContact();
    }
}
