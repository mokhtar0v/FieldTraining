
namespace DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        int Add(Customer customer);
        int Delete(int id);
        IEnumerable<Customer> GetAll(bool withTracking = false);
        Customer? GetByID(int id);
        int Update(Customer customer);
    }
}