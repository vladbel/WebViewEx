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
        private string _Html = HtmlScript.TypeScriptClassPattern;

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
