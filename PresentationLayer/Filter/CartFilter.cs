using BusinessLogicLayer.DTOs.CartDTO;

namespace PresentationLayer.Filter
{
    public class CartFilter
    {
        public int UserId { get; set; }
        public DateTime? CreatedAfter { get; set; }

        public IEnumerable<CartDTOAdditionalDetails> ApplyFilter(IEnumerable<CartDTOAdditionalDetails> carts)
        {
            if (UserId != 0)
            {
                carts = carts.Where(c => c.UserId == UserId).ToList();
            }

            return carts;
        }
    }
}
