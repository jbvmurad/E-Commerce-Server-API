using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Application.Services.PaginationService;

public sealed class PagedList<T>
{
    public IReadOnlyList<T> Items { get; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalCount { get; }
    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => Page > 1;

    public PagedList(IReadOnlyList<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int page, int pageSize)
    {
        var totalCount = await source.CountAsync();

        var items = await source
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedList<T>(items, page, pageSize, totalCount);
    }
}
