﻿// Класс для хранения записей данных
class DataRecord
{
    // Свойство для хранения текста записи данных
    public string Text { get; }

    // Свойство для хранения даты, соответствующей записи данных
    public string Date { get; }

    // Конструктор класса, принимающий текст и дату в качестве параметров
    public DataRecord(string text, string date)
    {
        // Инициализация свойства Text значением text, переданным в конструктор
        Text = text;

        // Инициализация свойства Date значением date, переданным в конструктор
        Date = date;
    }
}