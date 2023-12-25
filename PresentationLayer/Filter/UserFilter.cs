using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.DTOs.UserDTO;
using System.Globalization;

namespace PresentationLayer.Filter
{
    public class UserFilter
    {
        public string UserName { get; set; }
        public string UserDoB { get; set; }

        public IEnumerable<UserDTODetails> ApplyFilter(IEnumerable<UserDTODetails> users)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                users = users.Where(u => u.UserName.Contains(UserName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(UserDoB))
            {
                DateTime parsedUserDoB;
                if (DateTime.TryParseExact(UserDoB, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedUserDoB))
                {
                    users = users.Where(u => DateTime.Parse(u.UserDob).Date == parsedUserDoB.Date).ToList();
                }
            }

            return users;
        }

    }
}
