using System;

namespace HelloWorldMath
{
    internal struct AngleStruct
    {
        private double angleRadians; // angle in radians
        public double AngleDegrees // PROPERTY – angle in degrees
        {
            get { return angleRadians * 180.0 / Math.PI; }
            set { angleRadians = value / 180.0 * Math.PI; }
        }
    }
}