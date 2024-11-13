using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Brand : Entity<Guid> // 1 Brand - in 1 dən çox Modeli ola bilər
{ 
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; } // Bu markaya aid olan bütün modellərin siyahısı.

    // Default konstruktor: Yeni bir marka yaradarkən, modellər siyahısını boş bir `HashSet` olaraq təyin edir. 
    // HashSet - 1 modeldən 2 dənə ola bilməz
    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }


}
