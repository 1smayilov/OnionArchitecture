using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public class Entity<TId> // TId - sinfin fərqli tiplər alması üçündür
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Entity()
    {
        Id = default;
    }
    // var brand = new Brand();         // Parametresiz konstruktordan istifadə
    // Console.WriteLine(brand.Id);     // TId tipinin standart dəyəri olacaq


    public Entity(TId id)
    {  
        Id = id; 
    }
}
