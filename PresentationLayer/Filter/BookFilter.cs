using BusinessLogicLayer.DTOs.BookDTO;

namespace PresentationLayer.Filter
{
    public class BookFilter
    {
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public IEnumerable<BookDTODetails> ApplyFilter(IEnumerable<BookDTODetails> books)
        {
            return books
                .Where(b => string.IsNullOrEmpty(Title) || b.Title.Contains(Title, StringComparison.OrdinalIgnoreCase))
                .Where(b => string.IsNullOrEmpty(AuthorId) || b.AuthorId.Contains(AuthorId, StringComparison.OrdinalIgnoreCase))
                .Where(b => MinPrice == null || b.Price >= MinPrice)
                .Where(b => MaxPrice == null || b.Price <= MaxPrice);
        }
    }
}
