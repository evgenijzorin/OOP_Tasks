using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Core
   {
   public abstract class Logger
      {
      public abstract void ShowMessage(string message);
      }
   public sealed class ConsoleLogger : Logger
      {
      public override void ShowMessage(string message)
         {
         System.Console.WriteLine(message);
         }
      }
   }
