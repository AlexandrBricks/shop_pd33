using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Models
{
    public class ProductOrder : IUnique
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductQuantity { get; set; }

        public ProductOrder(int id, int IdProduct,int IdOrder,int ProductQuantity)
        {
            this.Id = id;
            this.ProductId = IdProduct;
            this.OrderId = IdOrder;
            this.ProductQuantity = ProductQuantity;
        }

        public ProductOrder()
        {

        }

        public override string ToString()
        {
            return string.Format($"{Id} {ProductId} {OrderId} {ProductQuantity}");
        }

    }
}
