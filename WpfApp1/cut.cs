using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    public class cut
    {
        public int length = 0;
        public int width = 0;
        public int numberOf = 0;
        public bool toLong;
        public string title;

        public cut(int lengthP, int widthP, int numberOfP, bool toLongP, string titleP)
        {
            length = lengthP;
            width = widthP;
            numberOf = numberOfP;
            toLong = toLongP;
            title = titleP;
        }
    }
}
