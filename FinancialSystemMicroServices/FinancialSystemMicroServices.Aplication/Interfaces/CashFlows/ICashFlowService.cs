using System.Threading.Tasks;
using FinancialSystemMicroServices.Domain.VOs;

namespace FinancialSystemMicroServices.Aplication.Interfaces.CashFlows
{
    public interface ICashFlowService
    {
        Task<IEnumerable<CashFlowsVO>> GetByDateRange(DateTime initialDate, DateTime finalDate);
    }
}
