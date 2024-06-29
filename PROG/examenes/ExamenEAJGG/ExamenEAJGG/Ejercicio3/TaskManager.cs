using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    public class TaskManager
    {
        public delegate bool FilterDelegate(Task element);

        private int _maxTasks;
        private List<Task> _tasks = new();

        public DateTime MaxDate => GetMaxDate();
        public int TaskCount => _tasks.Count;
        public TaskManager(int maxTasks) 
        { 
            _maxTasks = maxTasks;
        }

        private DateTime GetMaxDate()
        {
            if (_tasks.Count == 0)
                return DateTime.MinValue;
            DateTime maxDate = _tasks[0].RealizationDate;
            for (int i = 1; i < _tasks.Count; i++)
            {
                if (_tasks[i].RealizationDate > maxDate)
                    maxDate = _tasks[i].RealizationDate;
            }
            return maxDate;
        }

        public void AddTask(Task task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            if (TaskCount < _maxTasks && !ContainsId(task.Id))
                _tasks.Add(task);
        }

        public bool ContainsTask(string taskName)
        {
            if (taskName == null)
                throw new ArgumentNullException(nameof(taskName));
            foreach (var task in _tasks)
            {
                if (task.Name == taskName) 
                    return true;
            }
            return false;
        }

        public bool ContainsId(int id)
        {
            foreach (var task in _tasks)
            {
                if (task.Id == id)
                    return true;
            }
            return false;
        }

        public List<Task> FilterTask(FilterDelegate found)
        {
            if (found == null)
                throw new ArgumentNullException(nameof(found));
            List<Task> filteredList = new List<Task>();
            foreach (var task in _tasks)
            {
                if(found(task))
                    filteredList.Add(task);
            }
            return filteredList;
        }

        public void ClearTasks()
        {
            _tasks = new();
        }

        public void RemoveAllTasks(string description)
        {
            foreach(var task in _tasks)
            {
                if (task.Name == description || task.Description == description)
                    _tasks.Remove(task);
            }
        }

    }
}
