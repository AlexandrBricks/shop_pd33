using AutoMapper;
using Shop.DataAccess.Models;
using Shop.ViewModels;

namespace Shop.Application
{
    public static class AutomapperFactory
    {
        private static IMapper _mapper;
        private static IConfigurationProvider _mapperConfiguration;

        public static IMapper GetMapper()
        {
            if (_mapper == null)
                _mapper = GetMapperConfiguration().CreateMapper();

            return _mapper;
        }

        public static IConfigurationProvider GetMapperConfiguration()
        {
            if (_mapperConfiguration == null)
            {
                _mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    //Models config
                    cfg.CreateMap<Customer, CustomerViewModel>();
                    cfg.CreateMap<CustomerViewModel, Customer>();
                    cfg.CreateMap<Customer, Customer>();

                    cfg.CreateMap<Description, DescriptionViewModel>();
                    cfg.CreateMap<DescriptionViewModel, Description>();
                    cfg.CreateMap<Description, Description>();

                    cfg.CreateMap<Employee, EmployeeViewModel>();
                    cfg.CreateMap<EmployeeViewModel, Employee>();
                    cfg.CreateMap<Employee, Employee>();

                    cfg.CreateMap<Position, PositionViewModel>();
                    cfg.CreateMap<PositionViewModel, Position>();
                    cfg.CreateMap<Position, Position>();

                    cfg.CreateMap<Order, OrderViewModel>();
                    cfg.CreateMap<OrderViewModel, Order>();
                    cfg.CreateMap<Order, Order>();

                    cfg.CreateMap<ProductOrder, ProductOrderViewModel>();
                    cfg.CreateMap<ProductOrderViewModel, ProductOrder>();
                    cfg.CreateMap<ProductOrder, ProductOrder>();

                    cfg.CreateMap<Product, ProductViewModel>();
                    cfg.CreateMap<ProductViewModel, Product>();
                    cfg.CreateMap<Product, Product>();
                });
            }

            return _mapperConfiguration;
        }
    }
}
