using System;
using Census_Analyzer_Program;
using Census_Analyzer_Program.POCO;
using Census_Analyzer_Program.Datas;
using System.Collections.Generic;
using NUnit.Framework;


namespace CensusAnalyzerTest
{
    public class UnitTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State,Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderindianCensusFilePath = @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\IndiaStateCensusDatas.csv";
        static string delimiterIndianCensusFilePath = @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath= @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\IndiaStateCensusDatas.csv";
        static string wrongIndianStateCensusFileType= @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\IndiaStateCensusDatas.txt";
        static string indianStateCodeFilePath = @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType= @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\IndiaStateCodes.csv";
        static string delimiterIndianStateCodeFilePath = @"D:\BridgeLabz\Indian_State_Census\CensusAnalyzerTest\CSVFiles\DelimiterIndiaStateCensusData.csv";

        Census_Analyzer_Program.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void SetUp()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord=new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29,totalRecord.Count);
            Assert.AreEqual(37,stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(
                ()=>censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,wrongIndianStateCensusFilePath,indianStateCensusHeaders));

            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);            
        }

        [Test]

        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(
                () => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));

            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(
                () => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));

            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

    }
}

