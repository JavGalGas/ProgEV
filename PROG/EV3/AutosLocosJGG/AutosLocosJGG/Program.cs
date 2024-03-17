namespace AutosLocosJGG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRace race = new Race();
            RaceObject car1 = new GlamourCar("GlamourCar");
            RaceObject car2 = new PiereCar("PiereCar");
            RaceObject car3 = new WoodCar("WoodCar");
            RaceObject car4 = new TroglodyteCar("WoodCar");
            RaceObject obstacle1 = new Rock("Rock");
            RaceObject obstacle2 = new Puddle("Rock");
            RaceObject obstacle3 = new Bomb("Bomb",4);
            race.AddObject(car1, 20.0);
            race.AddObject(car2, 5.0);
            race.AddObject(car3, 100.0);
            race.AddObject(car4, 4000.0);
            race.AddObject(obstacle1, 2.0);
            race.AddObject(obstacle2, 20.0);
            race.AddObject(obstacle3 , 50.0);
            race.VisitCars(car =>
            {
                car.SetPosition(0.0);
            });
            for (int i = 0; i < race.GetObjectCount(); i++)
            {
                Console.WriteLine(race.GetObjectAt(i)!.Position);
            }
            




        }
    }
}
