using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesDemo;

namespace DemoRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderService = new OrderService();
            var billingService = new BillingService();
            var shipmentService = new ShipmentService(); 

            orderService.OrderCreated += new OrderCreatedHandler(billingService.OnOrderCreated);

            billingService.BillingSuccessfullHandler += shipmentService.billingService_BillingSuccessfullHandler; 

            orderService.CreateNewOrder();

            Console.Read(); 

        }
    }
}
