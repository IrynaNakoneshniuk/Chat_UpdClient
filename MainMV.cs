using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chat_UpdClient
{
    public class MainMV : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand sendCommand { get; set; }
        public MainMV()
        {
            sendCommand = new SendMsgCommand(this);
        }
        private List<string> _msgs= new List<string>();
        private string _msg;
        public string Message
        {
            get { return _msg; }
            set
            {
                if (_msg != value)
                {
                    _msg = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }
        public List<string> Msgs
        {
            get { return _msgs; }
            set
            {
                _msgs = value;
                OnPropertyChanged(nameof(Msgs));
            }
        }
    }
}
