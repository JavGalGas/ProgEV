using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutosLocosJGG.IRace;

namespace AutosLocosJGG
{
    public interface IRace
    {
        delegate void VisitDriverDlegate<T>(Driver driver);
        delegate void VisitCarDelegate<T>(Car car);
        delegate void VisitObstacleDelegate<T>(Obstacle car);
        delegate void VisitObjectDelegate<T>(RaceObject car);


        void AddObject(RaceObject obj, double position);
        void Init(double distance);
        void SimulateStep();
        void VisitDrivers(VisitDriverDlegate<Driver> visit);
        void VisitCars(VisitCarDelegate<Car> visit);
        void VisitObstacles(VisitObstacleDelegate<Obstacle> visit);
        void VisitObjects(VisitObjectDelegate<RaceObject> visit);
        int GetObjectCount();
        RaceObject? GetObjectAt(int index);
        int IndexOf(RaceObject obj);
    }
}
