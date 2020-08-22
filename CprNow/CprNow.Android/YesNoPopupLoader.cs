using Android.App;
using CprNow.Custom;
using CprNow.Droid.Implementation;
using Xamarin.Forms;

[assembly: Dependency(typeof(YesNoPopupLoader))]

namespace CprNow.Droid.Implementation
{
    public class YesNoPopupLoader : IYesNoPopupLoader
    {
        public void ShowPopup(CustomYesNoBox popup)
        {
            var alert = new AlertDialog.Builder(MainActivity.Instance, Resource.Style.Theme_AppCompat_Light_Dialog_Alert);

            alert.SetTitle(popup.Title);
            alert.SetMessage(popup.Text);

            var buttons = popup.Buttons;

            alert.SetPositiveButton(buttons[0], (senderAlert, args) =>
            {
                popup.OnPopupClosed(new CustomYesNoBoxClosedArgs
                {
                    Button = buttons[0]
                });
            });

            alert.SetNegativeButton(buttons[1], (senderAlert, args) =>
            {
                popup.OnPopupClosed(new CustomYesNoBoxClosedArgs
                {
                    Button = buttons[1]
                });
            });

            alert.SetCancelable(false);
            alert.Show();
        }
    }
}