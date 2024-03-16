using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Race : IRace
    {
        private List<RaceObject> _raceObjects = new List<RaceObject>();
        private double _distance;
        private RaceObject[]? _winner;
        public void AddObject(RaceObject? obj, double position)
        {
            if (obj == null || (position < 0 || position >= _distance)) 
            {
                return;
            }
            //obj.position = position; <-- Asignar la posición al RaceObject
            _raceObjects.Add(obj);
        }

        public RaceObject? GetObjectAt(int index)
        {
            if(index < 0 || index >= _raceObjects.Count)
                return null;
            return _raceObjects[index];
        }

        public int GetObjectCount()
        {
            return _raceObjects.Count;
        }

        public void Init(double distance) // Inicia una carrera con una meta (distance)
        {
            if(distance <= 0)
                return;

            _distance = distance;

            while (_winner == null)
            {
                SimulateStep();
            }
        }

        public void SimulateStep() //Simula el comportamiento de un turno
        {
            
        }

        public void VisitCars(IRace.VisitCarDelegate<Car> visit)
        {
            
        }

        public void VisitDrivers(IRace.VisitDriverDlegate<Driver> visit)
        {
            
        }

        public void VisitObjects(IRace.VisitObjectDelegate<RaceObject> visit)
        {
            
        }

        public void VisitObstacles(IRace.VisitObstacleDelegate<Obstacle> visit)
        {
            
        }
    }
}
