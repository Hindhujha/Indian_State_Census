using System;
using System.Collections.Generic;
using System.Linq;
using Census_Analyzer_Program.POCO;
using Census_Analyzer_Program.Datas;

namespace Census_Analyzer_Program
{
    public class IndianCensusAdapter:CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath,string dataHeaders)
        {
            dataMap = new Dictionary<string,CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach(string data in censusData.Skip(1))
            {
                if(!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] coloumn = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                {
                    dataMap.Add(coloumn[1], new CensusDTO(new stateCodeDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                {
                    dataMap.Add(coloumn[0], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                }
               
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);

        }
    }
}
