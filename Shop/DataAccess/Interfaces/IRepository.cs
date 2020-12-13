using Shop.DataAccess.Models;

namespace Shop.DataAccess.Interfaces
{
    public interface IRepository
    {
        public IDataSet<Customer> Customers { get; }
        public IDataSet<Description> Descriptions { get; }
        public IDataSet<Employee> Employees { get; }
        public IDataSet<Position> Positions { get; }
        public IDataSet<Order> Orders { get; }
        public IDataSet<Product> Products { get; }
        public IDataSet<ProductOrder> ProductOrders { get; }
        public void SaveAll();
    }
}
