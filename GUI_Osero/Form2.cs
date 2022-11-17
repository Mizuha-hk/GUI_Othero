using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Osero
{
    public partial class Title : Form
    {
        private Osero_ApplicationContext context;
        public Title(Osero_ApplicationContext applicationContext)
        {
            InitializeComponent();

            this.context = applicationContext;
        }

        private void Title_Load(object sender, EventArgs e)
        {

        }

        //スタートボタンクリックメソッド
        private void StartButton_Click(object sender, EventArgs e)
        {
            //InGameに切り替え
            context.SwichForm(new InGame(this.context));
        }
    }
}
