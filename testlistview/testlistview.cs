using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace testlistview
{   
    public class App : Application
    {
         

        public App()
        {
//
//            MainPage = new MyBudgetView();  
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Padding = 20,
                    Children =
                    {
                        new Label { Text = "Hi There" },
                        new Label { Text = "Hi There" },
                        new Label { Text = "Hi There" },
                        new Label { Text = "Hi There" },
                        new Label { Text = "Hi There" },
                        new Label { Text = "Hi There" },
                        new MyPage(), 
                        new Label { Text = "THis is the last bit ...." }
                    }
                }
            };
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

    public class Payment
    {
        public string Description
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public double RunningTotal
        {
            get;
            set;
        }

        public DateTime PayDate
        {
            get;
            set;
        }
    }
}

