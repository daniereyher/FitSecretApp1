﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitSecretApp1
{
    public partial class App : Application
    {
        public App()
        {
            

            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
