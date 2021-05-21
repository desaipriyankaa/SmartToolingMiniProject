using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmartToolingMiniProject
{
    class CsvReader
    {
        private string _csvFilePath;
        public CsvReader(string csvfilePath)
        {
            this._csvFilePath = csvfilePath;
        }
        public List<Assets> GetAssetsFromFile()
        {
            var AssetsList = new List<Assets>();
            using (StreamReader reader = new StreamReader(_csvFilePath))
            {
                string csvLine;
                while ((csvLine = reader.ReadLine()) != null)
                {
                    Assets asset = ReadAssetsFromCsvLine(csvLine);
                    AssetsList.Add(asset);
                }
            }
            return AssetsList;
        }

        public Assets ReadAssetsFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            //string machineName;
            //string assetName;
            //string seriesName;

            
            //        machineName = parts[0];
            //        assetName = parts[1];
            //        seriesName = parts[2];


                  
            return new Assets() { MachineName=parts[0], AssetName=parts[1], SeriesName=parts[2]};
        }
    }
}
