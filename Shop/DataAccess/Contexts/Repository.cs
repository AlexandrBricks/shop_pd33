using Shop.Application;
using Shop.DataAccess.Interfaces;
using Shop.DataAccess.Models;

namespace Shop.DataAccess.Contexts
{
    internal class Repository : IRepository
    {
        public IDataSet<Customer> Customers { get; private set; }

        public IDataSet<Description> Descriptions { get; private set; }

        public IDataSet<Employee> Employees { get; private set; }
        
        public IDataSet<Position> Positions { get; private set; }

        public IDataSet<Order> Orders { get; private set; }

        public IDataSet<Product> Products { get; private set; }

        public IDataSet<ProductOrder> ProductOrders { get; private set; }

        public Repository()
        {
            var container = IoCContainerFactory.GetInstance();
            
            //DI
            Customers = container.Create<IDataSet<Customer>>();
            Descriptions = container.Create<IDataSet<Description>>();
            Employees = container.Create<IDataSet<Employee>>();
            Positions = container.Create<IDataSet<Position>>();
            Orders = container.Create<IDataSet<Order>>();
            Products = container.Create<IDataSet<Product>>();
            ProductOrders = container.Create<IDataSet<ProductOrder>>();
        }

        public void SaveAll()
        {
            Customers.Save();
            Descriptions.Save();
            Employees.Save();
            Positions.Save();
            Orders.Save();
            Products.Save();
            ProductOrders.Save();
        }

        public void RefreshAll()
        {
            Customers.Refresh();
            Descriptions.Refresh();
            Employees.Refresh();
            Positions.Refresh();
            Orders.Refresh();
            Products.Refresh();
            ProductOrders.Refresh();
        }
    }
}
