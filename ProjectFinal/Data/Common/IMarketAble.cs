using ProjectFinal.Entities;
using ProjectFinal.Enums;
using System;
using System.Collections.Generic;


namespace ProjectFinal.Data.Common


{
    public interface IMarketAble
    {
        #region Lists
        public List<Product> Products { get; }
        public List<Sale> Sales { get; }
       
        #endregion

        #region Product Metods
        public  int AddProduct(string name, double price, int quantity, Categories category);
        public void ProductAdjustByCode(int no,string newName,double newPrice,int newQuantity,Categories newCategory);
        public void DeleteProduct(int no);
        public List<Product> DisplayAllProduct();
        public List<Product> DisplayByCategories(Categories category);
        public List<Product> ProductsByPriceRange(double minPrice, double maxPrice);
        public List<Product> SearchByName(string name);

        #endregion

        #region Sales Metods
       public void SalesAdd(int noProduct, int quantity); 
       public void SalesDelete(int no);
       public void RemoveFromSales(string name, int returnQuantity, int saleNo);
       public List<Sale> DisplaySales();
       public List<Sale> SalesByDateRange(DateTime startDate,DateTime endDate );
       public List<Sale> SalesByPriceRange(double minPrice,double maxPrice); //Daxil edilən qiymət aralığında satışın qaytaılması
       public List<Sale> SalesByDateTime(DateTime date);  //Daxil edilən tarixə əsasən satışın göstərilməsi
       public Sale SalesBySelectNo(int no);        //Daxil edilən nömrəyə əsasən satışı qaytarır.


        #endregion
   
    }
   
}
