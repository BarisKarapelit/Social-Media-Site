using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _object;
        void ICategoryDal.Delete(Category category)
        {
            _object.Remove(category);
            context.SaveChanges();

        }

        void ICategoryDal.Insert(Category category)
        {
            _object.Add(category);
            context.SaveChanges();
        }

        List<Category> ICategoryDal.List()
        {
            return _object.ToList();
        }

        void ICategoryDal.Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
