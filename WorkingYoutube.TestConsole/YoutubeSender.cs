namespace WorkingYoutube.TestConsole
{

     /// <summary> Отправитель команды</summary>
    class YoutubeSender
    {
        ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        // Выполнить
        public async Task Run(string url, string fileName, IProgress<double> progress)
        {
            await _command.Run(url, fileName, progress);
            await Console.Out.WriteLineAsync("Файл скачен");
        }


    }
}
