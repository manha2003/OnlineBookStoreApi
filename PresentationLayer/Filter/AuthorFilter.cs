using BusinessLogicLayer.DTOs.AuthorDTO;

namespace PresentationLayer.Filter
{
    public class AuthorFIlter
    {
        public string AuthorName { get; set; }
        public DateTime? AuthorDob { get; set; }

        public IEnumerable<AuthorDTODetails> ApplyFilter(IEnumerable<AuthorDTODetails> authors)
        {
            if (!string.IsNullOrEmpty(AuthorName))
            {
                authors = authors.Where(a => a.AuthorName.Contains(AuthorName)).ToList();
            }

            if (AuthorDob.HasValue)
            {
                authors = authors.Where(a => a.AuthorDob.Date == AuthorDob.Value.Date).ToList();
            }

            return authors;
        }
    }
}
