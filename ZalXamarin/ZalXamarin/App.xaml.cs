using ZalApiGateway;
using DL.ActiveRecords;
using DL.tools;
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

namespace ZalXamarin
{
    public partial class App : Application
    {
        private static IFolder ROOT_FOLDER_PATH = FileSystem.Current.LocalStorage;
        private const string LOCAL_DATA_FILE = "localData.xml";
        private const string OFFLINE_COMMANDS_FILE = "offlineCommands.xml";

        public App() {
            InitializeComponent();
            IS.CommandExecutedOffline += OnCommandExecutedOffline;
            IS.LoadOfflineCommands(LoadFromStorage(OFFLINE_COMMANDS_FILE));
            IS.LoadLocalData(LoadFromStorage(LOCAL_DATA_FILE));
            //IS.Connect();            
            MainPage = new SideMenu.SideMenu();
            Connect();
        }

        private async void Connect() {
            ZalApiGateway.ActionGateway gateway = new ZalApiGateway.ActionGateway();
            Collection<ZalApiGateway.Models.ActionModel> models = await gateway.GetAllAsync();
            ZalApiGateway.Models.ActionModel model = await gateway.GetAsync(2);

            /*Security security = new Security();
            string text = "nějaký text";
            text = security.Encrypt(text);
            text = security.Decrypt(text);
            var values = new Dictionary<string, string> {
                { "body", text }
             };
            HttpContent content = new FormUrlEncodedContent(values);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://zalesak.hlucin.com/api/endpoint.php", content);
            string str = await response.Content.ReadAsStringAsync();
            str = security.Decrypt(str);*/
        }


        protected override void OnStart() {
        }

        protected override void OnSleep() {
            SaveToStorage( LOCAL_DATA_FILE, IS.GetLocalDataXml().ToString());
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
