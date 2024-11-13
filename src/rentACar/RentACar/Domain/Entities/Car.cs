using Core.Persistence.Repositories;
using Domain.Enums;
using System.Drawing;

namespace Domain.Entities;

public class Car : Entity<Guid> // 1 Maşının 1 Modeli ola bilər
{
    public Guid ModelId { get; set; } // Car hansı model növünə aiddir?
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindexScore { get; set; } // Maşını kiralayan adamı statusu
    public CarState CarState { get; set; } // Maşının vəziyyəti

    public virtual Model? Model { get; set; } // Car hansı model növünə aiddir? (car.Model.Name)

    public Car()
    {

    }

    public Car(
        Guid id,
        Guid modelId,
        CarState carState,
        int kilometer,
        short modelYear,
        string plate,
        short minFindexScore
    )
        : this()
    {
        Id = id;
        ModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
        MinFindexScore = minFindexScore;
    }
}