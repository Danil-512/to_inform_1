//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bot_to_inform
{
    internal class Program
    {
        // Объект клиент для работы с апи телеграм бота.
        // Позволяет выполнять все нужные действия по типу отправки сообщений и тп.
        // Сразу присвоим токен. Далее нужно сделать чтение токена из файла.
        private static ITelegramBotClient bot_сlient;

        // Объект хранящий настройки бота. 
        private static ReceiverOptions receiver_options;
        static void Main(string[] args)
        {
            // Ключ хранится в отдельном тестовом файле, его нужно прочитать 
            string key_path = "../../../../bot_key.txt";

            string key = null;

            try
            {
                using (StreamReader reader = new StreamReader(key_path))
                {
                    key = reader.ReadToEnd();
                }
            }
            catch
            {
                Console.WriteLine("Ошибка при чтении ключа");
            }
            if (key == null)
            {
                Console.WriteLine("Ключ бота не может быть прочитан");
            }


            bot_сlient = new TelegramBotClient(key);

            // Метод для старта бота с указанием всех его настроек.
            // Аргументы - методы, которые будут вызваны при ...
            bot_сlient.StartReceiving(Update, Error);

            Console.WriteLine("Бот успешно запущен.");
            Console.ReadLine();
            
        }

        
        // /---
        private static async Task Update(ITelegramBotClient bot_client, Update update, CancellationToken token)
        {
            // Переменная для хранения полученного сообщения
            var message = update.Message;

            Console.WriteLine($"Получено сообщение от пользователя {message.Chat.Username} в {DateTime.Now}");

            // Определяем, какого типа получено сообщение
            if (message.Text != null)
            {
                Console.WriteLine($"Cообщение от пользователя {message.Chat.Username} в {DateTime.Now} имеет текст");

                if (message.Text.ToUpper().Contains("ПРИВЕТ"))
                {
                    Console.WriteLine("Пользователь поздоровался.");

                    // Можно ответить пользователю
                    await bot_client.SendMessage(message.Chat.Id, "Тебе тоже привет!");
                    return;
                }

                if (message.Text.ToUpper().Contains("РЕГИСТРАЦИЯ"))
                {
                    Console.WriteLine("Регистрация пользователя");


                    // добавление данных
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        // создаем два объекта User
                        User user1 = new User { Tg_username = $"{message.Chat.Username}"};
                        Console.WriteLine("Начало добавления пользователя");

                        // добавляем их в бд
                        db.Users.AddRange(user1);
                        db.SaveChanges();
                        await bot_client.SendMessage(message.Chat.Id, "Новый пользователь записан.");
                        Console.WriteLine("Пользователь успешно создан");
                    }
                    // получение данных
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        // получаем объекты из бд и выводим на консоль
                        var users = db.Users.ToList();
                        Console.WriteLine("Users list:");
                        foreach (User u in users)
                        {
                            Console.WriteLine($"{u.Id}:{u.Tg_username} - {u.Reg_date}");
                        }
                    }
                }
            }

            return;

            throw new NotImplementedException();
        }

        // /---
        private static async Task Error(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }

}