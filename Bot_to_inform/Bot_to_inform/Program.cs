//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types.ReplyMarkups;

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

            Console.WriteLine($"Получено сообщение от пользователя {message.Chat.Username} в {DateTime.Now}, ид чата {message.Chat.Id}");

            // Начало работы с базой
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("Начало обращения к базе");

                // Нужно узнать, есть ли сейчас в таблице такой пользователь - новый ли это чат.
                bool tg_user_exists = await db.Tg_Users.AnyAsync(u => u.Tg_chat_id == $"{message.Chat.Id}");

                if (tg_user_exists)
                {
                    Console.WriteLine("Этот чат уже есть в таблице");
                }
                else
                {
                    Console.WriteLine("Чата нет в таблице, его нужно создать.");

                    // Экземпляр класса тг_пользователь.
                    Tg_user tg_user1 = new Tg_user { Tg_username = $"{message.Chat.Username}", Tg_chat_id = $"{message.Chat.Id}" };

                    db.Tg_Users.AddRange(tg_user1);
                    db.SaveChanges();

                    Console.WriteLine("Чат добавлен в таблицу");

                    await bot_client.SendMessage(message.Chat.Id, "Вы подписались на чат.");
                }
            }


            switch (update.Type)
            {
                case UpdateType.Message:
                {
                    var replyKeyboard = new ReplyKeyboardMarkup(
                        new List<KeyboardButton[]>()
                        {
                            new KeyboardButton[]
                            {
                                new KeyboardButton("Привет!"),
                                new KeyboardButton("Пока!"),
                            },
                            new KeyboardButton[]
                            {
                                new KeyboardButton("Позвони мне!")
                            },
                            new KeyboardButton[]
                            {
                                new KeyboardButton("Напиши моему соседу!")
                            }
                        }
                    )
                    {
                        // автоматическое изменение размера клавиатуры, если не стоит true,
                        // тогда клавиатура растягивается чуть ли не до луны,
                        // проверить можете сами
                        ResizeKeyboard = true,
                    };
                    return;
                }
            }




            //    ////получаем объекты из бд и выводим на консоль
            //    //var users = db.Tg_users.ToList();

            //    //Console.WriteLine($"Написал пользователь с ником {message.Chat.Username}, ид чата {message.Chat.Id}");


            //    //Console.WriteLine("Users list:");
            //    //foreach (Tg_user u in users)
            //    //{
            //    //    Console.WriteLine($"{u.Tg_Id}:{u.Tg_username} - {u.Tg_chat_id}");
            //    //}

            //    //// получаем объекты из бд и выводим на консоль
            //    //var users = db.Users.ToList();
            //    //Console.WriteLine("Users list:");
            //    //foreach (User u in users)
            //    //{
            //    //    Console.WriteLine($"{u.Id}:{u.Tg_username} - {u.Reg_date}");
            //    //}

            //}



            //// Определяем, какого типа получено сообщение
            //if (message.Text != null)
            //{
            //    Console.WriteLine($"Cообщение от пользователя {message.Chat.Username} в {DateTime.Now} имеет текст");

            //    if (message.Text.ToUpper().Contains("ПРИВЕТ"))
            //    {
            //        Console.WriteLine("Пользователь поздоровался.");

            //        // Можно ответить пользователю
            //        await bot_client.SendMessage(message.Chat.Id, "Тебе тоже привет!");
            //        return;
            //    }

            //    if (message.Text.ToUpper().Contains("РЕГИСТРАЦИЯ"))
            //    {
            //        Console.WriteLine("Регистрация пользователя");


            //        // добавление данных
            //        using (ApplicationContext db = new ApplicationContext())
            //        {
            //            // создаем два объекта User
            //            User user1 = new User { Tg_username = $"{message.Chat.Username}"};
            //            Console.WriteLine("Начало добавления пользователя");

            //            // добавляем их в бд
            //            db.Users.AddRange(user1);
            //            db.SaveChanges();
            //            await bot_client.SendMessage(message.Chat.Id, "Новый пользователь записан.");
            //            Console.WriteLine("Пользователь успешно создан");
            //        }
            //        // получение данных
            //        using (ApplicationContext db = new ApplicationContext())
            //        {
            //            // получаем объекты из бд и выводим на консоль
            //            var users = db.Users.ToList();
            //            Console.WriteLine("Users list:");
            //            foreach (User u in users)
            //            {
            //                Console.WriteLine($"{u.Id}:{u.Tg_username} - {u.Reg_date}");
            //            }
            //        }
            //    }
            //}

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