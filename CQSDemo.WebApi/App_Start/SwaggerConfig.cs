using System.Web.Http;
using WebActivatorEx;
using CQSDemo.WebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CQSDemo.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
              .EnableSwagger(c =>
              {
                  c.SingleApiVersion("v1", "SwaggerDemoApi");
                  c.IncludeXmlComments(string.Format(@"{0}\bin\CQSDemo.WebApi.xml",
                                       System.AppDomain.CurrentDomain.BaseDirectory));
                  c.DescribeAllEnumsAsStrings();
              })
              .EnableSwaggerUi();
        }
    }
}
