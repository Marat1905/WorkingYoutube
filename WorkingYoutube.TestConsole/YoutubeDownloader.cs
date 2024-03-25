
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace WorkingYoutube.TestConsole
{
    internal class YoutubeDownloader
    {
        private readonly YoutubeClient _youtubeClient;
        public YoutubeDownloader()
        {
            _youtubeClient = new YoutubeClient();
        }

        public async Task Download(string url, string fileName, IProgress<double> progress)
        {
            //Запрашиваем манифест, в котором перечислены все доступные потоки для определенного видео,
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(url);
            //Выбираем видео MP4 высочайшего качества
            var streamInfo = streamManifest
                .GetVideoOnlyStreams()
                .Where(s => s.Container == Container.Mp4)
                .GetWithHighestVideoQuality();

            //Скачиваем видео
            await _youtubeClient.Videos.DownloadAsync(url, $"{fileName}.{streamInfo.Container}", builder => builder.SetPreset(ConversionPreset.UltraFast), progress);
        }

    }
}
