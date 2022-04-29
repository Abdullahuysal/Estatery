using DataAccess.Abstract;
using Dtos.Requests;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Converter
{
    public class SalesTypeConverter : ISalesTypeConverter
    {
        private ISalesTypeDal _salesTypeDal;
        public SalesTypeConverter(ISalesTypeDal salesTypeDal)
        {
            _salesTypeDal = salesTypeDal;
        }
        public async Task<SalesType> SalesTypeDtoToSalesType(SalesTypeRequest salesTypeRequest)
        {
            SalesType salesType = new SalesType();
            var salesTypeData = await _salesTypeDal.GetAsync(s => s.Name == salesTypeRequest.Name);
            salesType.Name = salesTypeData.Name;
            return salesType;
        }
    }
}
