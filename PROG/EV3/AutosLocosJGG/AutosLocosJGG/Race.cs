using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Race : IRace
    {
        private List<RaceObject> _raceObjects = new List<RaceObject>();
        private double _distance;
        private RaceObject[] _winners = new RaceObject[0];
        private int _turn = 0;

        public void PrintWinners() 
        {
            if (_winners.Length < 1 )
            {
                return;
            }
            string message = "";
            if (_winners.Length > 1 )
            {
                message = "Los participantes ";
                for (int i = 0; i < _winners.Length; i++)
                {
                    message += _winners[i].Name;
                    if (i < _winners.Length - 2)
                        message += ", ";
                    if (i == _winners.Length - 2)
                        message += " y ";
                }
                message += " son los ganadores de esta carrera.";
            }
            else
            {
                message = $"El participante {_winners[0].Name} es el ganador de esta carrera";
            }
            
            Console.WriteLine(message);
        }
        public void AddObject(RaceObject? obj, double position)
        {
            if (obj == null || position < 0) 
            {
                return;
            }
            obj.SetObjectPosition(position);
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

            VisitObstacles(obstacle =>
            {
                if (obstacle.Position > distance)
                {
                    _raceObjects.RemoveAt(IndexOf(obstacle));
                }
            });

            _distance = distance;
            _turn = 0;

            VisitCars(car =>
            {
                car.SetCarPosition(0.0);
            });
            //foreach(Car car in _raceObjects)
            //{
            //    car.SetPosition(0.0);
            //}

            while (_winners.Length <= 0)
            {
                SimulateStep();
            }
        }

        public void SimulateStep() //Simula el comportamiento de un turno
        {
            _turn++;
            VisitObjects(obj =>
            {
                obj.Simulate(this);
                if (obj.Position > _distance && obj.GetObjectType() == ObjectType.CAR)
                {
                    int winnerLegth = _winners.Length;
                    int newWinnerLength = winnerLegth +1;
                    RaceObject[] newWinner = new RaceObject[newWinnerLength];
                    for(int i = 0; i < winnerLegth; i++)
                        newWinner[i] = _winners[i];
                    newWinner[winnerLegth] = obj;
                    _winners = newWinner;
                }
            });
            _raceObjects.RemoveAll(obj => !obj.IsAlive);
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
            VisitObjects(obstacle =>
            {
                if (obstacle.GetObjectType() == ObjectType.CAR)
                    visit((Car)obstacle);
            });
            //foreach (Car car in _raceObjects)
            //{
            //    visit(car);
            //}
        }

        public void VisitDrivers(IRace.VisitDriverDelegate<Driver> visit)//modificar
        {
            if (visit == null)
                return;
            VisitCars(car =>
            {
                visit(car.Driver);
                if (car.Copilot != null)
                    visit(car.Copilot);
            });
            //foreach (Car car in _raceObjects)
            //{
            //    visit(car.Driver);
            //    if (car.Copilot != null)
            //        visit(car.Copilot);
            //}

            // el if comprueba si obj es de tipo Car; si lo es, 
            //if (obj is Car car)
            //{
            //    visit(car.Driver);
            //    if (car.Copilot != null)
            //        visit(car.Copilot);
            //}
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
            VisitObjects(obstacle =>
            {
                if (obstacle.GetObjectType() == ObjectType.OBSTACLE)
                    visit((Obstacle)obstacle);
            });
            //foreach (Obstacle obstacle in _raceObjects)
            //{
            //    visit(obstacle);
            //}
        }

        

      
    }
}
