namespace WorkingYoutube.TestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // создадим отправителя
            var sender = new YoutubeSender();

            // создадим получателя
            var receiver = new YoutubeDownloader();

            // создадим команду
            var commandOne = new YoutubeCommand(receiver);

            // инициализация команды
            sender.SetCommand(commandOne);

            await Console.Out.WriteLineAsync();
            IProgress<double> p1 = new Progress<double>(value => RewriteLine(1, string.Format("Скачено: {0:P2}", value)));
            //  выполнение
            await sender.Run("https://www.youtube.com/watch?v=v7r03w1wgu0", "VIDEO", p1);

        }

        static object obj = new object();

        /// <summary>Метод для перезаписи строки</summary>
        /// <param name="lineNumber">Строка с конца</param>
        /// <param name="newText">Текст для новой записи</param>
        /// <returns></returns>
        public static void RewriteLine(int lineNumber, String newText)
        {
            lock (obj)
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, currentLineCursor - lineNumber);
                Console.Write(newText);
                Console.WriteLine(new string(' ', Console.WindowWidth - newText.Length));
                Console.SetCursorPosition(0, currentLineCursor);
            }

        }
    }
}
