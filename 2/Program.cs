using System;

class Program
{
    static void Main(string[] args)
    {
        // Создание объекта класса Notification
        Notification notification = new Notification();

        // Регистрация обработчиков событий для разных типов уведомлений
        notification.MessageSent += (sender, message) =>
        {
            Console.WriteLine($"Сообщение отправлено: {message}");
        };

        notification.CallMade += (sender, recipient) =>
        {
            Console.WriteLine($"Звонок сделан для: {recipient}");
        };

        notification.EmailSent += (sender, emailInfo) =>
        {
            Console.WriteLine($"Электронное письмо отправлено: {emailInfo}");
        };

        while (true)
        {
            Console.WriteLine("Выберите тип уведомления:");
            Console.WriteLine("1. Сообщение");
            Console.WriteLine("2. Звонок");
            Console.WriteLine("3. Электронное письмо");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            if (choice == "4")
            {
                break; // Выход из программы
            }

            switch (choice)
            {
                case "1":
                    Console.Write("Введите текст сообщения: ");
                    string message = Console.ReadLine();
                    notification.SendMessage(message); // Вызов метода SendMessage для отправки сообщения
                    break;

                case "2":
                    Console.Write("Введите имя получателя звонка: ");
                    string recipient = Console.ReadLine();
                    notification.MakeCall(recipient); // Вызов метода MakeCall для совершения звонка
                    break;

                case "3":
                    Console.Write("Введите адрес электронной почты получателя: ");
                    string emailRecipient = Console.ReadLine();
                    Console.Write("Введите тему письма: ");
                    string emailSubject = Console.ReadLine();
                    notification.SendEmail(emailRecipient, emailSubject); // Вызов метода SendEmail для отправки электронного письма
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите тип уведомления из списка.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
