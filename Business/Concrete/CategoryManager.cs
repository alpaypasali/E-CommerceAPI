using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
   
        public IResult Add(Category category)
        {


            _categoryDal.Add(category);

            return new SuccessResult("Category added successfully.");
        }
       
        public IResult Delete(Category category)
        {


            _categoryDal.Delete(category);

            return new SuccessResult("Category deleted successfully.");
        }


        public IDataResult<List<Category>> GetCategory()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetCategoryById(int categoryid)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryid));
        }
     
        public IResult Update(Category category)
        {
            if (category.CategoryName.Length < 2)
            {
                return new ErrorResult("Category not updated successfully.");
            }

            _categoryDal.Update(category);

            return new SuccessResult("Category updated successfully.");
        }
    }
}
