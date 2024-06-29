using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public enum TaskState
    {
        DONE,
        NOT_DONE,
        TO_DO,
    }
    public class Task
    {
        private int _id;
        private string _name;
        private string _description;
        private DateTime _realizationDate;
        private int _priority;
        private TaskState _state;

        public int Id => _id;
        public string Name => _name;
        public string Description => _description;
        public DateTime RealizationDate => _realizationDate;
        public int Priority => _priority;
        public TaskState State => _state;

        public Task(int id, string name, string description, DateTime realizationDate, int priority, TaskState state) 
        {

            _id = id;

            if (name == null)
                _name = "";
            else
                _name = name;

            if (description == null)
                _description = "";
            else
                _description = description;

            _realizationDate = realizationDate;
            _priority = priority;
            _state = SetState(state);
        }

        private TaskState SetState(TaskState state)
        {
            if (_realizationDate < DateTime.Today)
                return TaskState.NOT_DONE;
            return (state == TaskState.NOT_DONE) ? TaskState.TO_DO : state;
        }
    }
}
