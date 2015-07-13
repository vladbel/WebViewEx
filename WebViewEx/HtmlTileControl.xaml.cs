using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WebViewEx
{
    public sealed partial class HtmlTileControl : UserControl
    {
        public HtmlTileControl()
        {
            this.InitializeComponent();
        }

        private async void ScriptNotify_Handler(object sender, NotifyEventArgs e)
        {
            // handle notification from JavaScript
            System.Diagnostics.Debug.WriteLine("Script notification: " + e.Value);


            // Invoke JavaScript function
            var script = await HtmlViewModelHelpers.HandleScriptNotify(new HtmlViewModelHelpers.ScriptNotificationMessage { Id = "id_value" }, HtmlViewModelHelpers.ExecuteScriptAsync);



            try
            {
                string result;
                result = await this.HtmlTileView.InvokeScriptAsync("eval", new string[] { script });
                // This will throw exception "Unknown name. (Exception from HRESULT: 0x80020006 (DISP_E_UNKNOWNNAME))"
                //result = await this.HtmlTileView.InvokeScriptAsync("ST.receivedSmartThingsMessageSuccess", args);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }
    }
        
}
