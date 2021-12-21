using System;
using System.Windows.Forms;

namespace LinkedIn_Applier
{
    internal class Messages
    {
        internal static void Error(string message, string Header = "ERROR!")
        {
            MessageBox.Show(message, Header, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static void Info(string message, string Header = "INFO!")
        {
            MessageBox.Show(message, Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static DialogResult AskInfo(string message, string Header = "QUESTION!")
        {
          return  MessageBox.Show(message, Header, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}