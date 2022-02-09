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

        string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value); }
        }

        bool codesInCSharp;
        public bool CodesInCShare
        {
            get { return codesInCSharp; }
            set { SetProperty(ref codesInCSharp, value); }
        }

        double numberOfCopies;
        public double NumberOfCopies
        {
            get { return numberOfCopies; }
            set { SetProperty(ref numberOfCopies, value); }
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
            dictionary["Name"] = Name;
            dictionary["BirthDate"] = BirthDate;
            dictionary["CodesInCShare"] = CodesInCShare;
            dictionary["NumberOfCopies"] = NumberOfCopies;
            dictionary["BackgroundNamedColor"] = BackgroundNamedColor;
        }

        T GetDictionaryEntry<T>(IDictionary<string, object> dictionary, string key, T defaultValue = default(T))
        {
            return dictionary.ContainsKey(key) ? (T)dictionary[key] : defaultValue;
        }
    }
}
