namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(1,"Cumpleaños","",new DateTime(2023,6,15),3, TaskState.TO_DO);
            Console.WriteLine($"Id: {task1.Id}");
            Console.WriteLine($"Name: {task1.Name}");
            Console.WriteLine($"Description: {task1.Description}");
            Console.WriteLine($"RealizationDate: {task1.RealizationDate}");
            Console.WriteLine($"State: {task1.State}");

            Console.WriteLine("");

            Task task2 = new Task(2, "Hola", "", new DateTime(2024, 6, 30), 5, TaskState.TO_DO);
            Task task3 = new Task(4, "", "Cumpleaños", new DateTime(2025, 2, 18), 5, TaskState.DONE);

            TaskManager manager = new(2);

            Console.WriteLine(manager.MaxDate);
            Console.WriteLine(manager.TaskCount);

            Console.WriteLine("");

            manager.AddTask(task1);
            manager.AddTask(task2);
            manager.AddTask(task3);

            manager = new(3);
            manager.AddTask(task1);
            manager.AddTask(task2);
            manager.AddTask(task3);

            Console.WriteLine(manager.MaxDate);
            Console.WriteLine(manager.TaskCount);

            Console.WriteLine("");

            List<Task> list = manager.FilterTask(task =>
            {
                return (task.Description == "Cumpleaños");                    
            });
            foreach (var task in list)
            {
                Console.WriteLine($"{task.Id}, {task.Name}, {task.RealizationDate}, {task.Priority}, {task.State}");
            }

        }
    }
}