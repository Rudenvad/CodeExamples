namespace Examples.Threading;

public class ProcessImageExample
{
    private static string _highResImage = "img_large_highres.jpg";

    private static List<string> _lowResImages = new()
    {
        "img_01.jpg",
        "img_02.jpg",
        "img_03.jpg",
        "img_04.jpg",
        "img_05.jpg"
    };

    private const int MainThreadSleepTime = 5000;
    private const int HighResImageProcessTime = 10000;
    private const int LowResImageProcessTime = 500;

    public static void Main()
    {
        Console.WriteLine("=== Processing images using ThreadPool ===");

        // Simulate parallel processing of multiple low-res images using thread pool
        foreach (var image in _lowResImages)
            ThreadPool.QueueUserWorkItem(_ => ProcessImage(image));

        Console.WriteLine("=== Processing large image using Dedicated Thread ===");

        // Use a dedicated thread for a high-res image (e.g., longer processing time)
        var dedicatedThread = new Thread(() => ProcessImage(_highResImage, true))
        {
            IsBackground = true // Optional: ensures the app won't hang on exit
        };

        dedicatedThread.Start();

        // Keep main thread alive long enough to observe outputs
        Thread.Sleep(MainThreadSleepTime);
    }

    // Entry point for async version
    public static async Task MainAsync()
    {
        // Process low-res images concurrently
        var tasks = _lowResImages.Select(img => ProcessImageAsync(img)).ToList();

        // Process high-res image concurrently as well
        tasks.Add(ProcessImageAsync(_highResImage, isHighRes: true));

        await Task.WhenAll(tasks);

        Console.WriteLine("=== Async Image Processing Completed ===");
    }

    // Overload for ThreadPool callback (object state)
    private static void ProcessImage(object state) => ProcessImage(state, false);

    // Main worker method simulating image processing
    private static void ProcessImage(object state, bool isHighRes)
    {
        var imageName = state.ToString();
        Console.WriteLine($"[START] Processing {imageName} on Thread ID {Thread.CurrentThread.ManagedThreadId}");

        // Simulate time based on complexity
        var workTime = isHighRes ? HighResImageProcessTime : LowResImageProcessTime;
        Thread.Sleep(workTime); // Simulated work

        Console.WriteLine($"[DONE]  Finished {imageName} on Thread ID {Thread.CurrentThread.ManagedThreadId}");
    }

    // Async simulation of image processing
    private static async Task ProcessImageAsync(string imageName, bool isHighRes = false)
    {
        Console.WriteLine($"[START] Processing {imageName} on Thread ID {Thread.CurrentThread.ManagedThreadId}");

        var workTime = isHighRes ? HighResImageProcessTime : LowResImageProcessTime;
        await Task.Delay(workTime); // Simulate async delay

        Console.WriteLine($"[DONE]  Finished {imageName} on Thread ID {Thread.CurrentThread.ManagedThreadId}");
    }
}
