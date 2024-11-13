using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transmission : Entity<Guid> // 1 Ötürücüdə 1 dən çox Model ola bilər
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; } // Bu ötürücü növünə aid olan modellərin siyahısı (transmission.Model.Name)

    public Transmission()
    {
        Models = new HashSet<Model>();
    }

    public Transmission(Guid id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }
}