using System;
using System.Collections.Generic;

// Делегат для выполнения задачи
delegate void TaskDelegate(string taskName);

class Program
{
    static void Main(string[] args)
    {
        // Создаем список для хранения задач
        List<TaskItem> tasks = new List<TaskItem>();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Выполнить задачи");
            Console.WriteLine("3. Выход");

            string choice = Console.ReadLine();

            if (choice == "3")
            {
                break; // Выход из программы
            }

            switch (choice)
            {
                case "1":
                    Console.Write("Введите название задачи: ");
                    string taskName = Console.ReadLine();
                    Console.WriteLine("Выберите действие для задачи:");
                    Console.WriteLine("1. Отправить уведомление");
                    Console.WriteLine("2. Записать в журнал");
                    string actionChoice = Console.ReadLine();
                    TaskDelegate taskDelegate = null;

                    // Выбор делегата в зависимости от действия
                    switch (actionChoice)
                    {
                        case "1":
                            taskDelegate = SendNotification;
                            break;
                        case "2":
                            taskDelegate = WriteToLog;
                            break;
                        default:
                            Console.WriteLine("Некорректный выбор действия.");
                            break;
                    }

                    if (taskDelegate != null)
                    {
                        // Добавление задачи в список
                        tasks.Add(new TaskItem(taskName, taskDelegate));
                        Console.WriteLine($"Задача '{taskName}' добавлена.");
                    }
                    break;

                case "2":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Нет задач для выполнения.");
                    }
                    else
                    {
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"Выполнение задачи: {task.Name}");
                            // Выполнение задачи с использованием делегата
                            task.TaskHandler(task.Name);
                            Console.WriteLine();
                        }
                        tasks.Clear(); // Очистка списка выполненных задач
                    }
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите действие из списка.");
                    break;
            }
        }
    }

    // Метод для отправки уведомления
    static void SendNotification(string taskName)
    {
        Console.WriteLine($"Отправка уведомления для задачи '{taskName}'");
    }

    // Метод для записи в журнал
    static void WriteToLog(string taskName)
    {
        Console.WriteLine($"Запись в журнал для задачи '{taskName}'");
    }
}
