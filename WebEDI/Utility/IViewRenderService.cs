using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;

namespace WebEDI.Utility
{
    /// <summary>
    /// Support methods to render a view to a string
    /// </summary>
    public interface IViewRenderService
    {
        /// <summary>
        /// Render a view to a string
        /// </summary>
        /// <param name="viewPath"> The path to the view </param>
        /// <param name="model"> Model used in the view </param>
        /// <returns></returns>
        Task<string> RenderViewToStringAsync(string viewPath, object model);

        /// <summary>
        /// Render a view to a string
        /// </summary>
        /// <param name="viewPath"> The path to the view </param>
        /// <param name="model"> Model used in the view </param>
        /// <param name="tempData"> TempData used in the view </param>
        /// <returns></returns>
        Task<string> RenderViewToStringAsync(string viewPath, object model, ITempDataDictionary tempData);
    }
}
