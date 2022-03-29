using System;
using Xamarin.Forms;
using System.Web;

namespace XamarinFormsWebServices.ViewModels
{
    public class PickerViewModel : BaseViewModel
    {
        public PickerViewModel()
        {
            Title = "Picker Page";
        }

        public Command PhotoCommand
        {
            get
            {
                return new Command(OnPhotoClicked);
            }
        }

        private void OnPhotoClicked(object obj)
        {
            ProfileImage = "https://source.unsplash.com/user/c_v_r/1900x800";
            //ProfileImage = "https://picsum.photos/200/300";
        }

        private ImageSource _ProfileImage;
        public ImageSource ProfileImage
        {
            get { return _ProfileImage; }
            set { SetProperty(ref _ProfileImage, value); }
        }
    }
}
