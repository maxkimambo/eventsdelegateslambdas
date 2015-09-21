using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{

    public delegate void OrderCreatedHandler(object sender, OrderEventsArgs e);

    public class OrderService
    {
     
        public event OrderCreatedHandler OrderCreated; 

      
        public void CreateNewOrder()
        {
            // create a new order object 
            var order = new Order()
            {
                Id = 1,
                OrderDate = DateTime.Now,
                OrderDetails = new List<OrderDetail>()
                {
                    new OrderDetail()
                    {
                        ProductId = 1,
                        Price = 100,
                        Quantity = 2
                    },
                    new OrderDetail()
                    {
                        ProductId = 3,
                        Price = 24,
                        Quantity = 1
                    },
                    new OrderDetail()
                    {
                        ProductId = 4,
                        Price = 15,
                        Quantity = 2
                    }



                }
            }; 


            StoreOrderInDb(order);
        
        }
        /// <summary>
        /// Raises Order created event. 
        /// make sure its protected virtual so that its overridable. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnOrderCreated(object sender, OrderEventsArgs e)
        {
            if (OrderCreated != null)
            {
                // invoke the event 
                OrderCreated(this,e);
            }
        }

        public void StoreOrderInDb(Order order)
        {
            Console.WriteLine("saved order id {0} into the database", order.Id);
            // raise order created event 
            OnOrderCreated(this, new OrderEventsArgs() { Order = order });
        }
    }
}
