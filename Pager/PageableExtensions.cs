using Microsoft.EntityFrameworkCore;
using Pager.Models;

namespace Pager
{
    public static class PageableExtensions
    {

        public static async Task<PageableResponse<T>> ToPageableListAsync<T>(this IQueryable<T> query, PageableRequest request, CancellationToken cancellationToken)
        {
            if (request.PageNumber > 0)
            {
                int start = (request.PageNumber - 1) * request.PageSize;
                query = query.Skip(start);
            }

            if (request.PageSize >= 0)
                query = query.Take(request.PageSize);

            int totalRecords = await query.CountAsync(cancellationToken);

            int pageCount = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

            var result = new PageableResponse<T>
            {
                Data = await query.ToListAsync(cancellationToken),
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                PageCount = pageCount,
                TotalRecords = totalRecords
            };

            return result;
        }
    }
}
