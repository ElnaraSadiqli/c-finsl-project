using ConsoleTables;
using ProjectFinal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Services
{
    public static class MenuService

    {
        static MarketService marketService = new();

        public static void DisplayAllProduct()
        {
            try
            {
                marketService.DisplayAllProduct();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
            var table = new ConsoleTable("Name", "Quantity", "Price", "Category");

            foreach (var product in marketService.Products)
            {
                table.AddRow(product.Name, product.Quantity.ToString(), product.Price.ToString("#.00"), product.Category);
            }

            table.Write();
            Console.WriteLine();

        }  //Məhsulları cədvəl ilə ekranda əks etdirmək

        public static void DisplayByCategories()
        {


        }

        public static void AddProduct() //Məhsul əlavə etmək
        {
            


            Console.WriteLine("Məhsulun adını daxil edin");
            Console.WriteLine(":::::::::::::::::::::::::");
            string name = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Məhsulun qiymətini daxil edin");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::");
            Console.WriteLine("Məhsulun kategoriyasını daxil edin");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::");
            Console.WriteLine(" ");
            Enum.TryParse<Categories>(Console.ReadLine(), true, out Categories categories);
            Console.WriteLine("Məhsulun sayını daxil edin");
            int quantity = int.Parse(Console.ReadLine());
           
                try
            {
                marketService.AddProduct( name,  price,  quantity, categories) ;
                Console.WriteLine("Məhsul daxil edildi");
            }
            catch (Exception e)
            {
                Console.WriteLine("Zəhmət olmasa məlumatları düzgün daxil edin");
                Console.WriteLine(e.Message);
                
            }








        }
        }


    }








