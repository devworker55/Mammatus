﻿using Mammatus.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mammatus.Collections.Pagination
{
    /// <summary>
    /// Extension methods for creating paged lists.
    /// </summary>
    public static class PaginationHelper
    {
        public static IPagedData<T> AsPagination<T>(this IEnumerable<T> source, int pageNumber)
        {
            return source.AsPagination(pageNumber, PagedData<T>.DefaultPageSize);
        }

        public static IPagedData<T> AsPagination<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), Resource.PageNumberGreaterThanOrEqualToZero);
            }

            return new PagedData<T>(source.AsQueryable(), pageNumber, pageSize);
        }
    }
}
