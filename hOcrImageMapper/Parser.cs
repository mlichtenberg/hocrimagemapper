using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace hOcrImageMapper
{
    public class Parser
    {
        public TextPage ParseHOcr(string text)
        {
            text = ReplaceLigatures(text);

            TextPage textPage = new TextPage();

            XDocument textXml = XDocument.Parse(text);

            XName spanName = XName.Get("span");
            IEnumerable<XElement> lines = textXml.Root.Descendants(spanName)
                                            .Where(x => (string)x.Attribute("class") == "ocr_line");

            // If no span elements found, try again using the XHTML namespace
            if (lines.Count() == 0)
            {
                spanName = XName.Get("span", "http://www.w3.org/1999/xhtml");
                lines = textXml.Root.Descendants(spanName)
                        .Where(x => (string)x.Attribute("class") == "ocr_line");
            }

            foreach (XElement line in lines)
            {
                TextLine textLine = new TextLine();

                IEnumerable<XElement> words = line.Descendants(spanName);
                foreach (XElement word in words)
                {
                    TextWord textWord = new TextWord();

                    XAttribute coords = word.Attribute("title");
                    string[] coordList = coords.Value.Split(' ');
                    textWord.x1 = Convert.ToInt32(GetNumbers(coordList[1]));
                    textWord.y2 = Convert.ToInt32(GetNumbers(coordList[4]));
                    textWord.x2 = Convert.ToInt32(GetNumbers(coordList[3]));
                    textWord.y1 = Convert.ToInt32(GetNumbers(coordList[2]));

                    textWord.text = word.Value;
                    textLine.words.Add(textWord);
                }

                textLine = NormalizeSemicolons(textLine);
                textPage.lines.Add(textLine);
            }

            return textPage;
        }

        /// <summary>
        /// Some OCR engines includes spaces before semicolons, which causes them to be treated as
        /// separate words.  Identify all instances of "words" that are just semicolons, and combine them
        /// with the preceding words.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private TextLine NormalizeSemicolons(TextLine line)
        {
            TextLine newLine = new TextLine();

            if (line.words.Count > 0) newLine.words.Add(line.words[0]);

            for (int x = 1; x < line.words.Count; x++)
            {
                if (((TextWord)(line.words[x])).text == ";")
                {
                    int i = newLine.words.Count - 1;
                    (newLine.words[i] as TextWord).text += ";";

                    // Replace coordinates of right side of bounding box with coordinates from last word
                    (newLine.words[i] as TextWord).x2 = (line.words[x] as TextWord).x2;
                    (newLine.words[i] as TextWord).y2 = (line.words[x] as TextWord).y2;
                }
                else
                {
                    newLine.words.Add(line.words[x]);
                }
            }

            return newLine;
        }

        /// <summary>
        /// Replace unwanted ligatures commonly inserted into OCR output.  Post-processing the OCR
        /// output in this manner has shown to be more accurate than configuring the OCR engine
        /// to not use the ligatures.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string ReplaceLigatures(string input)
        {
            string output = input;

            output = output.Replace("ﬀ", "ff");
            output = output.Replace("ﬁ", "fi");
            output = output.Replace("ﬂ", "fl");
            output = output.Replace("ﬀ", "ff");
            output = output.Replace("ﬃ", "ffi");
            output = output.Replace("ﬄ", "ffl");
            output = output.Replace("ﬅ", "ft");
            output = output.Replace("ﬆ", "st");
            output = output.Replace("—", "-");
            output = output.Replace("‘", "'");
            output = output.Replace("’", "'");
            output = output.Replace("»", ">>");

            return output;
        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
