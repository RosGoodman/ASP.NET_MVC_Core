
using Autofac;
using ByteDataSaver;
using PseudoScaner.ScanerJobs;

namespace PseudoScaner;

public static class Program
{
    private static IContainer Container { get; set; }

    public static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ScanEmulatorJob>().As<IScanEmulatorJob>();
        builder.RegisterType<ScanFileEmulator>().As<IScanFileEmulator>();
        builder.RegisterType<DataSaver>().As<IDataSaver>();

        Container = builder.Build();
        StartJob();
        
        Console.ReadLine();
    }

    public static async void StartJob()
    {
        using(var scope = Container.BeginLifetimeScope())
        {
            var emulator = scope.Resolve<IScanEmulatorJob>();

            for (int i = 0; i < 30; i++)
            {
                await emulator.Execute();
            }
        }
    }
}