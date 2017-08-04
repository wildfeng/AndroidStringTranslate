using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AndroidStringTranslate.Translate
{
    public class EnglishTranslater : AbsTranslater
    {
        
        public override void BetinTranslate()
        {
            WebClient webClient = new WebClient();
            string url = "http://fanyi.baidu.com/v2transapi?from=zh&query="+SourceString+"&to=en";
            webClient.DownloadData(url);
        }

        public async override void BetinTranslateAsync()
        {
            WebClient webClient = new WebClient();
            string url = "http://fanyi.baidu.com/v2transapi?from=zh&query=" + SourceString + "&to=en";
          byte[] raw = await webClient.DownloadDataTaskAsync(url);

            string str = System.Text.Encoding.Default.GetString(raw);

        }
    }
}
