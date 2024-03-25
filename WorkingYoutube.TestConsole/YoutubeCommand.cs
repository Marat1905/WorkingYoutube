namespace WorkingYoutube.TestConsole
{
    /// <summary>Конкретная реализация команды.</summary>
    class YoutubeCommand : ICommand
    {
        private readonly YoutubeDownloader _receiver;

        public YoutubeCommand(YoutubeDownloader receiver)
        {
            _receiver = receiver;
        }

        public async Task Run(string url, string fileName, IProgress<double> progress)
        {
            await _receiver.Download(url, fileName, progress);
        }
    }
}
