using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aStar1
{
    internal class Point //класс точки 
    {

        public int x { get; set; }
        public int y { get; set; }
        

        public Point (int _x, int _y) 
        {
            x = _x;
            y = _y;
        }

        public Point(Point t)
        {
            this.x = t.x;
            this.y = t.y;
        }

        public override bool Equals(object obj)
        {
            Point temp = (Point)obj;

            if (obj == null)
                return (false);
            //if (temp.GetType() != this.GetType())
             //   return (false);
            //;
            return (temp.x == this.x && temp.y == this.y);
        }


        public static bool operator ==(Point a, Point b) => b.Equals(a);

        public static bool operator !=(Point a, Point b) => !(b == a);
    }
}
