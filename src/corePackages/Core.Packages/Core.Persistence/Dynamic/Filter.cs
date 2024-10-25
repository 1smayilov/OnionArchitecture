using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic;

public class Filter
{
    public string Field { get; set; } // Qiyməti > 300 And Qiyməti < 500 (Buradakı Qiymət)
    public string? Value { get; set; } // Qiyməti > 300 And Qiyməti < 500 (Buradakı 300 və 500)
    public string Operator { get; set; } // Qiyməti > 300 And Qiyməti < 500 (> , <) 
    public string? Logic { get; set; } // Qiyməti > 300 And Qiyməti < 500 (Buradakı And)

    public IEnumerable<Filter> Filters { get; set; } 

    public Filter()
    {
        Field = string.Empty;
        Operator = string.Empty;
    }

    public Filter(string field, string @operator)
    {
        Field = field;
        Operator = @operator;
    }
}
