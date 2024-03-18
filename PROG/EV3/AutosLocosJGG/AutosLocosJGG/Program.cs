namespace AutosLocosJGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race();
            double finishLine = 5000.0;
            RaceObject car1 = new GlamourCar("GlamourCar");
            RaceObject car2 = new PiereCar("PiereCar");
            RaceObject car3 = new WoodCar("WoodCar");
            RaceObject car4 = new TroglodyteCar("TroglodyteCar");
            RaceObject obstacle1 = new Rock("Rock");
            RaceObject obstacle2 = new Puddle("Rock");
            RaceObject obstacle3 = new Bomb("Bomb", 4);
            race.AddObject(car1, 20.0);
            race.AddObject(car2, 5.0);
            race.AddObject(car3, 100.0);
            race.AddObject(car4, 4000.0);
            race.AddObject(obstacle1, Utils.GetRandomBetween(0, finishLine));
            race.AddObject(obstacle2, Utils.GetRandomBetween(0, finishLine));
            race.AddObject(obstacle3, Utils.GetRandomBetween(0, finishLine));
            race.Init(finishLine);
            race.PrintWinners();
 
            //race.VisitObjects(obj =>
            //{
            //    obj.SetObjectPosition(0.0);
            //});
            //for (int i = 0; i < race.GetObjectCount(); i++)
            //{
            //    Console.WriteLine(race.GetObjectAt(i)!.Position);
            //}
        }
    }
}
