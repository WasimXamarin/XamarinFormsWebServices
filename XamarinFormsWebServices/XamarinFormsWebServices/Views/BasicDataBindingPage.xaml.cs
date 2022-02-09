using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsWebServices.ViewModels;

namespace XamarinFormsWebServices.Views
{
    public partial class BasicDataBindingPage : ContentPage
    {
        public BasicDataBindingPage()
        {
            InitializeComponent();
            BindingContext = new BasicDataBindingViewModel();
        }
    }
}
