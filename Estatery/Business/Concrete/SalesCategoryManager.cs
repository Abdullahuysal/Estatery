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

        public async Task<List<SalesCategory>> GetAllSalesCategories()
        {
            var salescategories = await _salesCategoryDal.GetAllAsync();
            return salescategories;
        }

        public async Task<SalesCategory> GetSalesCategory(string salesCategoryName)
        {
            SalesCategory salesCategory = await _salesCategoryDal.GetAsync(s => s.Name == salesCategoryName);
            if(salesCategory != null)
            {
                return salesCategory;
            }
            return null;
        }

        public async Task<SalesCategory> GetSalesCategoryById(int salesCategoryId)
        {
            var salesCategory = await _salesCategoryDal.GetAsync(s => s.Id == salesCategoryId);
            return salesCategory;
        }
    }
}
