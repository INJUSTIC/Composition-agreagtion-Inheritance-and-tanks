using System;
using System.Collections.Generic;
using System.Text;

namespace Composition_and_agregation
{
    class Gun
    {
        public double Caliber { get; }
        public int CarrelLength { get; } //CarrelLength - длина ствола
        public Gun(double Caliber, int CarrelLength)
        {
            this.Caliber = Caliber;
            this.CarrelLength = CarrelLength;
        }
        public bool IsOnTarget(int dice)
        {
            return (CarrelLength + dice) > 100;
        }
    }
}
