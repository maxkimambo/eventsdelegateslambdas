using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
   public  class OrderEventsArgs : EventArgs
   {
       public Order Order { get; set; }
   }
}
