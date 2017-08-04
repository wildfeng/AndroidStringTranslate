using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidStringTranslate.Translate
{
   public abstract class AbsTranslater
    {
        public string SourceString { get; set; }

        public abstract void BetinTranslate();

        public abstract void BetinTranslateAsync();

        public event TranslateCompletedEventHandler TranslateCompleted;

        public void OnTranslateCompleted(TranslateCompletedEventArgs e)
        {
            if (TranslateCompleted != null)
            {
                TranslateCompleted(this, e);
            }
        }

        public delegate void TranslateCompletedEventHandler(object sender, TranslateCompletedEventArgs e);
    }
}
