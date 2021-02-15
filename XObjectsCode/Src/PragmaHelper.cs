using System.IO;
using System.Text;

namespace Xml.Schema.Linq.CodeGen
{
    static class PragmaHelper
    {
        public static void InsertFilePragma(this StringWriter writer, string pragma)
        {
            var builder = writer.GetStringBuilder();
            // Insert the pragma on the first blank line, which will be just after the <auto-generated> comment.            
            int blankIndex = IndexOfBlankLine(builder);
            builder.Insert(blankIndex, pragma + "\r\n");
        }

        private static int IndexOfBlankLine(StringBuilder builder)
        {
            // We look for two chars \n[\r\n], so the stop condition is one less than actual length
            for (int i = 0; i < builder.Length - 1; i++)
            {
                if (builder[i] == '\n')
                {
                    ++i;    // Safe because of the `Length - 1` stop condition
                    if (builder[i] == '\r' || builder[i] == '\n')
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
    }
}