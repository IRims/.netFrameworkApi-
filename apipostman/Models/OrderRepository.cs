using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apipostman.Models
{
    public class OrderRepository : IOrderRepository
    {
        private List<Order> orders = new List<Order>();
        private int _nextId = 1;
        public OrderRepository()
        {
            orders.Add(new Order
            {
                OrdId = 1,
                CusName = "Rimsha Zahid",
                Laptop = 1,
                LCD = 0,
                Phone = 1
            });
            orders.Add(new Order
            {
                OrdId = 2,
                CusName = "Ayesha Zahid",
                Laptop = 1,
                LCD = 1,
                Phone = 2
            });
            orders.Add(new Order
            {
                OrdId = 3,
                CusName = "Bushra Majeed",
                Laptop = 0,
                LCD = 1,
                Phone = 0
            });
        }
        public Order Add(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.OrdId = _nextId++;
            orders.Add(item);
            return item;
        }
        public Order Get(int id)
        {
            return orders.Find(p => p.OrdId == id);
        }
        public IEnumerable<Order> GetAll()
        {
            return orders;
        }
        public void Remove(int id)
        {
            orders.RemoveAll(p => p.OrdId == id);
        }
        public bool Update(Order item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = orders.FindIndex(p => p.OrdId == item.OrdId);
            if (index == -1)
            {
                return false;
            }
            orders.RemoveAt(index);
            orders.Add(item);
            return true;
        }
    }
}
