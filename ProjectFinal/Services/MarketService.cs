using ProjectFinal.Data.Common;
using ProjectFinal.Entities;
using ProjectFinal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Services
{
    public class MarketService : IMarketAble
    {

        #region LIst Services

        public MarketService()
        {
            _sales = new();
            _products = new();
        }

        private List<Product> _products;
        public List<Product> Products => _products;
      
        private List<Sale> _sales;
        public List<Sale> Sales => _sales;


        #endregion

        #region Product Services
        public int AddProduct(string name, double price, int quantity, Categories category)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("quantity");
            if (price <= 0)
                throw new ArgumentOutOfRangeException("price");


             Product product = new Product();
             product.Name=name;
             product.Price=price;
             product.Quantity = quantity;
             product.Category = category;


            _products.Add(product);
            return product.No;


        }

      

        public void DeleteProduct(int no)
        {
           
            int index = _products.FindIndex(p => p.No == no);
            if (index == -1)
                throw new KeyNotFoundException();

            _products.RemoveAt(index);

        }

        public List<Product> DisplayAllProduct()
        {

            return _products;
        }

        public List<Product> DisplayByCategories(Categories category)
        {
            List<Product> products=_products.FindAll(p => p.Category == category);
            return products;
        }

        public void ProductAdjustByCode(int no, string newName, double newPrice, int newQuantity, Categories newCategory)
        {
            int index = _products.FindIndex(p => p.No == no);
            if (index == -1)
                throw new KeyNotFoundException();

            if (string.IsNullOrEmpty(newName))
                throw new ArgumentNullException("newName");
            if (newQuantity <= 0)
                throw new ArgumentOutOfRangeException("newQuantity");
            if (newPrice <= 0)
                throw new ArgumentOutOfRangeException("newPrice");

            Product product = new Product();
            product.Name = newName;
            product.Price = newPrice;
            product.Quantity = newQuantity;
             
            


           
        }

        public List<Product> ProductsByPriceRange(double minPrice, double maxPrice)
        {
            if (minPrice <= 0)
                throw new ArgumentOutOfRangeException("minPrice");
            if (maxPrice <= 0)
                throw new ArgumentOutOfRangeException("maxPrice");
            Product product = new Product();

            List<Product> products = _products.FindAll(p => p.Price >=minPrice && p.Price>=maxPrice);

            return products;




        }

        internal void AddProduct(string name, string quantity, string category, double v)
        {
            throw new NotImplementedException();
        }

        public List<Product> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            List<Product> products = _products.FindAll(p => p.Name.Contains(name));

            return products;

        }

        #endregion

        #region Sale Services

        #region Satışdan məhsulun çıxarılması
        public void RemoveFromSales(string name, int returnQuantity, int saleNo)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
           
            if (returnQuantity <= 0)
                throw new ArgumentOutOfRangeException("returnQuantity");


            if (saleNo <= 0)
                throw new KeyNotFoundException();
          

            Sale sale = _sales.Find(s => s.No == saleNo);
            if (sale == null)
                throw new ArgumentNullException("sale");

            SalesItem salesItem = sale.SalesItems.Find(sI => sI.Cost == returnQuantity);
            if (salesItem == null)
                throw new ArgumentNullException("salesitem");

            _sales.Remove(sale);
            
        }
        #endregion

        #region Yeni satışın daxil edilməsi
        public void SalesAdd(int noProduct, int quantity)
        {
            if (noProduct <= 0)
                throw new ArgumentOutOfRangeException("noProduct");

            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("quantity");

            Product product = _products.Find(p => p.No == noProduct);

            if (product == null)
                throw new ArgumentNullException("product");

            if ((product.Quantity - quantity) <= 0)
                throw new ArgumentOutOfRangeException("quantity");

            SalesItem salesItem = new SalesItem();
            salesItem.Amount = quantity;
            salesItem.Product = product;

            Sale sale = new Sale();
            sale.Date = DateTime.Now;
            sale.SalesItems.Add(salesItem);
            sale.Cost = product.Price * quantity;

            product.Quantity -= quantity;

        }
        #endregion

        #region Tarix aralığina görə satışın qaytarılması
        public List<Sale> SalesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Sale> sales = _sales.FindAll(s => s.Date >= startDate && s.Date <= endDate);
            return sales;
        }
        #endregion

        #region Qiymət aralığina görə satışın tapılması
        public List<Sale> SalesByPriceRange(double minPrice, double maxPrice)
        {
            if (minPrice <= 0)
            {
                throw new ArgumentOutOfRangeException("minPrice");
            }
            if (maxPrice <= 0)
            {
                throw new ArgumentOutOfRangeException("maxPrice");
            }
           
            List<Sale> sales = _sales.FindAll(s => s.Cost <= maxPrice && s.Cost >= minPrice); //Satışlar listində satışın min və max qiymətini tapır
            return sales;

        }
        #endregion

        #region Daxil edilən no ya görə satışın tapılması
        public Sale SalesBySelectNo(int no)
        {
            if (no <= 0)
            {
                throw new ArgumentOutOfRangeException("no");
            }
            Sale sale = _sales.Find(s => s.No == no);
            if(sale==null)
            {
                throw new ArgumentNullException("sale");
            }
            
            return sale;

        }

        #endregion

        #region Satışların ekranda əks olunması
       public List<Sale> DisplaySales()
        {
            return _sales;
        }
        #endregion

        #region Satışın silinməsi
        void IMarketAble.SalesDelete(int no)
        {
            if (no <= 0) 
            {
                throw new ArgumentOutOfRangeException("no");
            }
            Sale sale = _sales.Find(s => s.No == no);
            if(sale==null)
            {
                throw new ArgumentNullException("sale");
            }
        }
        #endregion
        public List<Sale> SalesByDateTime(DateTime date)
        {
            List<Sale> sales = _sales.FindAll(s => s.Date >= date);
            return sales;
           

        }

        
        #endregion







        
    }
}
