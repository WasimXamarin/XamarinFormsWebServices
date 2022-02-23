using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsWebServices.ViewModels;
using XamarinFormsWebServices.Views;

namespace XamarinFormsWebServices
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Settings = new BasicDataBindingViewModel(Current.Properties);

            MainPage = new NavigationPage(new ScannerPage());
        }

        public BasicDataBindingViewModel Settings { private set; get; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            Settings.SaveState(Current.Properties);
        }

        protected override void OnResume()
        {

        }
    }
}
