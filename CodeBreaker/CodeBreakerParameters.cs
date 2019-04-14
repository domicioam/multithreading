using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker
{
    public class CodeBreakerParameters
    {
        private int _firstCharNumber;
        private int _lastCharNumber;
        private int _maxUnicodeCharCode;
        public int FirstCharNumber
        {
            get
            {
                return _firstCharNumber;
            }
            set
            {
                _firstCharNumber = value;
            }
        }
        public int LastCharNumber
        {
            get
            {
                return _lastCharNumber;
            }
            set
            {
                _lastCharNumber = value;
            }
        }
        public int MaxUnicodeCharCode
        {
            get
            {
                return _maxUnicodeCharCode;
            }
            set
            {
                _maxUnicodeCharCode = value;
            }
        }
    }
}
