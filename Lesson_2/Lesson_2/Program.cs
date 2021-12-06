using Lesson_2;

public static class Program
{
    static void Main()
    {
        using (var pool = new SimpleThreadPool(5))
        {
            var random = new Random();
            Action<int> randomizer = (index =>
            {
                Console.WriteLine("{0}: Working on index {1}", Thread.CurrentThread.Name, index);
                Thread.Sleep(random.Next(20, 400));
                Console.WriteLine("{0}: Ending {1}", Thread.CurrentThread.Name, index);
            });

            for (var i = 0; i < 40; ++i)
            {
                var i1 = i;
                pool.QueueTask(() => randomizer(i1));
            }
        }
    }
}