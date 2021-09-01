using System;
using System.Collections.Generic;
using System.Text;

namespace Composition_and_agregation
{
    //создаем абстрактный класс снаряда. Здесь используется агрегация(объект класса Gun передается в качестве аргумента конструктора)
    abstract class Ammo
    {
        public string Type { get; } // тип(имя) снаряда
        public Gun gun { get; } // дуло, в котором будет снаряд
        public Ammo(Gun gun, string Type)
        {
            this.gun = gun;
            this.Type = Type;
        }
        public virtual double GetDamage()
        {
            return gun.Caliber * 3;
        }
    }
    //Создаем 3 конкретных класса снарядов, которые наследуем от абстрактного Ammo и переопределяем GetDamage 
    class HECartridge : Ammo
    {
        public HECartridge(Gun gun) : base(gun, "фугасный") { }
        public override double GetDamage()
        {
            return base.GetDamage();
        }
    }
    class HEATCartridge : Ammo
    {
        public HEATCartridge(Gun gun) : base(gun, "кумулятивный") { }
        public override double GetDamage()
        {
            return base.GetDamage() * 0.6;
        }
    }
    class APCartridge : Ammo
    {
        public APCartridge(Gun gun) : base(gun, "подкалиберный") { }
        public override double GetDamage()
        {
            return base.GetDamage() * 0.3;
        }
    }
}
