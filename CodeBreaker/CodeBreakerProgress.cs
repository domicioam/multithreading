using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBreaker
{
    public class CodeBreakerProgress
    {
        private int priCharNumber;
        private int priCharCode;
        private int priPercentageCompleted;

        public int CharNumber
        {
            get { return priCharNumber; }
            set { priCharNumber = value; }
        }

        public int CharCode
        {
            get { return priCharCode; }
            set { priCharCode = value; }
        }

        public int PercentageCompleted
        {
            get { return priPercentageCompleted; }
            set { priPercentageCompleted = value; }
        }
    }
}
