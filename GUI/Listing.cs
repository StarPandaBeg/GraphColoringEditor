using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IND_KDM.GUI
{
    public class Listing
    {
        private static TextBox _textBox;
        public static string FilePath = "log.txt";

        public static void Init(TextBox label)
        {
            _textBox = label;
            File.Create(FilePath).Close();
        }

        public static void AddLine(string line)
        {
            _textBox.AppendText(line + "\r\n");
            File.AppendAllText(FilePath, line + "\n");
        }
    }
}
