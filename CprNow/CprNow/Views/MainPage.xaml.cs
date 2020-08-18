using System;
using System.ComponentModel;
using CprNow.ViewModels;

namespace CprNow.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            //this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            try
            {
                var viewModel = Children[1].BindingContext as CprViewModel;

                viewModel?.StopTimer();
            }
            catch (Exception)
            {
            }
        }
    }
}