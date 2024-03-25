namespace WorkingYoutube.TestConsole
{
    /// <summary>
    /// Базовый класс команды
    /// </summary>
    interface ICommand
    {
        public Task Run(string url, string fileName, IProgress<double> progress);
    }
}
