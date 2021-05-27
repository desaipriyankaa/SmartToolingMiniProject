using System;
using System.Collections.Generic;
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
            return AssetList.Select(x=>x).Where(x => x.MachineName == machineType).ToList();
        }

        public List<Assets> GetAssetType(string AssetType)
        {
            return AssetList.Where(x => x.AssetName == AssetType).ToList();
        }


    }
}
