using api.Models;

namespace api.Interface
{
    public interface IBillService
    {
        public Task AddBillAsync(Bill bill);
        public Task<Bill> GetBillByIdAsync(Guid billId);
        public Task<Bill> GetBillByEnrollmentIdAsync(Guid enrollmentId);
        public Task<IEnumerable<Bill>> GetAllBillsAsync();
    }
}
