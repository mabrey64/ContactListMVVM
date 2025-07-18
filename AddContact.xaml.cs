namespace ContactListMVVM
{
    public partial class AddContact : ContentPage
    {

        public AddContact()
        {
            InitializeComponent();
            BindingContext = new ContactListMVVM.ViewModels.AddContactViewModel();
        }
    }

}
