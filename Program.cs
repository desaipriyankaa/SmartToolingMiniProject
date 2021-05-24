using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartToolingMiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            string file_path = @"F:\PProject\Advanced\MatrixLib\Matrix.txt";
            CsvReader reader = new CsvReader(file_path);
            var assets = reader.GetAssetsFromFile();
            
            try
            {
                Console.WriteLine("Enter Your Choice :");
                Console.WriteLine("1 : See Machine Type\n2 : See Asset Name\n3 : See latest series");
                choice = Int32.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Machine Name :");
                    string m_name = Console.ReadLine().ToLower();
                    var matches = assets.Where(x => x.MachineName.ToLower() == m_name).ToList<Assets>();
                    foreach (var item in matches)
                    {
                        Console.WriteLine($"{item.MachineName},{item.AssetName},{item.SeriesName}");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter Asset Name : ");
                    string a_name = Console.ReadLine().ToLower();
                    var Lines = assets.Where(x => x.AssetName.ToLower() == a_name).ToList<Assets>();
                    foreach (var lines in Lines)
                    {
                        Console.WriteLine($"{lines.MachineName},{lines.AssetName},{lines.SeriesName}");
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
