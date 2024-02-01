using System;
using UnityEngine;

namespace Sample
{
    public static class LessonVectors
    {
        // Максимальное количество баллов = 10

        ///Пример: Возвращает лежит ли точка point на внутри окружности с центром center и радиусом radius 
        public static bool IsPointInCircle(Vector2 center, float radius, Vector2 point)
        {
            return Vector2.Distance(center, point) <= radius;
        }

        ///Пример: Возвращает лежит ли точка point на отрезке (start, end) 
        public static bool IsPointOnLine(Vector2 start, Vector2 end, Vector2 point)
        {
            Vector2 vectorAP = point - start;
            Vector2 vectorAB = end - start;

            //Проверка коллинеарности векторов:
            float crossProduct = Vector3.Cross(vectorAP, vectorAB).z;
            if (Mathf.Abs(crossProduct) > float.Epsilon)
                return false;

            //Проверка проекций:
            float dotProduct = Vector2.Dot(vectorAP, vectorAB);
            float squaredLengthAB = vectorAB.sqrMagnitude;

            if (dotProduct < 0 || dotProduct > squaredLengthAB)
                return false;

            return true;
        }
        
        /**
         * Простая (1 балл)
         *
         * Проверить, лежит ли окружность с центром в (x1, y1) и радиусом r1 целиком внутри
         * окружности с центром в (x2, y2) и радиусом r2.
         * Вернуть true, если утверждение верно
         */
        public static bool CircleInsideCircle(
            Vector2 c1, float r1,
            Vector2 c2, float r2
        )
        {
            return Vector2.Distance(c1, c2) + r1 <= r2;
        }

        /**
        * Простая (2 балла)
        *
        * Определить, с какой стороны лежит ли точка point относительно прямой, которая задается точками start и end.
        * Если точка относительно прямой расположена слева то вернуть -1, если справа, то 1, если точка лежит на прямой, то вернуть 0
        */
        public static float PointRelativeLine(Vector2 start, Vector2 end, Vector2 point)
        {

            float dr = (point.x - start.x) * (end.y - start.y) - (point.y - start.y) * (end.x - start.x);
            
            if (dr < 0) return -1;
            if (dr > 0) return 1;

            return 0;
        }


        /**
        * Простая (2 балла)
        *
        * Определить, лежит ли точка point внутри или на периметре прямоугольника,
        * который задается двумя точками start и end
        */
        public static bool IsPointInRectangle(Vector2 start, Vector2 end, Vector2 point)
        {
            if (Math.Max(start.x, end.x) >= point.x && point.x >= Math.Min(start.x, end.x) &&
                Math.Max(start.y, end.y) >= point.y && point.y >= Math.Min(start.y, end.y)) {
                    return true;
                } else {
                    return false;
                }
        }
        
        /**
         * Средняя (3 балла)
         *
         * Определить число ходов, за которое шахматный король пройдёт из клетки start в клетку end.
         * Шахматный король одним ходом может переместиться из клетки, в которой стоит,
         * на любую соседнюю по вертикали, горизонтали или диагонали.
         * Ниже точками выделены возможные ходы короля, а крестиками -- невозможные:
         *
         * xxxxx
         * x...x
         * x.K.x
         * x...x
         * xxxxx
         *
         * Если клетки start и end совпадают, вернуть 0.
         * Если любая из клеток некорректна, бросить IllegalArgumentException().
         *
         * Пример: kingMoveNumber(Square(3, 1), Square(6, 3)) = 3.
         * Король может последовательно пройти через клетки (4, 2) и (5, 2) к клетке (6, 3).
         */
        public static int KingMoveNumber(Vector2Int start, Vector2Int end)
        {
            if (start == end) return 0;
            if (Mathf.Abs(start.x - end.x) > Mathf.Abs(start.y - end.y)) {
                return Mathf.Abs(start.x - end.x);
            } else {
                return Mathf.Abs(start.y - end.y);
            }
        }

        /**
        * Сложная (2 балла)
        *
        * Определить, пересекает ли луч ray окружность с центром center и радиусом radius
        * Описание алгоритмов см. в Интернете
        * Если начало луча находится внутри или на окружности, то вернуть false 
        */
        public static bool RayCircleIntersect(Ray ray, Vector3 center, float radius)
        {
            
            throw new NotImplementedException();
        }
    }
}