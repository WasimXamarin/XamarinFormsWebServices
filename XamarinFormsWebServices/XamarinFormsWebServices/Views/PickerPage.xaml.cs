using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsWebServices.ViewModels;

namespace XamarinFormsWebServices.Views
{
    public partial class PickerPage : ContentPage
    {
        public PickerPage()
        {
            InitializeComponent();
            BindingContext = new PickerViewModel();
        }
    }
}
