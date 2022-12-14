using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        #region İlkel Versiyonu CategoryAdd
        //GenericRepository<Category> category = new GenericRepository<Category>();

        //public List<Category> GetAll()
        //{
        //    return category.List();
        //}
        //public void CategoryAddBl(Category p)
        //{
        //    bool query = (p.CategoryName == ""|| p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51);

        //    if (query)
        //    {

        //    }
        //    else
        //    {
        //        category.Insert(p);
        //    }
        //}

        #endregion

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        //public  void CategoryAddBl(Category category)
        //{
        //    bool query = (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryDescription == "" || category.CategoryName.Length >= 51);
        //    if (query.Equals(true))
        //    {

        //    }
        //}

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x=>x.CategoryID==id);

        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

       

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
