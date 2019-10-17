using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebEDI.Utility
{
    public class ViewRenderService : IViewRenderService
    {
        public IRazorViewEngine RazorViewEngine { get; set; }
        public ITempDataProvider TempDataProvider { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public ViewRenderService(IRazorViewEngine razorViewEngine,
                            ITempDataProvider tempDataProvider,
                            IServiceProvider serviceProvider)
        {
            RazorViewEngine = razorViewEngine;
            TempDataProvider = tempDataProvider;
            ServiceProvider = serviceProvider;
        }

        public async Task<string> RenderViewToStringAsync(string viewPath, object model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = ServiceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = RazorViewEngine.GetView(executingFilePath: viewPath, viewPath: viewPath, isMainPage:false );
                if(!viewResult.Success)
                    viewResult = RazorViewEngine.FindView(actionContext, viewPath, false);
                if (viewResult.View == null)
                {
                    Log.Logger.Warning($"{viewPath} does not match any available view");
                    Log.Logger.Warning("Search location {@SearchedLocations}", viewResult.SearchedLocations);
                    throw new ArgumentNullException($"{viewPath} does not match any available view. View log for detail");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, TempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }

        public async Task<string> RenderViewToStringAsync(string viewPath, object model, ITempDataDictionary tempData)
        {
            var httpContext = new DefaultHttpContext { RequestServices = ServiceProvider };
            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                var viewResult = RazorViewEngine.FindView(actionContext, viewPath, false);

                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewPath} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    tempData,
                    sw,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);
                return sw.ToString();
            }
        }
    }
}
