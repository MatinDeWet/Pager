﻿namespace Pager.Models
{
    public class PageableRequest
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
