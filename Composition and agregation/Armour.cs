using System;
using System.Collections.Generic;
using System.Text;

namespace Composition_and_agregation
{
    //создаем абстрактный класс брони
    abstract class Armour
    {
        public double Thickness { get; } // толщина брони
        public string Type { get; } // тип(имя) брони
        public Armour(double Thickness, string Type)
        {
            this.Thickness = Thickness;
            this.Type = Type;
        }
        public virtual bool IsPenetrated(Ammo ammo)  // пробило ли броню
        {
            return ammo.GetDamage() > Thickness;
        }
    }
    class HeArmour : Armour
    {
        public HeArmour(double Thickness) : base(Thickness, "гомогенная") { }
        public override bool IsPenetrated(Ammo ammo)
        {
            // В зависимости от типа снаряда увеличиваем/уменьшаем значение брони
            if(ammo is HEATCartridge)
            {
                return base.IsPenetrated(ammo);
            }
            else if(ammo is HECartridge)
            {
                return ammo.GetDamage() > Thickness*1.2;
            }
            else
            {
                return ammo.GetDamage() > Thickness * 0.8;
            }
        }
    }
    class HEATArmour : Armour
    {
        public HEATArmour(double Thickness) : base(Thickness, "противокумулятивная") { }
        public override bool IsPenetrated(Ammo ammo)
        {
            // В зависимости от типа снаряда увеличиваем/уменьшаем значение брони
            if (ammo is HEATCartridge)
            {
                return ammo.GetDamage() > Thickness * 1.2;
            }
            else if (ammo is HECartridge)
            {
                return base.IsPenetrated(ammo);               
            }
            else
            {
                return ammo.GetDamage() > Thickness * 0.8;
            }
        }
    }
    class APArmour : Armour
    {
        public APArmour(double Thickness) : base(Thickness, "противоподкалиберая") { }
        public override bool IsPenetrated(Ammo ammo)
        {
            // В зависимости от типа снаряда увеличиваем/уменьшаем значение брони
            if (ammo is HEATCartridge)
            {
                return ammo.GetDamage() > Thickness * 0.8;
            }
            else if (ammo is HECartridge)
            {
                return ammo.GetDamage() > Thickness * 0.8;
            }
            else
            {
                return ammo.GetDamage() > Thickness * 1.4;
            }
        }
    }
}
