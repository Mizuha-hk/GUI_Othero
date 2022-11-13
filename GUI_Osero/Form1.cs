using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Osero
{
    public partial class Form1 : Form
    {
        //picturBoxコントロールの配列フィールド作成
        private System.Windows.Forms.PictureBox[,] stone;
        Stone stone_status = new Stone();


        public Form1()
        {
            InitializeComponent();
        }

        //formのロードイベントハンドラ
        private void Form1_Load(object sender, EventArgs e)
        {
            //駒のステータス初期化
            stone_status.def_set();

            //マスの配列作成
            this.stone = new System.Windows.Forms.PictureBox[8,8];

            //picturBoxのインスタンス作成
            for(Int16 i = 0; i < 8; i++)
            {
                for(Int16 j = 0; j < 8; j++)
                {
                    this.stone[i,j] = new System.Windows.Forms.PictureBox();
                    //プロパティ設定
                    this.stone[i, j].Name = "Stone" + i.ToString() + j.ToString();
                    this.stone[i, j].Size = new Size(50, 50);
                    this.stone[i, j].Location = new Point(12 + (50 * i), 12 + (50 * j));
                    this.stone[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    this.stone[i, j].Tag = "P" + i.ToString() + j.ToString();

                    if (stone_status.stones[i,j] == 2)
                    {
                        this.stone[i, j].Image = System.Drawing.Image.FromFile(@"..\..\Properties\None.png");
                    }
                    else if(stone_status.stones[i,j] == 0)
                    {
                        this.stone[i, j].Image = System.Drawing.Image.FromFile(@"..\..\Properties\White.png");
                    }
                    else
                    {
                        this.stone[i, j].Image = System.Drawing.Image.FromFile(@"..\..\Properties\Black.png");
                    }

                    this.Controls.Add(this.stone[i, j]);

                    this.stone[i,j].Click += new System.EventHandler(this.stone_Click);
                }
            }
            this.ResumeLayout(false);
        }

        
        private void stone_Click(object sender ,EventArgs e)
        {
            //クリックされたオブジェクトからTagを取得し、座標として変換
            Int16 i = Int16.Parse(((PictureBox)sender).Tag.ToString().Substring(1, 1));
            Int16 j = Int16.Parse(((PictureBox)sender).Tag.ToString().Substring(2, 1));

            //取得した座標からデータ上ひっくり返す
            stone_status.put(i, j);

            //全データを参照してマスの表示切替
            for (Int16 x = 0; x < 8; x++)
            {
                for (Int16 y = 0; y < 8; y++)
                {
                    if (stone_status.stones[x, y] == 0)
                    {
                        this.stone[x, y].Image = System.Drawing.Image.FromFile(@"..\..\Properties\White.png");
                    }
                    else if (stone_status.stones[x, y] == 1)
                    {
                        this.stone[x, y].Image = System.Drawing.Image.FromFile(@"..\..\Properties\Black.png");
                    }
                }
            }

        }
    }
}
