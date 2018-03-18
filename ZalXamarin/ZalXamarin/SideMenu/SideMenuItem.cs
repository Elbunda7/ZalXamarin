using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalXamarin.Pages;

namespace ZalXamarin.SideMenu
{

    public class SideMenuItem : INotifyPropertyChanged
    {
        private static event Action ActiveItemSwitched;
        public event PropertyChangedEventHandler PropertyChanged;

        private static int IdMarker = 0;
        private static int IdOfActive = 0;

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; private set; }
        public bool IsActive { get; private set; }

        public SideMenuItem(string title, Type targetType, string iconSource) {
            Id = IdMarker++;
            Title = title;
            Icon = iconSource;
            TargetType = targetType;
            OnActiveItemSwitched();
            ActiveItemSwitched += OnActiveItemSwitched;
        }

        public void SetAsActive() {
            IdOfActive = Id;
            ActiveItemSwitched.Invoke();
        }

        private void OnActiveItemSwitched() {
            if (IsActive != (Id == IdOfActive)) {
                IsActive = Id == IdOfActive;
                RaisePropertyChanged("IsActive");
            }
        }

        private void RaisePropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}