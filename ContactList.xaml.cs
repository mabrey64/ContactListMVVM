using ContactListMVVM;
using ContactListMVVM.ViewModels;

public partial class ContactList : ContentPage
{
    public ContactList()
    {
        InitializeComponent();
        var sharedContacts = ((App)Application.Current).SharedContacts;
        BindingContext = new ViewModels.ContactListViewModel(sharedContacts);
    }
}
