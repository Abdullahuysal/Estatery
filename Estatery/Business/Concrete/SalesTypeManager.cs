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

        public async Task<List<SalesType>> GetAllSalesTypes()
        {
            var salestypes = await _salesTypeDal.GetAllAsync();
            return salestypes;
        }

        public async Task<SalesType> GetSalesType(string salesTypeName)
        {
            SalesType salesType = await _salesTypeDal.GetAsync(s => s.Name == salesTypeName);
            if (salesType != null)
            {
                return salesType;
            }
            return null;
        }

        public async Task<SalesType> GetSalesTypeById(int salesTypeId)
        {
            var salesType = await _salesTypeDal.GetAsync(s => s.Id == salesTypeId);
            return salesType;
        }
    }
}
