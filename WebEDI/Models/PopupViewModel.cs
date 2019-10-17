using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEDI.Models
{
    public class PopupViewModel
    {
        public PopupViewModel()
        {
            JsMethodNoAction = "javascript:void(0)";
            JsMethodCloseAction = "javascript:void(0)";
        }
        /// <summary>
        /// The title of popup
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Message showed user
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The javascript method called when user clicks 'Yes' Button
        /// </summary>
        public string JsMethodYesAction { get; set; }

        /// <summary>
        /// The javascript method called when user clicks 'No' Button
        /// </summary>
        public string JsMethodNoAction { get; set; }

        /// <summary>
        /// The javascript method called when user clicks 'Close' Button
        /// </summary>
        public string JsMethodCloseAction { get; set; }

        /// <summary>
        /// Id used to find the popup in jQuery
        /// </summary>
        public string JsPopupId { get; set; }

        /// <summary>
        /// Id of html element which contains the content
        /// </summary>
        public string JsContentId { get; set; }
    }
}
