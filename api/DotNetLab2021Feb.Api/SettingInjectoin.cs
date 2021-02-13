using DotNetLab2021Feb.Api.Context;
using DotNetLab2021Feb.Api.Datas;
using DotNetLab2021Feb.Api.Domains;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api
{
    public static class Setting
    {
        public static void SettingMyInjectionAndOdata(this IServiceCollection service, IConfiguration config)
        {
            service.AddTransient<IUserData, UserData>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IOrderData, OrderData>();
            service.AddTransient<IOrderService, OrderService>();

            service.AddDbContext<DotNetLab2021FebDatabaseContext>(opt => { opt.UseSqlServer(config.GetConnectionString("DefaultConnection")); });
            service.AddOData();

            service.AddMvcCore(options => {
                foreach (var outputFormat in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(w => w.SupportedMediaTypes.Count == 0))
                {
                    outputFormat.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                }
                foreach (var inputFormat in options.InputFormatters.OfType<ODataInputFormatter>().Where(w => w.SupportedMediaTypes.Count == 0))
                {
                    inputFormat.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                }
            });
        }
    }
}
