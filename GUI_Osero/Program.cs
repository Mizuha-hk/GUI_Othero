using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Osero
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Osero_ApplicationContext());
        }
    }

    //アプリのコンテキストクラス
    public class Osero_ApplicationContext : ApplicationContext
    {
        public Osero_ApplicationContext()
        {
            this.MainForm = new Title(this);
        }

        //フォームを切り替えるメソッド
        public void SwichForm(Form NextForm)
        {
            var previousForm = this.MainForm;
            this.MainForm = NextForm;

            previousForm.Close();
            NextForm.Show();
        }
    }
}