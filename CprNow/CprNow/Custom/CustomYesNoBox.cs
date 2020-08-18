using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CprNow.Custom
{
    public interface IYesNoPopupLoader
    {
        void ShowPopup(CustomYesNoBox reference);
    }

    public class CustomYesNoBox
    {
        public CustomYesNoBox(string title, string text, params string[] buttons)
        {
            Title = title;
            Text = text;
            Buttons = buttons.ToList();
        }

        public CustomYesNoBox(string title, string text) : this(title, text, "Yes", "No")
        {
        }

        public event EventHandler<CustomYesNoBoxClosedArgs> PopupClosed;

        public List<string> Buttons { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public void OnPopupClosed(CustomYesNoBoxClosedArgs e)
        {
            PopupClosed?.Invoke(this, e);
        }

        public void Show()
        {
            DependencyService.Get<IYesNoPopupLoader>().ShowPopup(this);
        }
    }

    public class CustomYesNoBoxClosedArgs : EventArgs
    {
        public string Button { get; set; }
    }
}