using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Wardrobe
    {
        public int width;
        public int depth;
        public int height;
        public int angle;
        public int top;
        public int upstand;
        public int kicker;

        public Wardrobe(int widthP, int depthP, int heightP, int angleP, int topP, int upstandP, int kickerP)
        {
            width = widthP;
            depth = depthP;
            height = heightP;
            angle = angleP;
            top = topP;
            upstand = upstandP;
            kicker = kickerP;
        }
    }
}
