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
        //各座標のマスのデータ
        public Int16[,] stones = new Int16[8, 8];

        /*ターンを決める変数
         0：白のターン
         1：黒のターン*/
        public Int16 turn = 1;

        //盤面初期化
        public void def_set()
        {
            for(Int16 i = 0; i < 8; i++)
            {
                for(Int16 j = 0; j < 8; j++)
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
        public void put(Int16 i, Int16 j)
        {
            //配置可能かどうかを格納する
            bool putable = false;

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
                for(Int16 x = -1; x <= (Int16)1; x+=(Int16)1)
                {
                    for(Int16 y = -1; y <= (Int16)1; y+=(Int16)1)
                    {
                        //（0，0）は除外
                        if (x == 0 && y == 0) { }
                        else
                        {
                            //探索方向の2マス先から自分の駒がないか探索
                            for (Int16 t = 2; t < 8; t++)
                            {
                                //探索中のマスが配列の定義内の時かつ探索方向の隣が相手の駒のとき
                                if (i + (t * x) < (Int16)8 && i + (t * x) >= (Int16)0 && j + (t * y) < (Int16)8 && j + (t * y) >= (Int16)0 && this.stones[i + x, j + y] == (Int16)((this.turn + 1) % 2))
                                {
                                    //探索先のマスが空白（2）だった時はひっくり返せないので即ブレイク
                                    if (this.stones[i + (t * x), j + (t * y)] == 2)
                                    {
                                        break;
                                    }
                                    //探索先が自分の駒だった場合
                                    else if (this.stones[i + (t * x), j + (t * y)] == this.turn)
                                    {
                                        for (Int16 k = 0; k < t; k++)
                                        {
                                            //置きたいマスと自分の駒の間を自分の駒にする
                                            this.stones[i + (x * k), j + (y * k)] = this.turn;
                                        }
                                        //配置可能であり、配置が完了したので真とする
                                        putable = true;
                                        //この方向の探索は終了とし、ブレイクする
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(putable == true)
            {
                //配置完了したのでターンを次に進める
                this.turn = (Int16)((this.turn + 1) % 2); 
            }
        }


    }
}
