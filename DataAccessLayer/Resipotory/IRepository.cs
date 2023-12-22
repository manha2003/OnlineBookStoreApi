using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        #region User Validation
        //Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);
        //Task<bool> IsAddressUniqueAsync(string address);
        //Task<bool> IsEmailUniqueAsync(string email);
        #endregion

        #region Book Validation
        Book GetBookByTitle( string title );

        #endregion
    }
}

