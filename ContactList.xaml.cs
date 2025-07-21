using ContactListMVVM;
using ContactListMVVM.ViewModels;
using ContactListMVVM.Classes;
using System.Collections.ObjectModel;

namespace ContactListMVVM
{
    public partial class ContactList : ContentPage
    {
        public ContactList()
        {
            InitializeComponent();
            /*
             * This is the constructor for the ContactList page.
             * It initializes the page and sets the BindingContext to an instance of ContactListViewModel,
             * The reason why we use the BindingContext is to enable data binding in the XAML.
             * The View's code-behind file (ContactList.xaml.cs) is responsible for setting up the view model
             * When it creates the ViewModel, it passes the globally shared SharedContacts collection
             * which is then stored in its own private field.
             */
            BindingContext = new ContactListViewModel(App.SharedContacts);
        }

        private async void OnContactTapped(object sender, ItemTappedEventArgs e)
        {
            /*
             * This method is called when an item in the ContactListView is tapped.
             * It retrieves the tapped contact and navigates to the ContactDetail page,
             * passing the selected contact as a query parameter.
             */
            if (e.Item is ContactListMVVM.Classes.Contact tappedContact)
            {
                System.Diagnostics.Debug.WriteLine($"Tapped: {tappedContact.Name}");
                await Shell.Current.Navigation.PushAsync(new ContactDetailPage(tappedContact));
                ((ListView)sender).SelectedItem = null; // Deselect after tap
            }
        }
        private async void OnAddContactClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContact());
        }

    }
}