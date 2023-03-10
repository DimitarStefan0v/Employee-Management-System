namespace EMS.Web.ViewModels
{
    using System;

    public abstract class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int ItemsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.ItemsCount / this.ItemsPerPage);

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string Search { get; set; }

        public string SortOrder { get; set; }
    }
}
