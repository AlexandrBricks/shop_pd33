using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Models
{
    public class Customer : IUnique
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Customer(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public Customer()
        {

        }

        public override string ToString()
        {
            return string.Format($"{Id} {Name} {Surname}");
        }
    }
}
