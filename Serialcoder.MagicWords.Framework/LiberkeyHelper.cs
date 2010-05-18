using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace JRoland.MagicWords
{
    public static class LiberkeyHelper
    {
        public static List<Entities.MagicWord> GetMagicWordList(string liberkeyPath)
        {
            List<Entities.MagicWord> list = new List<JRoland.MagicWords.Entities.MagicWord>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(liberkeyPath, @"Apps\ASuite\ASuite.xml"));

            foreach (XmlNode node in doc.SelectNodes("//Software"))
            {
                Entities.MagicWord word = new JRoland.MagicWords.Entities.MagicWord();
                word.Alias = node.Attributes["name"].Value;

                if (node.ChildNodes[1].InnerText.StartsWith("http", StringComparison.OrdinalIgnoreCase) || node.ChildNodes[1].InnerText.StartsWith("liberkey", StringComparison.OrdinalIgnoreCase))
                {
                    //
                }
                else
                {
                    word.FileName = Path.Combine(Path.Combine(liberkeyPath, @"Apps"), node.ChildNodes[1].InnerText.Replace("..\\", string.Empty));
                    //word.Notes = node.ChildNodes[5].InnerText;
                    word.Kind = Entities.Kind.Dynamic;
                    list.Add(word);
                }
            }
            return list;
        }
    }
}
