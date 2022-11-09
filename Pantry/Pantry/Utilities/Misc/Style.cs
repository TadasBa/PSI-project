using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace Pantry.models
{
    static class Style
    {
        public static readonly ToastOptions ToastError = new ToastOptions();
        public static readonly ToastOptions ToastSuccess = new ToastOptions();

        static Style()
        {
            ToastError.MessageOptions.Foreground = Color.Red;
            ToastError.MessageOptions.Message = "Error Occured While Creating Product";
            ToastError.BackgroundColor = Color.Black;

            ToastSuccess.MessageOptions.Foreground = Color.Green;
            ToastSuccess.MessageOptions.Message = "Product Created Succesfully";
            ToastSuccess.BackgroundColor = Color.Black;
        }
    }
}
