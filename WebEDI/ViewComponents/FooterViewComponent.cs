using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebEDI.ViewComponents
{
    public class FooterViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            string footertext = "";
            try
            {
                using (StreamReader sr = new StreamReader("wwwroot/Content/editnew.txt"))
                {
                    string line = await sr.ReadToEndAsync();
                    footertext = line;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
            TempData["WebEDIFooter"] = footertext;
            return View();
        }
    }
}
