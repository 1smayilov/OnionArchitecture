using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Model:Entity<Guid>
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }  
}
 
public class Transmission : Entity<Guid>
{
    public string Name { get; set; }
}

public class Fuel : Entity<Guid>
{
    public string Name { get; set; }
}   

public class Car : Entity<Guid>