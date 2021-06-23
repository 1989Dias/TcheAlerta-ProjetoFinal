using Plugin.Multilingual;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TcheAlerta
{
    public partial class App : Application
    {  
        public App() {
            InitializeComponent();
            
            AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }              

    }
}
