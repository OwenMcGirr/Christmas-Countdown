using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace Christmas_Countdown.View_Models_and_Logic
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private ChristmasLogic _logic;

        public MainPageViewModel()
        {
            _logic = ChristmasLogic.Instance;
            UpdateTimeLeft();
        }

        private string _timeLeft;
        public string TimeLeft
        {
            get
            {
                return _timeLeft;
            }
            set
            {
                _timeLeft = value;
                OnPropertyChanged("TimeLeft");
            }
        }

        private void UpdateTimeLeft()
        {
            TimeLeft = _logic.GetTimeLeft();
        }

        public void SwitchTimeUnit()
        {
            _logic.SwitchTimeUnit();
            UpdateTimeLeft();
        }

        public ICommand SwitchTimeUnitCommand
        {
            get
            {
                return new Command(SwitchTimeUnit);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
