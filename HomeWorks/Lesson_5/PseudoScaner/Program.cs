
using PseudoScaner.ScanerJobs;
using Quartz;
using Quartz.Impl;


namespace PseudoScaner;

public static class Program
{
    private static IScheduler _scheduler;

    public static async Task Main()
    {
        StdSchedulerFactory factory = new StdSchedulerFactory();
        _scheduler = await factory.GetScheduler();

        await _scheduler.Start();

        IJobDetail job = JobBuilder.Create<ScanEmulatorJob>()
            .WithIdentity("job1", "group1")
            .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(1)
                .RepeatForever())
            .Build();

        await _scheduler.ScheduleJob(job, trigger);

        await Task.Delay(TimeSpan.FromSeconds(20));

        await _scheduler.Shutdown();

        Console.ReadLine();
    }
}