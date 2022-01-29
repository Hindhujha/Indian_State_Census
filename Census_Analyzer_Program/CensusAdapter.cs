using System;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
namespace Census_Analyzer_Program
{
    public abstract class CensusAdapter
    {

        protected string[] GetCensusData(string csvFilePath,string dataHeaders)
        {
            string[] censusData;
            if(!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("Filenot Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if(Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid file type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData=File.ReadAllLines(csvFilePath);
            if(censusData[0]!=dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
            
            
            
            
    }
}
