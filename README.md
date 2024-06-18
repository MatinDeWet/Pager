# Pager

[![CodeFactor](https://www.codefactor.io/repository/github/matindewet/pager/badge)](https://www.codefactor.io/repository/github/matindewet/pager)
[![NuGet Version](https://img.shields.io/nuget/v/MatinDeWet.Pager)](https://www.nuget.org/packages/MatinDeWet.Pager) 
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/MatinDeWet/Pager/dotnet.yml)](https://github.com/MatinDeWet/Pager)

Pager was designed to make it easy to paginate data in .NET applications making use of Entity Framework Core. It is a simple library that can be used to paginate any collection of data. It is designed to be easy to use and easy to extend.

## Usage
To use Pager, you need to call the `Paginate` extension method on an `IQueryable<T>` object, you need to supply the method with a `PageableRequest` and `cancelation token`. This will return a `PagedResult<T>` object that contains the paginated data.

```C#
    var request = new PageableRequest
    {
        PageNumber = 1,
        PageSize = 10
    };

    var result = await _context.Clients.ToPageableListAsync(request, cancellationtoken);
```
You can specify the page number and the page size in the `PageableRequest` object. The `PageNumber` is the page you want to retrieve and the `PageSize` is the number of items you want to retrieve.

The `PagedResult<T>` object contains the following:
```C#
    public class PageableResponse<T>
    {
        public IEnumerable<T> Data { get; set; } // The data for the current page

        public int TotalRecords { get; set; } // The total number of records in the collection

        public int PageNumber { get; set; } // The current page number

        public int PageSize { get; set; } // The number of items per page

        public int PageCount { get; set; } // The total number of pages
    }
```
