using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmartToolingMiniProject
{
    public class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilepath)
        {
            _csvFilePath = csvFilepath;
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

        private Assets ReadAssetsFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            return new Assets() { MachineName=parts[0], AssetName=parts[1], SeriesName=parts[2]};
        }
    }
}
