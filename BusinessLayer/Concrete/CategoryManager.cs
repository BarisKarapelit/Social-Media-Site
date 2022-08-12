using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class CategoryManager
    {
        GenericRepository<Category> category = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return category.List();
        }
<<<<<<< HEAD

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
=======
        public void CategoryAddBl(Category p)
>>>>>>> parent of 7c76042 (Entity Framework Dal)
        {
            bool query = (p.CategoryName == ""|| p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51);

            if (query)
            {

            }
            else
            {
                category.Insert(p);
            }
        }

        public  void CategoryAddBl(Category category)
        {
            bool query = (category.CategoryName == "" || category.CategoryName.Length <= 3 || category.CategoryDescription == "" || category.CategoryName.Length >= 51);
            if (query.Equals(true))
            {

            }
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }
    }
}
