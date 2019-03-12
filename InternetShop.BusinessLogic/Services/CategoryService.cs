using InternetShop.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.BusinessLogic.Services
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);

        List<Category> GetAll();
        Category Get(int id);
    }
    public class CategoryService : ServiceBase, ICategoryService
    {
        private const string FilePath = @"\bin\Data\Categories.txt";
        List<Category> _categories;


        public CategoryService()
        {
            var savedData = ReadData();
            _categories = savedData != null ? savedData : new List<Category>();
        }
        public void Add(Category category)
        {
            int id = GetMaxId(_categories.OfType<IIdentifiable>().ToList());
            category.Id = id + 1;
            _categories.Add(category);

            SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = Get(id);
            if(category != null)
                _categories.Remove(category);
            SaveChanges();
        }

        public Category Get(int id)
        {
            return _categories.FirstOrDefault(x => x.Id == id);
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public void Update(Category category)
        {
            Category oldCategory = Get(category.Id);
            oldCategory.Name = category.Name;

            SaveChanges();
        }


        // File Write and Read
        private List<Category> ReadData()
        {
            var data = File.ReadAllText(GetStoragePath(FilePath));
            return JsonConvert.DeserializeObject<List<Category>>(data);
        }
        private void SavedData()
        {
            var data = JsonConvert.SerializeObject(_categories);
            File.WriteAllText(GetStoragePath(FilePath), data);
        }

        private void SaveChanges()
        {
            var data = JsonConvert.SerializeObject(_categories);

            File.WriteAllText(GetStoragePath(FilePath), data);
        }
    }
}
