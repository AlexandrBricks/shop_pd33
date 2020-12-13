using Shop.DataAccess.Interfaces;
using System;

namespace Shop.DataAccess.Models
{
    public class Order : IUnique
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int id, int idCustomer, int idEmployee, DateTime OrderDate)
        {
            this.Id = id;
            this.CustomerId = idCustomer;
            this.EmployeeId = idEmployee;
            this.OrderDate = OrderDate;
        }

        public Order()
        {

        }

        public override string ToString()
        {
            return string.Format($"{Id} {CustomerId} {EmployeeId} {OrderDate}");
        }
    }
}
