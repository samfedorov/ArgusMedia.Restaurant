using ArgusMedia.Restaurant.Dtos;

namespace ArgusMedia.Restaurant.Services
{
    public interface IBillService
    {
        /// <param name="isSplitBill">Do we need to split the bill for each client?</param>
        /// <returns>ClientId == null if isSplitBill == true</returns>
        Task<IEnumerable<BillReadDto>> CalculateBillAsync(IEnumerable<Guid> clientIds, bool isSplitBill);       
    }
}
