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
    public class SalesCategoryConverter : ISalesCategoryConverter
    {
        private ISalesCategoryDal _salesCategoryDal;
        public SalesCategoryConverter(ISalesCategoryDal salesCategoryDal)
        {
            _salesCategoryDal = salesCategoryDal;
        }
        public async Task<SalesCategory> SalesCategoryDtoToSalesCategory(SalesCategoryRequest salesCategoryRequest)
        {
            SalesCategory salesCategory = new SalesCategory();
            var salesCategoryData = await _salesCategoryDal.GetAsync(s => s.Name == salesCategoryRequest.Name);
            salesCategory.Name = salesCategoryData.Name;
            return salesCategory;
        }
    }
}
