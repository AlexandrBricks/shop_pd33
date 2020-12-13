using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Models
{
    public class Position : IUnique
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
