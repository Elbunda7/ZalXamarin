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
        private static IFolder ROOT_FOLDER_PATH = FileSystem.Current.LocalStorage;
        private const string LOCAL_DATA_FILE = "localData.xml";
        private const string OFFLINE_COMMANDS_FILE = "offlineCommands.xml";

        public App() {
            InitializeComponent();
            //Zal.CommandExecutedOffline += OnCommandExecutedOffline;
            //Zal.LoadOfflineCommands(LoadFromStorage(OFFLINE_COMMANDS_FILE));
            //Zal.LoadLocalData(LoadFromStorage(LOCAL_DATA_FILE));
            //IS.Connect();            
            Zal.StartSynchronizing();
            MainPage = new SideMenu.SideMenu();
            //Connect();
        }

        private async void Connect() {
            ActionGateway gateway = new ActionGateway();
            //var task = gateway.GetAllAsync();
            //Collection<ZalApiGateway.Models.ActionModel> models = await gateway.GetAllAsync();
            var task = gateway.GetAsync(2);
            var task2 = gateway.GetAsync(3);
            ZalApiGateway.Models.ActionModel model = await task;
            ZalApiGateway.Models.ActionModel model2 = await task2;
            //bool info = await gateway.JoinAsync(81, 1);
            //bool info2 = await gateway.AddAsync(model);
        }


        protected override void OnStart() {
        }

        protected override void OnSleep() {
            SaveToStorage( LOCAL_DATA_FILE, Zal.GetLocalDataXml().ToString());
        }

        protected override void OnResume() {
        }

        private void OnCommandExecutedOffline(XDocument commands) {
            SaveToStorage(OFFLINE_COMMANDS_FILE, commands.ToString());
        }

        private async void SaveToStorage(string fileName, string content) {
            IFolder folder = await ROOT_FOLDER_PATH.CreateFolderAsync("Saves", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(content);
        }

        private XDocument LoadFromStorage(string fileName) {
            string filePath = ROOT_FOLDER_PATH + "/Saves/" + fileName;
            XDocument document;
            try {
                document = XDocument.Load(filePath);
            }
            catch (Exception) {
                document = null;
            }
            return document;
        }

        /*private async Task<string> LoadFromStorageAsync() {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFile file = await rootFolder.GetFileAsync("Saves/localFile.xml");
            return await file.ReadAllTextAsync();
        }*/
    }
}
