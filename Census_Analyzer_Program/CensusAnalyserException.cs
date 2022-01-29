using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Census_Analyzer_Program
{
    public class CensusAnalyserException:Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INVALID_FILE_TYPE,INCORRECT_HEADER,NO_SUCH_COUNTRY,INCORRECT_DELIMITER
        }
        public ExceptionType eType;

        public CensusAnalyserException(string message,ExceptionType exceptionType):base(message)
        {
            this.eType = exceptionType;
        }
    }
}
