using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XamarinFormsWebServices.ViewModels
{
    public class ScannerViewModel : BaseViewModel
    {
        public ICommand QRCodeCommand { private set; get; }
        public ScannerViewModel()
        {
            Title = "Scanner";
            QRCodeCommand = new Command(OnQRCodeClcik);
        }

        private string _BarCodeValue;
        public string BarCodeValue
        {
            get { return _BarCodeValue; }
            set { SetProperty(ref _BarCodeValue, value); }
        }

        private async void OnQRCodeClcik(object obj)
        {
            try
            {
                var scanPage = new ZXingScannerPage();
                await Application.Current.MainPage.Navigation.PushAsync(scanPage);
                scanPage.Title = "Scanner Custom";
                scanPage.OnScanResult += async (result) =>
                {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PopAsync();
                        if (result != null)
                        {
                            BarCodeValue = result.Text;
                        }
                    });
                };
            }
            catch (Exception ex)
            {

            }
        }
    }
}
