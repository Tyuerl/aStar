using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace aStar1
{
    internal class Cell : IComparable
    {//класс для ячейки поля с нахождением gFunction Hfunction
        public Cell(Point a, int  glen, Cell rod, int hlen) 
        {
            position = a;
            GLength = glen;
            FromCame = rod;
            HLength = hlen;
        }
        public Point position { get; set; }
        public int GLength { get; set; }
        public Cell? FromCame { get; set; }
        public int HLength { get; set; }
        public int Flength
        {
            get => GLength + HLength;
        }
        public int getHfunction(Point end)
        {
            return (Math.Abs(position.x - end.x) + Math.Abs(position.y - end.y));
        }


        public override bool Equals(object obj)
        {

            Cell temp = (Cell)obj;

            if (obj == null)
                return (false);
            //if (temp.GetType() != this.GetType())
            //   return (false);
            //;
            return (temp.position == this.position);
        }

        public int CompareTo(object obj) // this need for IComparable and sortedList
        {

            var temp = (Cell)obj;
            if (temp.position == position)
                return 0;
            else
                return (-1);
        }

        //public static bool operator ==(Cell a, Cell b)
        //{
        //    if (b == null || a == null)
        //        return (false);
        //    return (b.Equals(a));
        //}

        //public static bool operator !=(Cell a, Cell b) => !(b == a);


    }
}
