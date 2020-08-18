using System;
using System.Collections.Generic;
using System.ComponentModel;
using CprNow.Custom;
using CprNow.Services;
using Xamarin.Forms;

namespace CprNow.Views
{
    [DesignTimeVisible(false)]
    public partial class CheckListPage : ContentPage
    {
        private readonly PreferenceSettings preferenceSettings = PreferenceSettings.Instance;

        public CheckListPage()
        {
            InitializeComponent();
            DisplayDisclaimer();
        }

        private void DisplayDisclaimer()
        {
            if (!preferenceSettings.GetDisclaimerAgreement())
            {
                string msg = "The information provided in this application is not a substitute for professional healthcare advice." + Environment.NewLine + Environment.NewLine +
                   "Ed Devs is not responsible or liable for any mishaps, reliability issues, or accuracy issues from using this app." + Environment.NewLine + Environment.NewLine +
                   "Please familiarize and verify this app before using in an actual chest compression-only CPR situation.";

                string disagree = "Disagree and quit";
                string agree = "Agree";

                var popup = new CustomYesNoBox("Terms and Conditions", msg)
                {
                    Buttons = new List<string> { agree, disagree }
                };

                popup.PopupClosed += (o, closedArgs) =>
                {
                    if (closedArgs.Button == agree)
                    {
                        preferenceSettings.SetDisclaimerAgreement(true);
                    }
                    else if (closedArgs.Button == disagree)
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                    }
                };

                popup.Show();
            }
        }

        private void GoToCprPage(object sender, EventArgs e)
        {
            DependencyService.Get<ISoundService>().PlayClick();

            var tab = this.Parent.Parent as TabbedPage;
            tab.CurrentPage = tab.Children[1];
        }
    }
}