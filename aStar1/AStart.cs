using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace aStar1
{
    internal class AStart
    {
        SortedList<Cell, int> array = new SortedList<Cell, int>();
        List<Cell> closedArray = new List<Cell>();
        Cell Path;
        
        /// <summary>
        /// Метод необходимый для получения соседних вершин(в данном случае просто соседей
        /// слева справа сверху снизу
        /// </summary>
        /// <param name="qur"> нынешняя клетка</param>
        /// <param name="ar"> сам массив карты</param>
        /// <param name="end"> позиция для победы</param>
        /// <returns></returns>
        private SortedList<Cell, int> GetCellNear(Cell qur, int[,] ar, Point end)
        {
            SortedList<Cell, int> nearCells = new SortedList<Cell, int>();
            Point[] nearPoints = new Point[4];
            nearPoints[0] = new Point(qur.position.x + 1, qur.position.y);
            nearPoints[1] = new Point(qur.position.x - 1, qur.position.y);
            nearPoints[2] = new Point(qur.position.x, qur.position.y + 1);
            nearPoints[3] = new Point(qur.position.x, qur.position.y - 1);

            foreach (Point t in nearPoints)
            {
                if (t.x < 0 || t.y < 0)
                    continue;
                if (t.x >= ar.GetLength(1) || t.y >= ar.GetLength(0))
                    continue;
                if (ar[t.y, t.x] == 1)
                    continue;
                Cell newCell = new Cell(t, qur.GLength + 1, qur, 0);
                newCell.HLength = newCell.getHfunction(end);
                nearCells.Add(newCell, newCell.Flength);
            }
            return (nearCells);
        }
        /// <summary>
        /// получить список вершин от конца до победы
        /// </summary>
        /// <returns></returns>
        public List<Point> GetPath()
        {
            var result = new List<Point>();
            var currentNode = Path;
            while (currentNode != null && !currentNode.Equals(null))
            {
                result.Add(currentNode.position);
                currentNode = currentNode.FromCame;
            }
            result.Reverse();
            return result;
        }


        /// <summary>
        /// само решение и проверка существует ли оно
        /// </summary>
        /// <param name="field"> массив краты</param>
        /// <param name="start"> позиция начала</param>
        /// <param name="end"> позиция конца</param>
        /// <returns></returns>
        public bool Solution(int [,] field, Point start, Point end)
        {
            Cell firstCell = new Cell(new Point(0, 0), 0, null, 0);
            firstCell.HLength = firstCell.getHfunction(end);
            array.Add(firstCell, firstCell.Flength);
            while (array.Count > 0)
            {
                Cell cur = array.First().Key;
                if (cur.position.x == 39 && cur.position.y == 49)
                    Console.WriteLine("ну хоть что-то");
                if (cur.position == end)
                {
                    Path = cur;
                    return true;
                }
                array.RemoveAt(0);
               // Console.WriteLine(cur.position.y + " " + cur.position.x);

                if (!closedArray.Contains(cur))
                    closedArray.Add(cur);
                foreach(Cell nearElement in GetCellNear(cur, field, end).Keys)
                {
                    if (closedArray.Contains(nearElement))
                    {
                        continue;
                    }
                    if (!array.ContainsKey(nearElement))
                    {
                      //  Console.WriteLine("добавили " + nearElement.position.y + " " + nearElement.position.x);
                        array.Add(nearElement, nearElement.Flength);
                    }
                    else if (array.ContainsKey(nearElement) &&
                        nearElement.Flength < array[nearElement])
                    {
                        array.Remove(nearElement);
                        array.Add(nearElement, nearElement.Flength);
                    }

                }
            }
            return false;
            Console.WriteLine("dsfsd");
            ;
        }
    }
}
