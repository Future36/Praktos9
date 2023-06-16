using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Email
{
    class ConverterRTF
    {
        static string htmlFilePath = "msg.html";
        static string rtfFilePath = "msg.rtf";
        static string sendRtfFilePath = "send.rtf";
        static string sendHtmlFilePath = "send.html";

        static ConverterRTF()
        {
            // Создание пустых файлов в начале
            File.WriteAllText(htmlFilePath, string.Empty);
            File.WriteAllText(rtfFilePath, string.Empty);
            File.WriteAllText(sendRtfFilePath, string.Empty);
            File.WriteAllText(sendHtmlFilePath, string.Empty);
        }

        public static void ConvertToRtf(string html)
        {
            File.WriteAllText(htmlFilePath, html);

            Document document = new Document(htmlFilePath, FileFormat.Html);
            document.SaveToFile(rtfFilePath, FileFormat.Rtf);
            document.Close();
        }

        public static void ConvertToHtml(string rtf)
        {
            using (FileStream fs = new FileStream(sendRtfFilePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(rtf);
                }
            }

            Document document = new Document(sendRtfFilePath, FileFormat.Rtf);
            document.SaveToFile(sendHtmlFilePath, FileFormat.Html);
            document.Close();
        }
    }
}
