using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Models
{
    public class Description : IUnique
    {
        public int Id { get; set; }
        public string Information { get; set; }
        public int ProductId { get; set; }

        public Description(int id, string information, int productId)
        {
            this.Id = id;
            this.Information = information;
            this.ProductId = productId;
        }

        public Description()
        {

        }

        public override string ToString()
        {
            return string.Format($"{Id} {Information} {ProductId}");
        }
    }
}
