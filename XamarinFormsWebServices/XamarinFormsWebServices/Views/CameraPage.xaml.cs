using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsWebServices.ViewModels;

namespace XamarinFormsWebServices.Views
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
            BindingContext = new CameraViewModel();
        }
    }
}
