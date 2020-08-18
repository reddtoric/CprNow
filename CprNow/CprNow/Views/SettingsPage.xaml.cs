using System;
using System.ComponentModel;
using CprNow.Services;
using CprNow.ViewModels;
using Xamarin.Forms;

namespace CprNow.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //temp
            /*try
            {
                soundService.Click();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex);
            }*/
        }

        private void Slider_DragStarted(object sender, EventArgs e)
        {
            DependencyService.Get<ISoundService>().PlayBeep();
        }
    }
}