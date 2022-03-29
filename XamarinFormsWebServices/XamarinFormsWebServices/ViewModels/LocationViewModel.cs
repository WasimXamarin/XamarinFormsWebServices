using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinFormsWebServices.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        public LocationViewModel()
        {
            Title = "Location";

            //double lat = 27.9135016;
            //double longt = 78.0781901;
        }

        private Double _LatitudeValue;
        public Double LatitudeValue
        {
            get { return _LatitudeValue; }
            set { SetProperty(ref _LatitudeValue, value); }
        }

        private Double _LongitudeValue;
        public Double LongitudeValue
        {
            get { return _LongitudeValue; }
            set { SetProperty(ref _LongitudeValue, value); }
        }

        private string _AddressValue;
        public string AddressValue
        {
            get { return _AddressValue; }
            set { SetProperty(ref _AddressValue, value); }
        }

        public Command AddressCommand
        {
            get { return new Command(OnAddressClicked); }
        }

        

        private async void OnAddressClicked(object obj)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(AddressValue);
                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    LatitudeValue = location.Latitude;
                    LongitudeValue = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
        }

        private Double _LatitudeValue1;
        public Double LatitudeValue1
        {
            get { return _LatitudeValue1; }
            set { SetProperty(ref _LatitudeValue1, value); }
        }

        private Double _LongitudeValue1;
        public Double LongitudeValue1
        {
            get { return _LongitudeValue1; }
            set { SetProperty(ref _LongitudeValue1, value); }
        }

        public Command GeolocationCommand
        {
            get { return new Command(OnGeolocationClicked); }
        }

        private async void OnGeolocationClicked(object obj)
        {
            try
            {
                var permissionAppUse = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                var permission = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
                if(permissionAppUse != PermissionStatus.Granted || permission != PermissionStatus.Granted)
                {
                    permissionAppUse = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    permission = await Permissions.RequestAsync<Permissions.LocationAlways>();
                }
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    LatitudeValue1 = location.Latitude;
                    LongitudeValue1 = location.Longitude;

                    double lat = 27.9135016;
                    double longt = 78.0781901;

                    long geofenceDistance = 120;
                    Location geofenceCentercordinate = new Location(lat, longt);
                    Location userLocation = new Location(LatitudeValue1, LongitudeValue1);
                    var distance = (long)Location.CalculateDistance(userLocation, geofenceCentercordinate, DistanceUnits.Kilometers);
                    if (distance < geofenceDistance)
                    {
                        await Application.Current.MainPage.DisplayAlert("Important", "You are in Geofence", "Ok");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Important", "You are not in Geofence", "Ok");
                    }

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                _ = Application.Current.MainPage.DisplayAlert("Error", pEx.ToString(), "Ok");
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}   
