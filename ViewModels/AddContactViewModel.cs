using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactListMVVM.Classes;

namespace ContactListMVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private ObservableCollection<Classes.Contact> sharedContacts;

        /*
         * This event is used to notify the view that it should navigate back to the contact list page.
         * It is invoked when a new contact is successfully added. 
         * The reason why this is here is to allow the view model to communicate with the view
         * It acts as a signal or channel that connects to the MapsToContactsRequested method in the view.
         */
        public event Action NavigateToContactsRequested;

        public AddContactViewModel(ObservableCollection<Classes.Contact> contacts)
        {
            this.sharedContacts = contacts;
        }

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string phoneNumber;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string nameErrorMessage = "Name is required.";

        [ObservableProperty]
        private string phoneNumberErrorMessage = "Phone number is required.";

        [ObservableProperty]
        private string emailErrorMessage = "Email is required.";

        [ObservableProperty]
        private string descriptionErrorMessage = "Description is required.";

        [ObservableProperty]
        private bool isNameErrorVisible;

        [ObservableProperty]
        private bool isPhoneNumberErrorVisible;

        [ObservableProperty]
        private bool isEmailErrorVisible;

        [ObservableProperty]
        private bool isDescriptionErrorVisible;

        [ObservableProperty]
        private string resultMessage;


        [RelayCommand]
        //Note: Using [RelayCommand] appends "Command" to the method name, so the method name should be unique.
        private void AddContact()
        {
            // Validate input
            IsNameErrorVisible = false;
            IsPhoneNumberErrorVisible = false;
            IsEmailErrorVisible = false;
            IsDescriptionErrorVisible = false;
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(Name))
            {
                IsNameErrorVisible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                IsPhoneNumberErrorVisible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                IsEmailErrorVisible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                IsDescriptionErrorVisible = true;
                isValid = false;
            }
            if (!isValid)
            {
                ResultMessage = "Please fill in all required fields.";
                return; // Exit if validation fails
            }
            // Add the contact
            ContactListMVVM.Classes.Contact newContact = new ContactListMVVM.Classes.Contact(Name, PhoneNumber, Email, Description);
            sharedContacts.Add(newContact);
            ResultMessage = $"Name: {newContact.Name}\nPhone: {newContact.PhoneNumber}\nEmail: {newContact.Email}\nDescription: {newContact.Description}";

            Name = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Description = string.Empty;

            /*
             * This line invokes the NavigateToContactsRequested event, which is used to notify the view
             * that it should navigate back to the contact list page.
             * The view will handle this event and perform the navigation.
             * When this is called, the ViewModel is signaling a broadcast to the view that it should navigate to the contacts page.
             */
            NavigateToContactsRequested?.Invoke();


        }

        // The code below is commented out because it uses the old INotifyPropertyChanged interface. It can still work but is not necessary when using CommunityToolkit.Mvvm.ComponentModel.

            //public event PropertyChangedEventHandler? PropertyChanged;
            //private string _name;
            //public string Name
            //{
            //    get => _name;
            //    set
            //    {
            //        if (_name != value)
            //        {
            //            _name = value;
            //            OnPropertyChanged(nameof(Name));
            //        }
            //    }
            //}
            //private string _phoneNumber;
            //public string PhoneNumber
            //{
            //    get => _phoneNumber;
            //    set
            //    {
            //        if (_phoneNumber != value)
            //        {
            //            _phoneNumber = value;
            //            OnPropertyChanged(nameof(PhoneNumber));
            //        }
            //    }
            //}
            //private string _email;
            //public string Email
            //{
            //    get => _email;
            //    set
            //    {
            //        if (_email != value)
            //        {
            //            _email = value;
            //            OnPropertyChanged(nameof(Email));
            //        }
            //    }
            //}
            //private string _description;
            //public string Description
            //{
            //    get => _description;
            //    set
            //    {
            //        if (_description != value)
            //        {
            //            _description = value;
            //            OnPropertyChanged(nameof(Description));
            //        }
            //    }
            //}
            //protected virtual void OnPropertyChanged(string propertyName)
            //{
            //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}
    }
}
