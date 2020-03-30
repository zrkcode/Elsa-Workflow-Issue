using Elsa.Dashboard.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BasicDemo
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule)
        )]
    public class AppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddTransient<Elsa.Dashboard.Areas.Elsa.Controllers.HomeController>();
            //context.Services.AddTransient<Elsa.Dashboard.Areas.Elsa.Controllers.WorkflowDefinitionController>();
            //context.Services.AddTransient<Elsa.Dashboard.Areas.Elsa.Controllers.WorkflowInstanceController>();
            //context.Services.AddTransient<Elsa.WorkflowDesigner.ViewComponents.WorkflowDesignerViewComponent>();

            context.Services.AddMvc(options =>
                options.EnableEndpointRouting = false
            ).AddControllersAsServices();

            context.Services
                .AddElsa()
                .AddElsaDashboard();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
