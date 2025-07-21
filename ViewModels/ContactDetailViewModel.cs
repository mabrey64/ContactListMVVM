using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListMVVM.Classes;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace ContactListMVVM.ViewModels
{
    public partial class ContactDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private ContactListMVVM.Classes.Contact selectedContact;

        public ContactDetailViewModel(ContactListMVVM.Classes.Contact contact)
        {
            SelectedContact = contact;
        }
    }
}
