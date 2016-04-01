using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogicLayout.Functions.DataHandlers;
using EntityModels.DataTransferObject;

namespace BusinessLogicLayout.Functions
{
    public class OrderTypeHandler : EntityHandler
    {
        public List<OrderTypeDTO> Get()
        {
            return UnitOfWork.OrderTypeRepository.Get().ToList().ConverToOrderTypeDtos();
        }
    }
}