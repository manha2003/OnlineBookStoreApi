using BusinessLogicLayer.DTOs.OrderDTO;

namespace PresentationLayer.Filter
{
    public class OrderFilter
    {
        public int UserId { get; set; }
        public DateTime? OrderDate { get; set; }

        public IEnumerable<OrderDTODetails> ApplyFilter(IEnumerable<OrderDTODetails> orders)
        {
            if (UserId != 0)
            {
                orders = orders.Where(o => o.CartId == UserId).ToList();
            }

            if (OrderDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.Date == OrderDate.Value.Date).ToList();
            }

            return orders;
        }
        }
    }

