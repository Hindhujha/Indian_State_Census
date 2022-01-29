using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Census_Analyzer_Program.Datas;

namespace Census_Analyzer_Program
{
    public class CensusAnalyser 
    {
        public enum Country
        {
            INDIA,US,BRAZIL
        }
        Dictionary<string, CensusDTO> dataMap;
        Dictionary<string,CensusDTO> LoadCensusData(Country country,string csvFilePath,string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
