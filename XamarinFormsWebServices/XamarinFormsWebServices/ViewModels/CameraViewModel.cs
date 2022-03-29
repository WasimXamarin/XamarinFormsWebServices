using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Windows.Input;
using System.IO;
using System.Threading.Tasks;
using Acr.UserDialogs;
using XamarinFormsWebServices.Models;

namespace XamarinFormsWebServices.ViewModels
{
    public class CameraViewModel : BaseViewModel
    {
        public CameraViewModel()
        {
            Title = "Camera";
        }

        public Command UploadProfileCommand
        {
            get { return new Command(UploadProfileClicked); }
        }

        private async void UploadProfileClicked(object obj)
        {
            _ =NewUploadProfile();
        }

        async Task NewUploadProfile()
        {
            try
            {
                var permissions = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (permissions != PermissionStatus.Granted)
                {
                    permissions = await Permissions.RequestAsync<Permissions.Camera>();
                }

                var actionSheet = await UserDialogs.Instance.ActionSheetAsync("Select Option", "", "Cancel", null, "Camera", "Gallery");

                FileResult mediaFile = null;
                if(actionSheet == "Gallery")
                {
                    mediaFile = await MediaPicker.PickPhotoAsync();
                }
                if (actionSheet == "Camera")
                {
                    mediaFile = await MediaPicker.CapturePhotoAsync();
                }

                if (mediaFile != null)
                {
                    var stream = await mediaFile.OpenReadAsync();
                    ProfileImage = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async Task<CameraModel> UploadProfile()
        {
            try
            {
                var photoData = new CameraModel();
                var isSupported = MediaPicker.IsCaptureSupported;
                if(isSupported)
                {
                    var mediaFile = await MediaPicker.CapturePhotoAsync();
                    if(mediaFile != null)
                    {
                        var stream = await mediaFile.OpenReadAsync();
                        photoData.FileName = mediaFile.FileName;
                        photoData.FileContent = streamToByteArray(stream);
                        photoData.MediaType = mediaFile.ContentType;
                        photoData.MediaUrl = mediaFile.FullPath;

                        ProfileImage = ImageSource.FromStream(() => stream);
                    }
                }
                return photoData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
                return null;
            }
        }

        public static byte[] streamToByteArray(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private ImageSource _ProfileImage;
        public ImageSource ProfileImage
        {
            get { return _ProfileImage; }
            set { SetProperty(ref _ProfileImage, value); }
        }
    }
}
