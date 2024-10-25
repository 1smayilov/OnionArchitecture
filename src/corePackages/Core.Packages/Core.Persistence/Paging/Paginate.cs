 using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging;

public class Paginate<T>
{
    public Paginate()
    {
        Items = Array.Empty<T>(); // Data yoxdursa Null problemi ilə qarşılaşmamaq üçün
    }

    public int Size { get; set; } // Səhifədə neçə data var
    public int Index { get; set; } // Hansı səhifədəyik
    public int Count { get; set; } //  Məsələn, verilənlər bazasında 100 müştəri varsa, Count 100 olacaq.
    public int Pages { get; set; } // Neçə səhifə var
    public IList<T> Items { get; set; } // Datamız nədir
    public bool HasPrevious => Index > 0; // Əvvəlki səhifə var?
    public bool HasNext => Index+1 < Pages; // Sonrakı səhifə var?

}
