using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoxCalc_remake
{
    class Point
    {
        public double Latitude 
        {
            get
            {
                //Value recived in degrees/minutes/seconds, but converted to radians for futher calculations
                //North is positive value, South is negative
                if (isNorth)
                    return (latitudeDegrees + latitudeMinutes / 60 + latitudeSeconds / 3600) * Math.PI / 180;
                else
                    return -((latitudeDegrees + latitudeMinutes/ 60 + latitudeSeconds/ 3600) * Math.PI / 180);
            }
        }
        public bool isNorth;
        public double latitudeDegrees;
        public double latitudeMinutes;
        public double latitudeSeconds;

        public double Longitude
        {
            get
            {
                //Value recived in degrees/minutes/seconds, but converted to radians for futher calculations
                //East is positive value, West is negative
                if (isEast)
                    return (longitudeDegrees + longitudeMinutes / 60 + longitudeSeconds / 3600) * Math.PI / 180;
                else
                    return -((longitudeDegrees + longitudeMinutes / 60 + longitudeSeconds/ 3600) * Math.PI / 180);
            }
        }
        public bool isEast;
        public double longitudeDegrees;
        public double longitudeMinutes;
        public double longitudeSeconds;

        public Point()
        {
            isNorth = true;
            isEast = true;
        }
    }
}
