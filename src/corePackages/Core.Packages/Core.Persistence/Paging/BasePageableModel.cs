using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging;

public abstract class BasePageableModel
{
    public int Size { get; set; } // Səhifədə neçə data var
    public int Index { get; set; } // Hansı səhifədəyik
    public int Count { get; set; } //  Məsələn, verilənlər bazasında 100 müştəri varsa, Count 100 olacaq.
    public int Pages { get; set; } // Neçə səhifə var
    public bool HasPrevious { get; set; } // Əvvəlki səhifə var?
    public bool HasNext { get; set; } // Sonrakı səhifə var?
}
