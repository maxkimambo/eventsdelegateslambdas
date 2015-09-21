using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{

    

    /// <summary>
    /// Order Processing complete delegate
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OrderProcessingComplete(object sender, EventArgs e);

    public delegate bool BillingSuccessfull(object sender, OrderEventsArgs e); 
}
