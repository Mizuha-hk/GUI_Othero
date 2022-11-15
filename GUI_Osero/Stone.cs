using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GUI_Osero
{
    internal class Stone
    {
        /*ターンを決める変数
         0：白のターン
         1：黒のターン*/
        public sbyte turn = 1;

        //配置完了したかどうかの変数
        public bool putCompleate;

        //配置可能かを格納する変数
        public bool pAble = false;

        //各座標のマスのデータ
        public sbyte[,] stones = new sbyte[8, 8];

        //盤面初期化
        public void def_set()
        {
            for(sbyte i = 0; i < 8; i++)
            {
                for(sbyte j = 0; j < 8; j++)
                {
                    stones[i, j] = 2;
                }
            }
            stones[3, 3] = 0;
            stones[4, 4] = 0;
            stones[3, 4] = 1;
            stones[4, 3] = 1;
        }
        //データ上で配置とひっくり返しのメソッド
        public void put(sbyte i, sbyte j)
        {
            //配置完了かどうかを格納する
            this.putCompleate = false;

            if (this.stones[i, j] == 2)  //駒配置の前提として配置場所が空白（2）である必要がある
            {
                /*置きたいマス（0，0）を基準に方向を指定する（x,y）
                  ____________________
                 |-1，-1| 0, -1| 1, -1|
                 |______|______|______|
                 |-1,  0| 0,  0| 1,  0|
                 |______|______|______|
                 |-1,  1| 0,  1| 1,  1|
                 |______|______|______|
                
                 順に方向を指定して探索する*/
                for(sbyte x = -1; x <= (sbyte)1; x+=(sbyte)1)
                {
                    for(sbyte y = -1; y <= (sbyte)1; y+=(sbyte)1)
                    {
                        //（0，0）は除外
                        if (x == 0 && y == 0) { }
                        else
                        {
                            //探索方向の2マス先から自分の駒がないか探索
                            for (sbyte t = 2; t < 8; t++)
                            {
                                //探索中のマスが配列の定義内の時かつ探索方向の隣が相手の駒のとき
                                if (i + (t * x) < (sbyte)8 && i + (t * x) >= (sbyte)0 && j + (t * y) < (sbyte)8 && j + (t * y) >= (sbyte)0 && this.stones[i + x, j + y] == (sbyte)((this.turn + 1) % 2))
                                {
                                    //探索先のマスが空白（2）だった時はひっくり返せないので即ブレイク
                                    if (this.stones[i + (t * x), j + (t * y)] == 2)
                                    {
                                        break;
                                    }
                                    //探索先が自分の駒だった場合
                                    else if (this.stones[i + (t * x), j + (t * y)] == this.turn)
                                    {
                                        for (sbyte k = 0; k < t; k++)
                                        {
                                            //置きたいマスと自分の駒の間を自分の駒にする
                                            this.stones[i + (x * k), j + (y * k)] = this.turn;
                                        }
                                        //配置可能であり、配置が完了したので真とする
                                        this.putCompleate = true;
                                        //この方向の探索は終了とし、ブレイクする
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(this.putCompleate == true)
            {
                //配置完了したのでターンを次に進める
                this.turn = (sbyte)((this.turn + 1) % 2); 
            }
        }

        //置けるかどうか調査し、置けない場合はターンを進めるメソッド
        public void pAble_Sertch()
        {
            Debug.WriteLine("サーチ関数が呼び出された");    //一回しか呼び出されていない！！
            pAble = false;
            //マス全体を調査していく
            for (sbyte i = 0; i < 8; i++)
            {
                for (sbyte j = 0; j < 8; j++)
                {
                    //以降配置メソッドと同様の探索方法
                    if (this.stones[i,j] == 2)
                    {
                        for(sbyte x = -1; x <= 1; x++)
                        {
                            for(sbyte y = -1; y <= 1; y++)
                            {
                                if(x == 0 && y == 0) { }
                                else
                                {
                                    for(sbyte t = 2; t < 7; t++)
                                    {
                                        if(i + (t * x) < (sbyte)8 && i + (t * x) >= (sbyte)0 && j + (t * y) < (sbyte)8 && j + (t * y) >= (sbyte)0 && this.stones[i + x, j + y] == (sbyte)((this.turn + 1) % 2))
                                        {
                                            if(this.stones[i + (t * x), j + (t * y)] == 2)
                                            {
                                                break;
                                            }
                                            else if(this.stones[i + (t * x), j + (t * y)] == this.turn)
                                            {
                                                //配置可能なマスが少なくとも1つあるので、pAbleを真とし、探索終了とする
                                                pAble = true;
                                                Debug.WriteLine("returnで帰った");
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (pAble == false)
            {
                //ここまで到達したら置くマスがないことになるのでターンを進める
                this.turn = (sbyte)((this.turn + 1) % 2);
                MessageBox.Show("置けるマスがないため、パスしました");
            }
        }
    }
}
