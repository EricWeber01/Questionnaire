using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questionnaire
{
    public class ancet
    {
        string name, famil, email, tel;
        public ancet() { }
        public ancet(string _name, string _famil, string _email, string _tel) { name = _name; famil = _famil; email = _email; tel = _tel; }
        public string Name { get { return name; } set { name = value; } }
        public string Famil { get { return famil; } set { famil = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Tel { get { return tel; } set { tel = value; } }
        public override string ToString()
        {
            return $"{name} - {famil}";
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
