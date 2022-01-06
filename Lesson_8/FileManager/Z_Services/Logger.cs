using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Services
{
    public abstract class Logger
    {
        public abstract void ShowMessage(string message);
        public abstract string GetMessageFromUser();
    }
    public sealed class ConsoleLogger : Logger
    {
        public override void ShowMessage(string message)
        {
            System.Console.WriteLine(message);
        }
        public override string GetMessageFromUser()
        {
            return Console.ReadLine(); 
        }
    }

}
