using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SalesTypeManager : ISalesTypeService
    {
        private ISalesTypeDal _salesTypeDal;
        public SalesTypeManager(ISalesTypeDal salesTypeDal)
        {
            _salesTypeDal = salesTypeDal;
        }
        public async Task<IDataResult<SalesType>> GetSalesType(string salesTypeName)
        {
            SalesType salesType = await _salesTypeDal.GetAsync(s => s.Name == salesTypeName);
            if (salesType != null)
            {
                return new SuccessDataResult<SalesType>(salesType);
            }
            return new ErrorDataResult<SalesType>(BusinessMessages.SalesTypeNotFound);
        }
    }
}
