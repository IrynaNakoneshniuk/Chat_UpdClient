using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chat_UpdClient
{
    public class SendMsgCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private MainMV mainMV;
        public SendMsgCommand(MainMV mainMV)
        {
            this.mainMV = mainMV;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public async void Execute(object? parameter)
        {
            string incomeMsg = null;
           Task.Run(async ()=> { incomeMsg = await Upd_client.ReceiveMessageAsync();
            });
            await Upd_client.SendMessageAsync(mainMV.Message);
            mainMV.Msgs.Add(mainMV.Message);
            mainMV.Msgs.Add(incomeMsg);
            mainMV.Message = null;
        }
    }
}
