using System;

namespace Net5.Rest.Infrastructure.Data.Entities
{
    public  class Book
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Author Author { get; set; }
    }
}