using ContactListMVVM.ViewModels;
using System.Collections.ObjectModel;
using ContactListMVVM.Classes;
using Microsoft.Maui.Controls;
using System;

namespace ContactListMVVM
{
    public partial class AddContact : ContentPage
    {
        public AddContact()
        {
            InitializeComponent();
            var addContactViewModel = new AddContactViewModel(App.SharedContacts);
            BindingContext = addContactViewModel;
            /*
             * The AddContactViewModel is responsible for handling the logic of adding a new contact.
             * It uses the SharedContacts collection to add the new contact.
             * The BindingContext is set to an instance of AddContactViewModel,
             * which allows the XAML to bind to properties and commands defined in the ViewModel.
             * Basically, this is where the ViewModel is connected to the View.
             */
            addContactViewModel.NavigateToContactsRequested += AddContactViewModel_NavigateToContactsRequested;
        }

        private async void AddContactViewModel_NavigateToContactsRequested()
        {
            /*
             * This method is called when the AddContactViewModel requests to navigate back to the contact list.
             * It uses Shell.Current.GoToAsync to navigate to the ContactList page.
             * The "//ContactList" syntax indicates that it should navigate to the root of the ContactList page.
             * It signfies an absolute route, which is the route of the Shell navigation system.
             */
            await Shell.Current.GoToAsync("//ContactListPage");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext is AddContactViewModel addContactViewModel)
            {
                addContactViewModel.NavigateToContactsRequested -= AddContactViewModel_NavigateToContactsRequested;
            }
        }
    }

}
