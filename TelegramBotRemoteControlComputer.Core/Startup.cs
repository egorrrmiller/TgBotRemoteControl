using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using TelegramBotRemoteControlComputer.Control.Commands;
using TelegramBotRemoteControlComputer.Processor;

namespace TelegramBotRemoteControlComputer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var botToken = Configuration["Config:BotToken"];
            var telegramBotClient = new TelegramBotClient(botToken);


            services.AddSingleton<ITelegramBotClient>(telegramBotClient);
            services.AddTransient<ProcessingEvents>();
            
            services.Scan(scan => scan
                .FromAssemblyOf<ICommand>().AddClasses().AsImplementedInterfaces()
                .WithTransientLifetime());
            
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ITelegramBotClient telegramBotClient)
        {
            var url = Configuration["Config:Url"];
            telegramBotClient.SetWebhookAsync($"{url}/api/bot");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}