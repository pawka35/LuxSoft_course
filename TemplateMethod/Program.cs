using System;
using System.Drawing;
using System.Threading;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var volvo = new Volvo();
            volvo.TestDrive(200, 160);
            volvo.TestDrive(200, 160);

            var lada = new Lada();
            lada.TestDrive(200, 160);
            lada.TestDrive(200, 160);
        }
    }


    internal abstract class DefaultCar
    {
        protected double ExploitationPeriod { get; set; } //период эксрлуотации
        abstract protected double Drive(int distance, int maxSpeed); // поездка
        abstract protected void PrintParameter(string parameter); // вывод инфоормации о периоде эуксплуотации
        public void TestDrive(int distance, int maxSpeed) // тест-драй автомобили
        {
            ExploitationPeriod += Drive(distance, maxSpeed);     //осуществляем тест-драйв

            #region пример изменения шаблонного поведения без вмешательства в наследуемые классы
            /*
            ExploitationPeriod -= 0.2; 
            Console.WriteLine("Будь проклят тот день, когда я сел на баранку этого пылесоса!");
            */
            #endregion
            PrintParameter(Math.Round(ExploitationPeriod, 2).ToString());      // выводи информации о периоде эксплуатации автомобиля
        }
    }

    class Volvo : DefaultCar
    {

        protected override double Drive(int distance, int maxSpeed)
        {
            var spendTime = (double)distance / maxSpeed; // потраченное время на поездку
            return spendTime;
        }

        protected override void PrintParameter(string parametr)
        {
            Console.WriteLine($"Volvos has Exploitation Period equal {parametr} hours");
        }
    }

    class Lada : DefaultCar
    {
        private double BreakChanse { get; set; } //шансы на поломку

        public Lada() //при конструировании объекта закладываем % поломок в пути
        {
            var rand = new Random();
            BreakChanse = (double)rand.Next(50, 90) / 100;
        }

        protected override double Drive(int distance, int maxSpeed) //потраченное время на поездку (с учетом поломок)
        {
            var rand = new Random();
            var spendedTime = (double)distance / maxSpeed;
            spendedTime *= BreakChanse; //вот тут учитываем поломку
            return spendedTime;
        }

        protected override void PrintParameter(string parameter)
        {
            Console.WriteLine($"Период эксплуатации Лады равен {parameter} часов");
        }
    }
}
