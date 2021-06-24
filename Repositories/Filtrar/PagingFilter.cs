using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Filtrar
{
    public class PagingFilter
    {
        const int maxPageSize = 200;
        private int count;
        internal bool previousPage { get; private set; }
        internal bool nextPage { get; private set; }
        internal int CurrentPage { get; private set; }
        internal int TotalCount { get; private set; }
        internal int TotalPages { get; private set; }
        public int pageNumber { get; set; } = 1;

        internal int _pageSize { get; private set; } = 15;

        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public async Task<List<TypeOfValue>> GetItems<TypeOfValue>(IQueryable<TypeOfValue> src)
        {
            this.count = src.Count();
            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            this.CurrentPage = this.pageNumber;
            // Parameter is passed from Query string if it is null then it default Value will be pageSize:70  
            this.pageSize = this.pageSize;
            // Display TotalCount to Records to User  
            this.TotalCount = count;
            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            // Returns List of Customer after applying Paging   
            var items = await src.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            // if CurrentPage is greater than 1 means it has previousPage  
            this.previousPage = CurrentPage > 1;
            // if TotalPages is greater than CurrentPage means it has nextPage  
            this.nextPage = CurrentPage < TotalPages;
            // Object which we are going to send in header

            return items;
        }
        public async Task<List<TypeOfValue>> GetItems<TypeOfValue>(List<TypeOfValue> src)
        {
            this.count = src.Count();
            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            this.CurrentPage = this.pageNumber;
            // Parameter is passed from Query string if it is null then it default Value will be pageSize:70  
            this.pageSize = this.pageSize;
            // Display TotalCount to Records to User  
            this.TotalCount = count;
            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            // Returns List of Customer after applying Paging   
            var items = src.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
            // if CurrentPage is greater than 1 means it has previousPage  
            this.previousPage = CurrentPage > 1;
            // if TotalPages is greater than CurrentPage means it has nextPage  
            this.nextPage = CurrentPage < TotalPages;
            // Object which we are going to send in header

            return items;
        }

        public PagingMeta GetMeta()
        {
            return new PagingMeta
            {
                TotalCount = TotalCount,
                PageSize = pageSize,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
                PreviousPage = previousPage,
                NextPage = nextPage
            };
        }
    }

    public class PagingMeta
    {
        public int TotalCount;
        public int PageSize;
        public int CurrentPage;
        public int TotalPages;
        public bool PreviousPage;
        public bool NextPage;
    }
}
