using Shop.DataAccess.Interfaces;

namespace Shop.DataAccess.Models
{
    public class Employee : IUnique
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
        public int ChiefId { get; set; } = -1;
        public Employee(int id, string name, string surname, int positionId, int idchief)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.PositionId = positionId;
            this.ChiefId = idchief;
        }

        public Employee()
        {

        }

        public override string ToString()
        {
            return string.Format($"{Id} {Name} {Surname} {PositionId} {ChiefId}");
        }
    }
}
