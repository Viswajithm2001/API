namespace MoviesAPI.Services
{
    public class WriteToFileHosterServices : IHostedService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private Timer _timer;
        public WriteToFileHosterServices(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile($"Process started {DateTime.Now}");
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile($"Process stopped {DateTime.Now}");
            return Task.CompletedTask;
        }
        private void WriteToFile(string message)
        {
            var dirPath = Path.Combine(_hostEnvironment.ContentRootPath, "Files");
            var filePath = Path.Combine(dirPath, "test.txt");
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            //File.AppendAllText(filePath, $"Write to file at {DateTime.Now}\n");
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }

        }
    }
}
