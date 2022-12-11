using Kasa;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Timer = System.Threading.Timer;
using System.Threading;

namespace Kasa.Console;

public class PlugOperations
{
    private ILoggerFactory _loggerFactory;
    private ILogger _logger;

    public PlugOperations(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _logger = loggerFactory.CreateLogger("Main");        
    }

    public async Task RunTestsAsync()
    {
        //var ipAddress = "192.168.0.121";
        var ipAddress = "192.168.0.192";
        using IKasaOutlet outlet = new KasaOutlet(ipAddress, new Options
        {
            LoggerFactory = _loggerFactory, //  = loggerFactory,
            MaxAttempts = 2
        });

        SystemInfo outletInfo = await outlet.System.GetInfo();

        //await outlet.System.SetOutletOn(true);
        //await outlet.System.SetOutletOn(false);

        //await outlet.System.SetAllChildOutletOn(true);

        await outlet.System.SetAllChildOutletOn(true);

        Thread.Sleep(3000);
         
        await outlet.System.SetAllChildOutletOn(false);

        //outletInfo.Children.ToList().ForEach(child =>
        //{
        //    outlet.System.SetChildOutletOn(false, child.id);
        //});

        //outletInfo = await outlet.System.GetInfo();
        //outletInfo.Children.ToList().ForEach(child =>
        //{
        //    outlet.System.SetChildOutletOn(true, child.id);
        //});

        Thread.Sleep(3000);
         
        bool isOn = await outlet.System.IsOutletOn();
        _logger.LogInformation($"Is outlet on: {isOn}");

        //await outlet.System.SetOutletOn(true);

        //await outlet.System.SetOutletOn(false);
    

        //CancellationTokenSource cts = new();

        //System.Threading.Timer timer = new(async _ => {
        //    try
        //    {
        //        SystemInfo systemInfo = await outlet.System.GetInfo();
            
        //        var isOutletCurrentlyOn = await outlet.System.IsOutletOn();
        //        if (isOutletCurrentlyOn != isOn)
        //        {
        //            Console.WriteLine($"Change Event: {isOutletCurrentlyOn}");
        //            _logger.LogInformation($"Change Event: {isOutletCurrentlyOn}");
        //        }
            
        //        isOn = isOutletCurrentlyOn;
        //    }
        //    catch (NetworkException nex)
        //    {
        //        _logger.LogError($"Network Error: {nex.Message}");
        //    }
        //}, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));

        //Console.CancelKeyPress += (sender, eventArgs) => cts.Cancel();

        //cts.Token.WaitHandle.WaitOne();
        //timer.Dispose();
    }
}