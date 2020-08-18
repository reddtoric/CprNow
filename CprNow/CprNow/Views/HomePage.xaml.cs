using System;
using System.ComponentModel;
using CprNow.Services;
using CprNow.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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