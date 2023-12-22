using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.DTOs.UserDTO;

namespace PresentationLayer.Filter
{
    public class UserFilter
    {
        public string UserName { get; set; }
        public DateTime? UserDoB { get; set; }

        public IEnumerable<UserDTODetails> ApplyFilter(IEnumerable<UserDTODetails> users)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                users = users.Where(u => u.UserName.Contains(UserName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (UserDoB.HasValue)
            {
                // Assuming you want to filter users with the exact date
                users = users.Where(u => u.UserDob.Date == UserDoB.Value.Date).ToList();
            }

            return users;
        }

    }
}
