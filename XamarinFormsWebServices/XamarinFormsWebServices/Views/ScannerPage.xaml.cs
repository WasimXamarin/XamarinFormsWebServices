using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsWebServices.ViewModels;

namespace XamarinFormsWebServices.Views
{
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
            BindingContext = new ScannerViewModel();
        }
    }
}
