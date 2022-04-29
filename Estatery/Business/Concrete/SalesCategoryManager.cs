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
    public class SalesCategoryManager : ISalesCategoryService
    {
        private ISalesCategoryDal _salesCategoryDal;
        public SalesCategoryManager(ISalesCategoryDal salesCategoryDal)
        {
            _salesCategoryDal = salesCategoryDal;
        }
        public async Task<IDataResult<SalesCategory>> GetSalesCategory(string salesCategoryName)
        {
            SalesCategory salesCategory = await _salesCategoryDal.GetAsync(s => s.Name == salesCategoryName);
            if(salesCategory != null)
            {
                return new SuccessDataResult<SalesCategory>(salesCategory);
            }
            return new ErrorDataResult<SalesCategory>(BusinessMessages.SalesCategoryNotFound);
        }
    }
}
