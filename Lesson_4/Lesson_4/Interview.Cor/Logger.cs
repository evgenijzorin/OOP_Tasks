using System;

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
