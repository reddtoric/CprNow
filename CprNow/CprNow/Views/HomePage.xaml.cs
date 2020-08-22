using System.ComponentModel;
using Xamarin.Forms;

namespace CprNow.Views
{
    [DesignTimeVisible(false)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //var viewModel = BindingContext as CprViewModel;

            //viewModel?.OnDisappearing();
        }
    }
}