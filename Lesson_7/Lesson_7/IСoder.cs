using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
   {
   public interface ICoder
      {
      string Encode(string lineEncode);
      string Decode(string lineDecode);
      }
   }
