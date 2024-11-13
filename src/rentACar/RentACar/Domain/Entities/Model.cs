using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model:Entity<Guid> // 1 Modelin 1 Brandi, 1 Yanacaq növü, 1 Ötürücü tipi ola bilər. || 1 Modelin 1 dən çox Maşını ola bilər
{
    public Guid BrandId { get; set; } // Model hansı markaya aiddir? ||  
    public Guid FuelId { get; set; } // Model hansı yanacaq növünə aiddir?
    public Guid TransmissionId { get; set; } // Model hansı ötürücü növünə aiddir?
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }  

    public virtual Brand? Brand { get; set; } // Model hansı markaya aiddir? (model.Brand.Name)
    public virtual Fuel? Fuel { get; set; } // Model hansı yanacaq növünə aiddir? (model.Fuel.Name)
    public virtual Transmission? Transmission { get; set; } // Model hansı ötürücü növünə aiddir? (model.Transmission.Name)

    public virtual ICollection<Car> Cars { get; set; } // Bu modelə aid olan avtomobillərin siyahısı. (model.Car.Name)

    public Model()
    {
        Cars = new HashSet<Car>(); // Default konstruktor: Model yaradarkən avtomobilləri saxlamaq üçün `Cars` siyahısını təyin edir.
    }

    public Model(Guid id, Guid brandID, Guid fuelId, Guid transmissionId, string name, decimal dailyPrice, string imageUrl) : this() // this dedikdə yuxarıdakı konstraktr da işləsin deməkdir
    {
        Id = id;
        BrandId = brandID;
        FuelId = fuelId;
        TransmissionId = transmissionId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
    }
}
