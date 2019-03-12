using InternetShop.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InternetShop.BusinessLogic.Services
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

        List<Product> GetAll();
        Product Get(int id);
    }
    public class ProductService : ServiceBase, IProductService
    {
        private const string FilePath = @"\bin\Data\Products.txt";
        private List<Product> _products;

        public ProductService()
        {
            var savedData = ReadData();
            _products = savedData != null ? savedData : new List<Product>();
        }

        public void Add(Product product)
        {
            int id = GetMaxId(_products.OfType<IIdentifiable>().ToList());
            product.Id = id + 1;
            _products.Add(product);
            SaveChanges();
        }
        

        public void Delete(int id)
        {
            Product product = Get(id);
            if(product != null)
                _products.Remove(product);
            SaveChanges();
        }

        public Product Get(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            if(_products != null)
                return _products;
            return null;
        }

        public void Update(Product product)
        {
            Product oldProduct = Get(product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.CategoryId = product.CategoryId;

            SaveChanges();
        }

        private List<Product> ReadData()
        {
            var data = File.ReadAllText(GetStoragePath(FilePath));
            return JsonConvert.DeserializeObject<List<Product>>(data);
        }
        private void SaveChanges()
        {
            var data = JsonConvert.SerializeObject(_products);
            File.WriteAllText(GetStoragePath(FilePath), data);
        }
    }
}
