﻿using ZalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZalDomain.Models;
using ZalDomain.tools;

namespace ZalXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {

        public LoginPage() {
            InitializeComponent();
            EmailEntry.Text = "pepa3@email.cz";
            PasswordEntry.Text = "password";
            HideErrorLabels();
        }

        private void HideErrorLabels() {
            EmailErrorLabel.Text = "";
            PassErrorLabel.Text = "";
        }

        private async Task LoginButton_Click(object sender, EventArgs args) {
            if (ValidateInputs()) {
                LoginErrorModel response = await Zal.Session.LoginAsync(EmailEntry.Text, PasswordEntry.Text, StayLoggedSwitch.IsToggled);
                if (response.HasAnyErrors) {
                    HandleErrors(response);
                }
                else {
                    await ShowProfile();
                }
            }
        }

        private bool ValidateInputs() {
            HideErrorLabels();
            bool isValid = Validator.IsValidEmail(EmailEntry.Text);
            if (!isValid) {
                EmailErrorLabel.Text = "Email není napsán správně";
            }
            return isValid;
        }

        private void HandleErrors(LoginErrorModel loginError) {
            if (!loginError.IsExist) {//cleanCode?
                EmailErrorLabel.Text = "Email nebyl nalezen";
            }
            else if (!loginError.IsPasswordCorrect) {
                PassErrorLabel.Text = "Nesprávné heslo";
            }
        }

        private async Task ShowProfile() {
            Navigation.InsertPageBefore(new ProfilePage(), Navigation.NavigationStack.First());
            await Navigation.PopToRootAsync();
        }

        private async Task ToRegistration_Click() {
            await Navigation.PushAsync(new RegistrationPage());
            Navigation.RemovePage(this);
        }

        private void DevLoginLeader_Click(object sender, EventArgs args) {
            //LoginUser("Leader@email.cz", "pass");
        }

        private void DevLoginMember_Click(object sender, EventArgs args) {
            //LoginUser("Member@email.cz", "pass");
        }

        private void DevLoginNovice_Click(object sender, EventArgs args) {
            //LoginUser("Novice@email.cz", "pass");
        }
    }
}