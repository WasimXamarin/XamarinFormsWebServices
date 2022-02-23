using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsWebServices.CommonClass;

namespace XamarinFormsWebServices.ViewModels
{
    public class BasicDataBindingViewModel : BaseViewModel
    {
        public BasicDataBindingViewModel()
        {
            Title = "Basic Data Binding";
        }
        
        public BasicDataBindingViewModel(IDictionary<string, object> dictionary)
        {
            
        }

        NamedColor backgroundNamedColor;
        public NamedColor BackgroundNamedColor
        {
            set
            {
                if(SetProperty(ref backgroundNamedColor, value))
                {
                    OnPropertyChanged("BackgroundColor");
                }
            }
            get { return backgroundNamedColor; }
        }
        public Color BackgroundColor
        {
            get { return BackgroundNamedColor?.Color ?? Color.White; }
        }

        public void SaveState(IDictionary<string, object> dictionary)
        {
            dictionary["BackgroundNamedColor"] = BackgroundNamedColor;
        }

        T GetDictionaryEntry<T>(IDictionary<string, object> dictionary, string key, T defaultValue = default(T))
        {
            return dictionary.ContainsKey(key) ? (T)dictionary[key] : defaultValue;
        }
    }
}
