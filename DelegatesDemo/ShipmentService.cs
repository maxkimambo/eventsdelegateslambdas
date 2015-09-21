using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public class ShipmentService
    {
        public  bool billingService_BillingSuccessfullHandler(object sender, OrderEventsArgs e)
        {
            // initiate shipping 
            ShipOrder(e.Order);
            return true;
        }


        public void ShipOrder(Order order)
        {
            Console.WriteLine("Shipped order id: {0}", order.Id);
        }
    }
}
