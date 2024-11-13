using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Fuel : Entity<Guid> // 1 Yanacaq növünündə 1 dən çox Model ola bilər
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; } // Bu yanacaq növünə aid modellərin siyahısı. (fuel.Model.Name)

    public Fuel()
    {
        Models = new HashSet<Model>();
    }

    public Fuel(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}   
