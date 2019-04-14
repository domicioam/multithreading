using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker
{
    public class CodeBreakerResult
    {
        private int priFirstCharNumber;
        private int priLastCharNumber;
        private string prsBrokenCode;
        public int FirstCharNumber
        {
            get
            {
                return priFirstCharNumber;
            }
            set
            {
                priFirstCharNumber = value;
            }
        }
        public int LastCharNumber
        {
            get
            {
                return priLastCharNumber;
            }
            set
            {
                priLastCharNumber = value;
            }
        }
        public string BrokenCode
        {
            get
            {
                return prsBrokenCode;
            }
            set
            {
                prsBrokenCode = value;
            }
        }
    }
}
