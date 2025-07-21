namespace ContactListMVVM;
using ContactListMVVM.ViewModels;
using Microsoft.Maui.Controls;
using ContactListMVVM.Classes;

public partial class ContactDetailPage : ContentPage
{
	public ContactDetailPage(ContactListMVVM.Classes.Contact contact)
	{ 
		InitializeComponent();
		BindingContext = contact;
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}