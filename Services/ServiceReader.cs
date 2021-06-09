using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartToolingMiniProject.Services
{
    public class ServiceReader
    {
        
        string filepath = @"F:\PProject\Advanced\SmartToolingMiniProject\Model\Matrix.txt";

        CsvReader reader;


        public List<Assets> AssetList { get; set; }

        public ServiceReader()
        {
            reader = new CsvReader(filepath);
            AssetList = reader.GetAssetsFromFile();
        }
        public List<Assets> GetAssets()
        {
            return AssetList;
        }

        public List<Assets> GetMachineType(string machineType)
        {
            return AssetList.Where(x => x.MachineName == machineType).ToList();
        }

        public List<Assets> GetAssetType(string assetType)
        {
            return AssetList.Where(x => x.AssetName == assetType).ToList();
        }

        public IEnumerable<string> UpdatedSeries()
        {
            var result = new List<string>();   
            // Find out all latest asset
           
            var newSeries = AssetList.OrderByDescending(x => x.SeriesName).
                ThenBy(x => x.AssetName).
                GroupBy(x => x.AssetName).
                Select(g => g.First()).ToList();


            // remaining old series

            var remain_old_assets = AssetList.Except(newSeries).ToList();
          


            // compare between newSeries and remain_old_assets, if in old asset we found seies name 
            // that series name we'll exclude and we'll get asset that is using all latest series

            var old = remain_old_assets.Select(a => a.MachineName).ToList();
            var newm = newSeries.Select(a => a.MachineName).ToList();

            foreach (var item in newm)
            {
                if(old.Contains(item))
                {
                    continue;
                }

                result.Add(item);
            }
            return result.ToHashSet();
        }

    }
}
