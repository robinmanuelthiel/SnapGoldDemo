﻿using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PhotoSharingApp.Frontend.Portable.Models;
using PhotoSharingApp.Frontend.Portable.Services;
using PhotoSharingApp.Frontend.Portable.ViewModels;
using Xamarin.Forms;

namespace PhotoSharingApp.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Setup IoC Container for Dependeny Injection
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Reset();

            var test = new PhotoDummyService();

            // Register Dependencies

            SimpleIoc.Default.Register<IAppEnvironment, AppEnvironment>();

            SimpleIoc.Default.Register<IPhotoService, PhotoDummyService>();
            SimpleIoc.Default.Register<CategoriesViewModel>();

            // Setup App Container
            var navigationPage = new NavigationPage();
            navigationPage.BarBackgroundColor = (Color)Resources["AccentColor"];
            navigationPage.BarTextColor = Color.Black;

            var appShell = new AppShell();
            appShell.Children.Add(new CategoriesPage());   // Home
            appShell.Children.Add(new CameraPage());       // Upload
            appShell.Children.Add(new LeaderboardsPage()); // Leaderboards
            appShell.Children.Add(new ProfilePage());      // My profile

            navigationPage.PushAsync(appShell);
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}