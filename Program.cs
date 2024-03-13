using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if (menuSelected == 1)
                {
                    ShowMenuAddTask();
                }
                else if (menuSelected == 2)
                {
                    ShowMenuRemoveTask();
                }
                else if (menuSelected == 3)
                {
                    ShowMenuTaskList();
                }
            } while (menuSelected != 4);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string optionSelected = Console.ReadLine();
            return Convert.ToInt32(optionSelected);
        }

        public static void ShowMenuRemoveTask()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                PrintListTasks();

                string taskSelected = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskSelected) - 1;
                if(indexToRemove > -1 || TaskList.Count < 0) 
                {
                    System.Console.WriteLine("Numero de tarea invalido");
                }
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskToRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {taskToRemove} eliminada");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hubo un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAddTask()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskToAdd = Console.ReadLine();
                if(String.IsNullOrEmpty(taskToAdd))
                {
                    System.Console.WriteLine("Tarea vacia no ha podido ser agregada");
                }
                else
                {
                    TaskList.Add(taskToAdd);
                    Console.WriteLine("Tarea registrada");
                }
            }
            catch (Exception)
            {
                System.Console.WriteLine("No se ha podido agregar tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            PrintListTasks();
        }

        public static void PrintListTasks()
        {
            if (TaskList?.Count <= 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                Console.WriteLine("----------------------------------------");
                var indexTask = 1;
                TaskList.ForEach(p => Console.WriteLine($"{indexTask++}. {p}"));
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
