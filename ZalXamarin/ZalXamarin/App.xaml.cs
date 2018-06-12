using ZalApiGateway;
using ZalDomain.ActiveRecords;
using ZalDomain.tools;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using ZalDomain;

namespace ZalXamarin
{
    public partial class App : Application
    {
        private static IFolder ROOT_FOLDER = FileSystem.Current.LocalStorage;
        private const string LOCAL_DATA_FILE = "localData.xml";
        private const string OFFLINE_COMMANDS_FILE = "offlineCommands.xml";

        public App() {
            InitializeComponent();
            InitializeAppData();
            MainPage = new SideMenu.SideMenu();
        }

        private async void InitializeAppData() {
            //Zal.CommandExecutedOffline += OnCommandExecutedOffline;
            await Task.Run(async () => {
                //Zal.LoadOfflineCommands(LoadFromStorage(OFFLINE_COMMANDS_FILE));
                //Zal.LoadDataFrom(await LoadFromStorageAsync(LOCAL_DATA_FILE));
                var a = await LoadFromStorageAsync(LOCAL_DATA_FILE);
                Zal.LoadDataFrom(a);
                await Zal.Session.LoginWithTokenAsync();
                //await Zal.StartSynchronizingAsync();

            });
            OnAppReady();
        }

        private void OnAppReady() {
            MainPage = new SideMenu.SideMenu();
        }

        

        protected override void OnStart() {
        }

        protected override void OnSleep() {
            var a = Zal.GetDataJson();
            SaveToStorage( LOCAL_DATA_FILE,a);
        }

        protected override void OnResume() {
        }

        private void OnCommandExecutedOffline(XDocument commands) {
            SaveToStorage(OFFLINE_COMMANDS_FILE, commands.ToString());
        }

        private async void SaveToStorage(string fileName, string content) {
            IFolder folder = await ROOT_FOLDER.CreateFolderAsync("Saves", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(content);
        }

        /*private XDocument LoadFromStorage(string fileName) {
            string filePath = ROOT_FOLDER + "/Saves/" + fileName;
            XDocument document;
            try {
                document = XDocument.Load(filePath);
            }
            catch (Exception) {
                document = null;
            }
            return document;
        }*/

        private async Task<string> LoadFromStorageAsync(string fileName) {
            string fileContent;
            try {
                IFile file = await ROOT_FOLDER.GetFileAsync("Saves/" + fileName);
                fileContent = await file.ReadAllTextAsync();
            }
            catch (Exception) {
                fileContent = "";
            }
            return fileContent;
        }
    }
}
