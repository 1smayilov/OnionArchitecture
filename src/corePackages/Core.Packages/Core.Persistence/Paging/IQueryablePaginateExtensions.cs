using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Persistence.Paging;

public static class IQueryablePaginateExtensions
{
    public static async Task<Paginate<T>> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default
        )
    {
        int count = await source.CountAsync(cancellationToken).ConfigureAwait(false); // source içərisində neçə element olduğunu (qeydi) sayır. Məsələn, əgər cədvəldə 1000 qeyd varsa, count 1000 olacaq

        List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false); // Əgər index 1 və size 10-dursa, Skip(10) 10 elementi atlayır, yəni ikinci səhifəni alır.

        Paginate<T> list = new()
        {
            Items = items, // Alınan elementlər
            Count = count, // Ümumi sayı
            Index = index,  // Hal-hazırda olan səhifə
            Size = size,    // Hər səhifədə neçə element var
            Pages = (int)Math.Ceiling(count / (double)size) // Toplam səhifə sayı
        };
        return list;
    }

    public static async Task<Paginate<T>> ToPaginateAsync<T>(
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default
        )
    {
        int count = await source.CountAsync(cancellationToken).ConfigureAwait(false); // source içərisində neçə element olduğunu (qeydi) sayır. Məsələn, əgər cədvəldə 1000 qeyd varsa, count 1000 olacaq

        List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false); // Əgər index 1 və size 10-dursa, Skip(10) 10 elementi atlayır, yəni ikinci səhifəni alır.

        Paginate<T> list = new()
        {
            Items = items, // Alınan elementlər
            Count = count, // Ümumi sayı
            Index = index,  // Hal-hazırda olan səhifə
            Size = size,    // Hər səhifədə neçə element var
            Pages = (int)Math.Ceiling(count / (double)size) // Toplam səhifə sayı
        };
        return list;
    }
}