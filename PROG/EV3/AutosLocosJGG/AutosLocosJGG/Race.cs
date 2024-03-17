using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (obj == null || position < 0) 
            {
                return;
            }
            //obj. = position; < --Asignar la posición al RaceObject
            _raceObjects.Add(obj);
        }

        public int IndexOf(RaceObject obj)
        {
            if (obj == null)
                return -1;
            for (int i = 0; i < GetObjectCount(); i++)
            {
                if (obj.Equals(GetObjectAt(i)))
                    return i;
            }
            return -1;
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
            foreach(Obstacle obj in _raceObjects)
            {
                if(obj.Position > distance)
                {
                    return;
                }
            }

            _distance = distance;

            VisitCars(car =>
            {
                car.SetPosition(0.0);
            });
            //foreach(Car car in _raceObjects)
            //{
            //    car.SetPosition(0.0);
            //}

            while (_winner == null)
            {
                SimulateStep();
            }
        }

        public void SimulateStep() //Simula el comportamiento de un turno
        {
            VisitObjects(obj =>
            {
                obj.Simulate(this);
            });
            //foreach(RaceObject obj in _raceObjects)
            //{
            //    if(obj.GetObjectType() == ObjectType.CAR && obj.Position > _distance)
            //    obj.Simulate(this);
            //}
        }

        public void VisitCars(IRace.VisitCarDelegate<Car> visit)//modificar
        {
            if (visit == null)
                return;
            foreach (Car car in _raceObjects)
            {
                visit(car);
            }
        }

        public void VisitDrivers(IRace.VisitDriverDlegate<Driver> visit)//modificar
        {
            if (visit == null)
                return;
            foreach (Car car in _raceObjects)
            {
                visit(car.Driver);
                if (car.Copilot != null)
                    visit(car.Copilot);
            }
        }

        public void VisitObjects(IRace.VisitObjectDelegate<RaceObject> visit)
        {
            if (visit == null)
                return;
            foreach (RaceObject raceObject in _raceObjects)
            {
                visit(raceObject);
            }
        }

        public void VisitObstacles(IRace.VisitObstacleDelegate<Obstacle> visit)//modificar
        {
            if (visit == null)
                return;
            foreach (Obstacle obstacle in _raceObjects)
            {
                visit(obstacle);
            }
        }

      
    }
}
