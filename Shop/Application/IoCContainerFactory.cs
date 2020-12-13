using Shop.DataAccess.Contexts;
using Shop.DataAccess.Interfaces;
using Shop.DataAccess.Models;
using Shop.Services;
using Shop.Services.Interfaces;

namespace Shop.Application
{
    public static class IoCContainerFactory
    {
        private static IoCContainer _container;

        public static IoCContainer GetInstance()
        {
            if (_container == null)
            {
                _container = new IoCContainer();

                //Repo config
                _container.RegisterTransient<IDataSet<Customer>, DataSet<Customer>>();
                _container.RegisterTransient<IDataSet<Description>, DataSet<Description>>();
                _container.RegisterTransient<IDataSet<Employee>, DataSet<Employee>>();
                _container.RegisterTransient<IDataSet<Position>, DataSet<Position>>();
                _container.RegisterTransient<IDataSet<Order>, DataSet<Order>>();
                _container.RegisterTransient<IDataSet<Product>, DataSet<Product>>();
                _container.RegisterTransient<IDataSet<ProductOrder>, DataSet<ProductOrder>>();
                _container.RegisterTransient<IRepository, Repository>();

                //services config
                _container.RegisterTransient<IProductDepartmentService, ProductDepartmentService>();
                _container.RegisterTransient<IHRDepartmentService, HRDepartmentService>();
                _container.RegisterTransient<ISalesDepartmentService, SalesDepartmentService>();
            }

            return _container;
        }

    }
}
