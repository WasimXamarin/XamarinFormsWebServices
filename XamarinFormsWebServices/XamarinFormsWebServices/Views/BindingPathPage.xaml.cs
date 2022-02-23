using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;
using XamarinFormsWebServices.ViewModels;

namespace XamarinFormsWebServices.Views
{
    public partial class BindingPathPage : ContentPage
    {
        public BindingPathPage()
        {
            InitializeComponent();
            BindingContext = new BindingPathViewModel();
        }
    }
}
