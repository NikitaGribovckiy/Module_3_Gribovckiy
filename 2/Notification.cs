using System;

// Класс "Уведомление"
class Notification
{
    // Событие для отправки сообщения
    public event EventHandler<string> MessageSent;

    // Событие для отправки звонка
    public event EventHandler<string> CallMade;

    // Событие для отправки электронного письма
    public event EventHandler<string> EmailSent;

    // Метод для отправки сообщения
    public void SendMessage(string message)
    {
        Console.WriteLine($"Отправка сообщения: {message}");
        OnMessageSent(message);
    }

    // Метод для отправки звонка
    public void MakeCall(string recipient)
    {
        Console.WriteLine($"Звонок для: {recipient}");
        OnCallMade(recipient);
    }

    // Метод для отправки электронного письма
    public void SendEmail(string recipient, string subject)
    {
        Console.WriteLine($"Отправка электронного письма: Тема - {subject}, Получатель - {recipient}");
        OnEmailSent($"{subject} ({recipient})");
    }

    // Вызов события для отправки сообщения
    protected virtual void OnMessageSent(string message)
    {
        MessageSent?.Invoke(this, message);
    }

    // Вызов события для отправки звонка
    protected virtual void OnCallMade(string recipient)
    {
        CallMade?.Invoke(this, recipient);
    }

    // Вызов события для отправки электронного письма
    protected virtual void OnEmailSent(string emailInfo)
    {
        EmailSent?.Invoke(this, emailInfo);
    }
}
