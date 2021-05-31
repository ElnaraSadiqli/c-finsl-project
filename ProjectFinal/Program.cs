using ProjectFinal.Services;
using System;
using System.Text;

namespace ProjectFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int selection = 0;
            int productOption = 0;



            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("*****************Bravo Supermarket******************");
            Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine(" ");
            do
            {
                Console.WriteLine("Zəhmət olmasa seçiminizi edin");
                Console.WriteLine(" ");
                Console.WriteLine("1.Məhsullar üzərində əməliyyat aparmaq");
                Console.WriteLine(" ");
                Console.WriteLine("2.Satışlar üzərində əməliyyat aparmaq");
                Console.WriteLine(" ");
                Console.WriteLine("3.Sistemdən çıxmaq");
                Console.WriteLine("  ");



                int.TryParse(Console.ReadLine(), out selection);


            } while (selection <= 0 || selection > 3);

            switch (selection)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Siz məhsullar üzərində əməliyyat aparmağı seçdiniz.");
                        Console.WriteLine("Zəhmət olmasa seçiminizi edin");

                        Console.WriteLine("1.Yeni məhsul əlavə etmək");
                        Console.WriteLine("2.Məhsul üzərində düzəliş etmək");
                        Console.WriteLine("3.Bütün məhsulları ekranda göstərmək");
                        Console.WriteLine("4.Kategoriyasına görə məhsulları göstərmək");
                        Console.WriteLine("5.Seçilmiş qiymət aralığina görə məhsulları göstərmək");
                        Console.WriteLine("6.Daxil edilən ada görə məhsulları göstərmək");
                        Console.WriteLine("7.Məhsul silmək");

                        int.TryParse(Console.ReadLine(), out productOption);

                    } while (productOption <= 0 || productOption > 7);

                    switch (productOption)
                    {
                        case 1:
                            MenuService.AddProduct();
                            break;
                        case2:
                            MenuService.DisplayAllProduct();
                            break;
                    } while (productOption != 0) ;
                    
                    break;
                
            }
        }   
    }
}

    


   

   