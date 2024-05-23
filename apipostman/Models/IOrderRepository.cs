using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apipostman.Models
{
    internal interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order Get(int id);
        Order Add(Order item);
        void Remove(int id);
        bool Update(Order item);
    }
}
