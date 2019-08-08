using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace true_janken
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> result = new List<string>();   //グーチョキパー格納
            Class1 class1 = new Class1();
            Report report = new Report();               //戦績を出すためのクラス
            List<double> win = new List<double>();            //勝ち数を記録するためのリスト
            Player p = new Player();                  //何回勝負するかのクラス
            List<string> name = new List<string>();     //プレイヤーの名前を格納するリスト


            int i;　                //繰り返し処理するための変数
            string namae;           //名前格納のための変数


            Console.WriteLine("じゃんけんをしましょう!");
            try                                                   //全体をtryで囲ってしまいエラー処理
            {
                Console.Write("何戦勝負にしますか？  =>");
                class1.fight = int.Parse(Console.ReadLine());     //stringをintに変換するための処理
                Console.Write("cpuの人数を入力してください =>");
                class1.max = int.Parse(Console.ReadLine());   //cpuの人数決め


                Console.Write("プレイヤーの人数を入力してください =>");
                p.playmax = int.Parse(Console.ReadLine());




                for (i = 0; i < p.playmax; i++)
                {
                    Console.Write("プレイヤーの名前を入力してください　=>");
                    namae = Console.ReadLine();
                    name.Add(namae);
                }    //プレイヤーの名前を格納
                for (i = 0; i < class1.max; i++)
                {
                    namae = ("cpu" + (i + 1));
                    name.Add(namae);
                }   //cpuの名前を格納





                for (int j = 0; j < class1.fight; j++)
                {
                    List<int> vs = new List<int>();     //全員分の1～3を格納


                    Console.WriteLine("みんなでじゃんけん勝負です！");
                    Console.WriteLine("****************************************************");
                    report.kaisuu++; //戦績を出すための施行した回数

                    Random rand = new Random((int)DateTime.Now.Ticks);     //乱数を取得するための処理


                    class1.hantei = 0;
                    while (class1.hantei == 0)    //あいこのときループさせるための設定
                    {
                        for (i = 0; i < p.playmax; i++)
                        {

                            Console.Write(name[i] + "さん、1から3の数字を入力して下さい \t 1:グー　2:チョキ　3:パー   =>");
                            vs.Add(int.Parse(Console.ReadLine()));
                        }


                        //入力した手を保持する


                        for (i = 0; i < class1.max; i++)
                        {
                            vs.Add(rand.Next(1, 4));
                        }
                        // 乱数を取得
                        //cpuの手を保持する


                        foreach (int item in vs)    //数字によってグーチョキパーを格納
                        {
                            if (item == 1)
                            {
                                result.Add("グー");
                            }
                            else if (item == 2)
                            {
                                result.Add("チョキ");
                            }
                            else if (item == 3)
                            {
                                result.Add("パー");
                            }
                            else
                            {
                                Console.WriteLine("入力エラーです！");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }

                        for (i = 0; i < class1.max + p.playmax; i++)   //結果の出力（コンソール上）
                        {
                            Console.Write(name[i] + "は");
                            Console.WriteLine(result[i]);
                        }
                        result.Clear();         //一旦クリア



                        Count c = new Count();
                        int counting = 0;
                        counting = c.CountSort(vs);
                        //何種類の手が出たか判断

                        Rule r = new Rule();         //勝ちパターンを記憶する世界


                        if (counting == 1 || counting == 3)
                        {
                            Console.WriteLine("あいこです！");
                            vs.Clear();                //出した手を一旦クリア
                            continue;

                        }



                        else
                        {
                            int Strong = r.WinRule(vs);     //Strongに勝ち判定を代入
                            Console.WriteLine("勝者");
                            for (i = 0; i < p.playmax + class1.max; i++)
                            {
                                win.Add(0);       //一旦0を格納しておく


                                if (vs[i] == Strong)
                                {
                                    Console.WriteLine("<" + name[i] + ">");
                                    report.winnum++;
                                    win[i] += 1;
                                }           //勝者の名前出すのと勝ち数を記録

                            }
                        }
                        vs.Clear();
                        class1.hantei = 1;    //いったんループを抜ける
                    }
                }
                class1.hantei = 0;







                Console.WriteLine("これが成績だ!");
                for (i = 0; i < class1.max + p.playmax; i++)
                {
                    double syouritu = win[i] / report.kaisuu;
                    Console.Write("|" + name[i] + ":");
                    Console.WriteLine(win[i] + "勝" + (report.kaisuu - win[i]) + "敗   勝率:" + syouritu + "|");

                }             //戦績の表示






                List<string> seiseki = new List<string>();
                for (i = 0; i < class1.max + p.playmax; i++)
                {
                    double syouritu = win[i] / report.kaisuu;
                    seiseki.Add(name[i]);
                    seiseki.Add(win[i] + "勝" + (report.kaisuu - win[i]) + "敗");
                    seiseki.Add("勝率:" + syouritu);
                }         //戦績をcsvファイルで出力するためのリスト作成



                FileOutput fileOutput = new FileOutput();
                Console.Write("ファイル出力しますか？  y:yes n:no  =>");
                fileOutput.output = Console.ReadLine()[0];

                if (fileOutput.output == 'y')
                {
                    Console.Write("ファイル名を入力してください(拡張子不要)  =>");
                    fileOutput.FileName = Console.ReadLine();


                    StreamWriter streamWriter = new StreamWriter(fileOutput.FileName + ".text", false, Encoding.UTF8);  //CSV形式でtextファイル
                    for (i = 0; i < 3 * (class1.max + p.playmax); i += 3)
                    {
                        streamWriter.WriteLine(string.Format(seiseki[i] + "," + seiseki[i + 1] + "," + seiseki[i + 2]));
                    }
                    streamWriter.Close();       //名前と戦績を格納したリストの出力

                }
                else if (fileOutput.output == 'n')
                {
                    Console.WriteLine("了解です。お疲れ様でした!");
                }
                else
                {
                    Console.WriteLine("ちゃんと入力してね、バイバイ");
                }

            }

            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("入力エラーです!!");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("入力エラーです!!");
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("入力エラーです!!");

            }
            //予期せぬ値が入力された時の処理


            Console.ReadLine();


        }

    }
}