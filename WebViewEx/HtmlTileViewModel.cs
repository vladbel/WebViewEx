using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace WebViewEx
{
    public class HtmlTileViewModel: ViewModelBase
    {
        private string _Html = @"
                                <html>
                                <head>
                                
                                    <script>
                                        function notifyHost() {
                                            console.log('Notify Host: try to raise notification for hosting app.');
                                            try {
                                                window.external.notify('notification argument');
                                            } catch (e) {
                                                var element = document.getElementById('output');
                                                if (element) {
                                                    element.innerHTML = 'Error notifyng host';
                                                }
                                                console.log(e);
                                            }            
                                        }
                                
                                        function handleInvokeScript(args) {
                                            console.log('Script invoked', args);
                                            var element = document.getElementById('output');
                                            if (element) {
                                                element.innerHTML = 'Script invoked' + args;
                                            }
                                        }
                                    </script>
                                </head>
                                <body>
                                    <div id='output'></div>
                                
                                    <button onclick='notifyHost()'> Notify Host</button>
                                </body>
                                </html>
                                ";
        public string Html 
        {
            get 
            { 
                return this._Html; 
            }
            set 
            {
                this._Html = value;
                this.OnPropertyChanged();
            }
        }
    }
}
