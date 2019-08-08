using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace true_janken
{
    class Class1
    {
        public int hantei=0;           //あいこのときにループする
        public int max;                //cpuの人数
        public int fight;              //戦う回数
    }

    class Player
    {
        public int playmax;            //プレイヤー人数
    }

    class Count
    {
         protected int one = 0;
         protected int two = 0;
         protected int three = 0;          //出た目のフラグのための変数
        int sum = 0;
        public int CountSort(List<int> list)
        {
            foreach(int item in list)
            {
                if(item == 1)
                {
                    one = 1;
                }
                else if(item == 2)
                {
                    two = 1;
                }
                else
                {
                    three = 1;
                }
                
            }
            sum = one + two + three;
            return sum;
        }
    }  //出た手の種類をcount



    class Rule : Count
    {
        public int strong;              //勝ち判定の数字を格納するための変数
        public int WinRule(List<int> list)
        {
            CountSort(list);
            if(this.one == 0)
            {
                strong = 2;
            }
            else if(this.two == 0)
            {
                strong = 3;
            }
            else if(this.three == 0)
            {
                strong = 1;
            }
            return strong;
        }

    }   //勝ち判定の数字を返す


    class Report
    {
        public double kaisuu;             //戦績を出すためのじゃんけんの試行回数
        public int winnum=0;
    }       //成績を出すための勝ち数判定



    class FileOutput
    {
        public char output;      //ファイル出力するかどうかの入力
        public string FileName;  //ファイルの名前格納変数
    }
  
}
