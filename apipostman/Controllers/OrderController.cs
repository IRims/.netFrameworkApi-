using apipostman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apipostman.Controllers
{
    public class OrderController : ApiController
    {
        static readonly IOrderRepository orderrepo = new OrderRepository();
        public IEnumerable<Order> Get()
        {
            return orderrepo.GetAll();
        }
        public Order Get(int id)
        {
            Order _order = orderrepo.Get(id);
            if (_order == null)
            {
                return _order;
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return _order;
        }
        public IEnumerable<Order> GetOrderByCusName(string CName)
        {
            return orderrepo.GetAll().Where(
            p => string.Equals(p.CusName, CName,
            StringComparison.OrdinalIgnoreCase));
        }
        public string Post(Order order)
        {
            order = orderrepo.Add(order);
            return "Album added successfully";
        }
        public void Put(int id, Order order)
        {
            order.OrdId = id;
            orderrepo.Update(order);
        }
        public void Delete(int id)
        {
            Order order = orderrepo.Get(id);
            orderrepo.Remove(id);
        }
    }
}
