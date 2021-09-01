using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Composition_and_agregation
{
    //Класс танка. Здесь используется как агрегация(передаем в качестве аргумента конструктора объект класса Gun),
    //так и композиция()
    class Panzer
    {
        public Gun gun { get; }
        public string Model { get; }
        public double Health { get; private set; } // здоровье танка
        public List<Ammo> Ammos { get; private set; } // список снарядов танка 
        public List<Armour> Armours { get; private set; }// список брони танка
        public Ammo CurrentAmmo { get; private set; }
        public Armour CurrentArmour { get; private set; }
        public double Armour_Thickness { get; }
        public Panzer(string Model, Gun gun, double Armour_Thickness, double Health)
        {
            this.Model = Model;
            this.gun = gun;
            //снаряжаем танк всеми видами брони
            Ammos = new List<Ammo>()
            {
                new HECartridge(this.gun),
                new HEATCartridge(this.gun),
                new APCartridge(this.gun)
            };
            Armours = new List<Armour>();
            //снаряжаем танк 10 снарядами каждого типа
            for (int i = 0; i < 10; i++)
            {
                Armours.Add(new HEATArmour(Armour_Thickness));
                Armours.Add(new HeArmour(Armour_Thickness));
                Armours.Add(new APArmour(Armour_Thickness));
            }
            this.Armour_Thickness = Armour_Thickness;
            this.Health = Health;
        }
        public void ChargeGun(Ammo ammo) // заряжаем пушку определенным снарядом
        {
            if (ammo == null) return;
            else
            {
                for (int i = 0; i < Ammos.Count; i++)
                {
                    if(ammo.Type == Ammos[i].Type)
                    {
                        CurrentAmmo = ammo;
                        Console.WriteLine("Снаряд готов!");
                        return;
                    }
                }
                Console.WriteLine($"Закончились снаряды типа '{ammo.Type}' ");
            }
        }
        public void SelectArmour(Armour armour) //надеваем броню на танк
        {
            if (armour == null) return;
            else
            {
                for (int i = 0; i < Armours.Count; i++)
                {
                    if(armour.Type == Armours[i].Type)
                    {
                        CurrentArmour = armour;
                        Console.WriteLine("Броня надета!");
                    }
                }
            }
        }
        public void Shoot(Panzer enemy_panzer) // Стреляем
        {
            if (CurrentAmmo == null || enemy_panzer == null) return;
            var random = new Random();
            if (gun.IsOnTarget(random.Next(0, 50)))
            {
                if (enemy_panzer.CurrentArmour.IsPenetrated(CurrentAmmo))
                {
                    Console.WriteLine($"Броня {enemy_panzer.Model} была пробита!");
                    GetDamage(enemy_panzer);
                }
                else Console.WriteLine($"Броня {enemy_panzer.Model} не была пробита!");
            }
            else Console.WriteLine("Промах");

            Ammos.Remove(CurrentAmmo); // удаляем использованный снаряд
            CurrentAmmo = null;
        }

        private void GetDamage(Panzer enemy_panzer) // регистрируем урон
        {
            enemy_panzer.Health -= CurrentAmmo.GetDamage();
            if (enemy_panzer.Health <= 0) Console.WriteLine($"Игра окончена. Победил танк {this.Model}");
            else Console.WriteLine($"Оставшееся здоровье {enemy_panzer.Model}: {enemy_panzer.Health}");
        }
    }
}
