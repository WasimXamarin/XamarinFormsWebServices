using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsWebServices.ViewModels;

namespace XamarinFormsWebServices.Views
{
    public partial class StringFormattingPage : ContentPage
    {
        public StringFormattingPage()
        {
            InitializeComponent();
            BindingContext = new StringFormattingViewModel();
        }
    }
}
