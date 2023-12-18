using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime UserDob { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }

        public Cart? Cart { get; set; }
        public Order? Order { get; set; }
    }
}
