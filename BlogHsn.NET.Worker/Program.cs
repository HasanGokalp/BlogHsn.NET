using BlogHsn.NET.Worker;
using BlogHsn.NET.Worker.Consumer;
using MassTransit;

//var builder = Host.CreateApplicationBuilder(args);

//builder.Services.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((context, cfg) =>
//    {
//        x.AddConsumer<ViewUpdateConsumer>();

//        cfg.Host("localhost", "/", h =>
//        {
//            h.Username("guest");
//            h.Password("guest");
//        });

//        cfg.ReceiveEndpoint("View-Update-queue", e =>
//        {
//            e.ConfigureConsumer<ViewUpdateConsumer>(context);
//        });
//    });
//});

 var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(x =>
                {
                    x.UsingRabbitMq((context, cfg) =>
    {
        x.AddConsumer<ViewUpdateConsumer>();

        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("View-Update-queue", e =>
        {
            e.ConfigureConsumer<ViewUpdateConsumer>(context);
        });
    });
                });
            });

var host = builder.Build();
await host.RunAsync();
