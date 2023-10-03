using System;

// Класс, представляющий задачу
class TaskItem
{
    // Свойство для имени задачи
    public string Name { get; set; }

    // Свойство для делегата задачи
    public TaskDelegate TaskHandler { get; set; }

    // Конструктор класса TaskItem, принимает имя и делегат задачи
    public TaskItem(string name, TaskDelegate taskHandler)
    {
        Name = name;
        TaskHandler = taskHandler;
    }
}
