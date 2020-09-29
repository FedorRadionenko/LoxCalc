using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxCalc_remake
{
    static class LoxMath
    {
        const double e = 0.08181;
        const double a = 6378.137;

        static private double deltaLong;
        static private double radCourse;
        static public double course;
        static public double distance;

        static Point start;
        static Point finish;


        //Courses in radians and in degrees calculated separately, because we need both
        static private void CourseRad()
        {
            if ((finish.Longitude - start.Longitude) > 180)
                deltaLong = finish.Longitude - start.Longitude - 360;
            else if ((finish.Longitude - start.Longitude) < -180)
                deltaLong = finish.Longitude - start.Longitude + 360;
            else
                deltaLong = finish.Longitude - start.Longitude;

            double FinishPart = Math.Pow((1 - e * Math.Sin(finish.Latitude)) / (1 + e * Math.Sin(finish.Latitude)), e / 2);
            double StartPart = Math.Pow((1 - e * Math.Sin(start.Latitude)) / (1 + e * Math.Sin(start.Latitude)), e / 2);
            double tanCourse = deltaLong / (Math.Log(Math.Tan((Math.PI / 4) + (finish.Latitude / 2)) * FinishPart) -
                                            Math.Log(Math.Tan((Math.PI / 4) + (start.Latitude / 2)) * StartPart));

            double tempCourse = Math.Atan(tanCourse);

            if ((deltaLong > 0 && tanCourse < 0) || (deltaLong < 0 && tanCourse > 0))
                radCourse = Math.PI + tempCourse;
            else if (deltaLong < 0 && tanCourse < 0)
                radCourse = 2 * Math.PI + tempCourse;
            else
                radCourse = tempCourse;
        }

        static private void Course()
        {
            course = radCourse * 180 / Math.PI;
        }

        static private void Distance()
        {
            double courseCheck = course;
            if (courseCheck == 90 || courseCheck == 270)
            {
                distance = Math.Abs(a * deltaLong * Math.Cos(start.Latitude));
            }
            distance = Math.Abs(a * (1 / Math.Cos(radCourse)) * ((1 - (0.25 * Math.Pow(e, 2))) * (finish.Latitude - start.Latitude) -
                   (0.375 * Math.Pow(e, 2) * (Math.Sin(2 * finish.Latitude) - Math.Sin(2 * start.Latitude)))));
        }

        static public void Calculate(Point first, Point second)
        {
            start = first;
            finish = second;
            CourseRad();
            Course();
            Distance();
        }
    }
}
