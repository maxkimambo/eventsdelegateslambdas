using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
  
    public class BillingService
    {

        public event BillingSuccessfull BillingSuccessfullHandler;
        private Order _order; 

        protected virtual bool OnBillingSuccessfullHandler(bool status)
        {
            BillingSuccessfull handler = BillingSuccessfullHandler;
            if (handler != null) handler(this, new OrderEventsArgs(){Order = _order});
            return status; 
        }

        public void OnOrderCreated(object sender, OrderEventsArgs e)
        {
            CreateInvoice(e.Order);   
        }

        public  static bool billingService_BillingSuccessfullHandler(object sender, OrderEventsArgs e)
        {
            // initiate shipping 
            var shipmentService = new ShipmentService(); 
            shipmentService.ShipOrder(e.Order);
            return true; 
        }


        public void CreateInvoice(Order order)
        {
            _order = order; 
            var orderTotal = order.OrderDetails.Sum(o => o.Quantity + o.Price);
            Console.WriteLine("Invoice created for {0}",orderTotal);
            // simulate fake billing process 
            //if value is more than 1 assume billing did happen. 
            OnBillingSuccessfullHandler(orderTotal >= 1); 
        }
    }
}
