using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IND_KDM.GUI
{
    public class Status
    {
        private static ToolStripStatusLabel _label;

        public static void Init(ToolStripStatusLabel label)
        {
            _label = label;
        }

        public static void Show(string text)
        {
            _label.Text = text;
        }

        public static void Clear()
        {
            _label.Text = string.Empty;
        }
    }
}
