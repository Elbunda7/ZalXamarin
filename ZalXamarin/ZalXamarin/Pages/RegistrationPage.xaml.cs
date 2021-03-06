﻿using ZalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZalXamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
            Title = "Registrace";
		}

        private void ConfirmatedPassword_Completed(object sender, EventArgs e) {
           if (PassEntry.Text == PassConfirmEntry.Text) {
                RegistrationButton.IsEnabled = true;
            }
        }

        private async void RegistrationButton_Click(object sender, EventArgs args) {
            bool isRegistered = await Zal.Session.RegisterAsync(NameEntry.Text, SurnameEntry.Text, PhoneEntry.Text, EmailEntry.Text, PassEntry.Text);
            if (isRegistered) {
                await ShowProfile();
            }
            else {
                await DisplayAlert("Regisrace", "Regisrace se nezdařila", "Ok");
            }
        }

        private async Task ShowProfile() {
            Navigation.InsertPageBefore(new ProfilePage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        private async void ToLogin_Click() {
            await Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }
    }
}