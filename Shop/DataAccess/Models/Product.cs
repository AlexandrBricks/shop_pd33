using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Models
{
    public class Product : IUnique
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DescriptionId { get; set; }

        public Product(int id, string name, decimal price, int descriptionId)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.DescriptionId = descriptionId;
        }

        public Product()
        {

        }

        public override string ToString()
        {
            return string.Format($"{Id} {Name} {Price}");
        }
    }
}
