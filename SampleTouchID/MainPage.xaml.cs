using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Fingerprint.Abstractions;
using MvvmCross.Platform;
using System.Threading;
using Plugin.Fingerprint;

namespace SampleTouchID
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAuthenticateClicked(object sender, EventArgs e)
        {
            #region commented code
            //        var fpService = Mvx.Resolve<IFingerprint>(); // or use dependency injection and inject IFingerprint

            //        var result = await fpService.AuthenticateAsync("Prove you have mvx fingers!");
            //        //if (result.Authenticated)
            //        //{
            //        //    await DisplayAlert("Welcome", "You are an authenticated person", "ok");
            //        //}
            //        //else
            //        //{
            //        //    await DisplayAlert("Alert", "Not authenticated", "ok");
            //        //}
            //    }
            //private async Task AuthenticateAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)
            //{
            //_cancel = swAutoCancel.IsToggled ? new CancellationTokenSource(TimeSpan.FromSeconds(10)) : new CancellationTokenSource();
            //private async Task SetResultAsync(FingerprintAuthenticationResult result)
            //{
            //    if (result.Authenticated)
            //    {
            //        await DisplayAlert("Welcome", "You are an authenticated person", "ok");
            //    }
            //    else
            //    {
            //        await DisplayAlert("Alert", "Not authenticated", "ok");
            //    }
            //}
            #endregion
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);
            if (result)
            {
                var auth = await CrossFingerprint.Current.AuthenticateAsync("To Authenticate");
                if (auth.Authenticated)
                {
                    //await DisplayAlert("Welcome", "you are an authenticated user to access", "ok");
                    await Navigation.PushAsync(new Authenticated());
                }
                else
                {
                    await DisplayAlert("Alert", "You are not an authorised person", "Ok");
                }
            }
            else
            {
               await DisplayAlert("Alert", "FingerPrint is not available in your device","Ok");
            }



            }

           
        }


    }

