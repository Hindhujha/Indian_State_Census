using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Census_Analyzer_Program.POCO;
using Census_Analyzer_Program.Datas;

namespace Census_Analyzer_Program
{
    public class CSVAdapterFactory
    {
      public  Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
      {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
            return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);

             ///   case (CensusAnalyser.Country.US):


       ///   return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("NO SUCH COUNTRY", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
      }

    }
}
