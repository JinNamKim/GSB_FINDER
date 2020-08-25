﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;


namespace GSBM_FINDER
{
    public partial class Form1 : Form
    {

        Thread Th_TIME;
        //Thread Th_M_1;
        //Thread Th_M_2;
        //Thread Th_M_5;
        Thread Th_FIND_M_1;

        List<GSBM_DATA> DATA_M_1 = new List<GSBM_DATA>();
        List<GSBM_DATA> DATA_M_2 = new List<GSBM_DATA>();
        List<GSBM_DATA> DATA_M_5 = new List<GSBM_DATA>();

        public Form1()
        {
            InitializeComponent();
            init();
        }

        public class GSBM_DATA
        {
            public string MINUTE;
            public string game_date;
            public string game_time;
            public string start_price;
            public string state;
            public string result;
            public string close_price;
            public string high_price;
            public string low_price;
            public string update_date;
            public string stop_price;
        }

        public void init()
        {
            Th_TIME = new Thread(TIMECLOCK);
            Th_TIME.Priority = ThreadPriority.Highest;

            //Th_M_1 = new Thread(Function_M_1);
            //Th_M_1.Priority = ThreadPriority.Normal;
            //Th_M_1.Start();

            //Th_M_2= new Thread(Function_M_2);
            //Th_M_2.Priority = ThreadPriority.Normal;
            //Th_M_2.Start();

            //Th_M_5 = new Thread(Function_M_5);
            //Th_M_5.Priority = ThreadPriority.Normal;
            //Th_M_2.Start();

            Th_FIND_M_1 = new Thread(FIND_M_1);
            Th_FIND_M_1.Priority = ThreadPriority.Normal;
            Th_FIND_M_1.Start();
        }


        public void FIND_M_1()
        {
            int CHECK_COUNT = 2;
            while (true)
            {
                GC.Collect();
                if (DATA_M_1 != null)
                {
                    int DO_COUNT = 0;
                    int SU_COUNT = 0;

                    for (int i = 0; i < DATA_M_1.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (DATA_M_1[i].state == "0")
                            {
                                continue;
                            }
                            else
                            {
                                if (DATA_M_1[i].result == "매수")
                                {
                                    SU_COUNT += 1;
                                }
                                else if (DATA_M_1[i].result == "매도")
                                {
                                    DO_COUNT += 1;
                                }
                            }
                        }
                        else
                        {
                            if (DATA_M_1[i].result == "매수")
                            {
                                SU_COUNT += 1;
                                if (DO_COUNT == 0 && SU_COUNT >= CHECK_COUNT)
                                {
                                    SetLabelText(label5, string.Format("{0}DO 발생", DO_COUNT));
                                    break;
                                }
                            }
                            else if (DATA_M_1[i].result == "매도")
                            {
                                DO_COUNT += 1;
                                if (SU_COUNT == 0 && DO_COUNT >= CHECK_COUNT)
                                {
                                    SetLabelText(label5, string.Format("{0}SU 발생", SU_COUNT));
                                    break;
                                }
                            }
                        }
                    }

                }
                Thread.Sleep(1000 * 10);
            }
        }


        public void Function_M_1()
        {
            webBrowser1.Navigate("https://gsbm.co.kr/trade/resultlist/1");
        }

        public void Function_M_2()
        {
            webBrowser2.Navigate("https://gsbm.co.kr/trade/resultlist/2");
        }

        public void Function_M_5()
        {
            webBrowser3.Navigate("https://gsbm.co.kr/trade/resultlist/5");
        }

        public void TIMECLOCK()
        {
            DateTime NEXT_TIME_1 = new DateTime(1987, 4, 14, 0, 0, 0);
            DateTime NEXT_TIME_2 = new DateTime(1987, 4, 14, 0, 0, 0);
            DateTime NEXT_TIME_5 = new DateTime(1987, 4, 14, 0, 0, 0);

            while (true)
            {
                DateTime NOW = DateTime.Now;
                SetLabelText(label1, string.Format("{0:HH:mm:ss}", NOW));

                
                if (NOW.Second == 0)
                {
                    NEXT_TIME_1 = DateTime.Now.AddMinutes(1);
                    if (NOW.Minute % 2 == 0)
                    {
                        NEXT_TIME_2 = DateTime.Now.AddMinutes(2);
                    }
                    if (NOW.Minute % 5 == 0)
                    {
                        NEXT_TIME_5 = DateTime.Now.AddMinutes(5);
                    }
                }

                if (NEXT_TIME_1.Year != 1987)
                {
                    TimeSpan T_1 = NEXT_TIME_1.Subtract(DateTime.Now);
                    SetLabelText(label2, string.Format("{0:0}:{1:00}", T_1.Minutes, T_1.Seconds));
                }

                if (NEXT_TIME_2.Year != 1987)
                {
                    TimeSpan T_1 = NEXT_TIME_2.Subtract(DateTime.Now);
                    SetLabelText(label3, string.Format("{0:0}:{1:00}", T_1.Minutes, T_1.Seconds));
                }

                if (NEXT_TIME_5.Year != 1987)
                {
                    TimeSpan T_1 = NEXT_TIME_5.Subtract(DateTime.Now);
                    SetLabelText(label4, string.Format("{0:0}:{1:00}", T_1.Minutes, T_1.Seconds));
                }

                

                if (NOW.Second % 5 == 0)
                {
                    Function_M_1();
                }

                if (NOW.Second % 10 == 0)
                {
                    Function_M_2();
                }

                if (NOW.Second % 20 == 0)
                {
                    Function_M_5();
                }

                GC.Collect();
                Thread.Sleep(500);
            }
        }


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string result = webBrowser1.DocumentText;
            JObject J_result = JObject.Parse(result);
            int data_count = J_result["resultData"].Count();

            DATA_M_1.Clear();
            for (int i = 0; i < data_count; i++)
            {
                GSBM_DATA GSBM_temp = new GSBM_DATA();
                JObject data_temp = JObject.Parse(Convert.ToString(J_result["resultData"][i]));

                GSBM_temp.close_price = Convert.ToString(data_temp["close_price"]);
                GSBM_temp.game_date = Convert.ToString(data_temp["game_date"]);
                GSBM_temp.game_time = Convert.ToString(data_temp["game_time"]);
                GSBM_temp.high_price = Convert.ToString(data_temp["high_price"]);
                GSBM_temp.low_price = Convert.ToString(data_temp["low_price"]);
                GSBM_temp.MINUTE = "1";
                GSBM_temp.result = Convert.ToString(data_temp["result"]);
                GSBM_temp.start_price = Convert.ToString(data_temp["start_price"]);
                GSBM_temp.state = Convert.ToString(data_temp["state"]);
                GSBM_temp.stop_price = Convert.ToString(data_temp["stop_price"]);
                GSBM_temp.update_date = Convert.ToString(data_temp["update_date"]);

                DATA_M_1.Add(GSBM_temp);
            }
            userControl11.View_Result(DATA_M_1);
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string result = webBrowser2.DocumentText;
            JObject J_result = JObject.Parse(result);
            int data_count = J_result["resultData"].Count();

            DATA_M_2.Clear();
            for (int i = 0; i < data_count; i++)
            {
                GSBM_DATA GSBM_temp = new GSBM_DATA();
                JObject data_temp = JObject.Parse(Convert.ToString(J_result["resultData"][i]));

                GSBM_temp.close_price = Convert.ToString(data_temp["close_price"]);
                GSBM_temp.game_date = Convert.ToString(data_temp["game_date"]);
                GSBM_temp.game_time = Convert.ToString(data_temp["game_time"]);
                GSBM_temp.high_price = Convert.ToString(data_temp["high_price"]);
                GSBM_temp.low_price = Convert.ToString(data_temp["low_price"]);
                GSBM_temp.MINUTE = "1";
                GSBM_temp.result = Convert.ToString(data_temp["result"]);
                GSBM_temp.start_price = Convert.ToString(data_temp["start_price"]);
                GSBM_temp.state = Convert.ToString(data_temp["state"]);
                GSBM_temp.stop_price = Convert.ToString(data_temp["stop_price"]);
                GSBM_temp.update_date = Convert.ToString(data_temp["update_date"]);

                DATA_M_2.Add(GSBM_temp);
            }
            userControl12.View_Result(DATA_M_2);
        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string result = webBrowser3.DocumentText;
            JObject J_result = JObject.Parse(result);
            int data_count = J_result["resultData"].Count();

            DATA_M_5.Clear();
            for (int i = 0; i < data_count; i++)
            {
                GSBM_DATA GSBM_temp = new GSBM_DATA();
                JObject data_temp = JObject.Parse(Convert.ToString(J_result["resultData"][i]));

                GSBM_temp.close_price = Convert.ToString(data_temp["close_price"]);
                GSBM_temp.game_date = Convert.ToString(data_temp["game_date"]);
                GSBM_temp.game_time = Convert.ToString(data_temp["game_time"]);
                GSBM_temp.high_price = Convert.ToString(data_temp["high_price"]);
                GSBM_temp.low_price = Convert.ToString(data_temp["low_price"]);
                GSBM_temp.MINUTE = "1";
                GSBM_temp.result = Convert.ToString(data_temp["result"]);
                GSBM_temp.start_price = Convert.ToString(data_temp["start_price"]);
                GSBM_temp.state = Convert.ToString(data_temp["state"]);
                GSBM_temp.stop_price = Convert.ToString(data_temp["stop_price"]);
                GSBM_temp.update_date = Convert.ToString(data_temp["update_date"]);

                DATA_M_5.Add(GSBM_temp);
            }
            userControl13.View_Result(DATA_M_5);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Th_M_1.Start();
            //Th_M_2.Start();
            //Th_M_5.Start();
            Th_TIME.Start();
        }



        #region Label
        /// <summary>
        /// Label의 Text를 변경한다.
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="txt"></param>
        public static void SetLabelText(Label lbl, string txt)
        {
            if (lbl.InvokeRequired)
            {
                lbl.Invoke(new MethodInvoker(delegate
                {
                    lbl.Text = txt;
                }));
            }
            else
            {
                lbl.Text = txt;
            }
        }

        /// <summary>
        /// 라벨 글자의 색상 설정
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="Color"></param>
        public static void SetLabelColor(Label lbl, System.Drawing.Color Color)
        {
            if (lbl.InvokeRequired)
            {
                lbl.Invoke(new MethodInvoker(delegate
                {
                    lbl.ForeColor = Color;
                }));
            }
            else
            {
                lbl.ForeColor = Color;
            }
        }

        /// <summary>
        /// 라벨 배경 색 변경
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="Color"></param>
        public static void SetLabelBackColor(Label lbl, System.Drawing.Color Color)
        {
            if (lbl.InvokeRequired)
            {
                lbl.Invoke(new MethodInvoker(delegate
                {
                    lbl.BackColor = Color;
                }));
            }
            else
            {
                lbl.BackColor = Color;
            }
        }
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Th_TIME.IsAlive)
            {
                Th_TIME.Abort();
                Th_TIME.Join();
            }

            if (Th_FIND_M_1.IsAlive)
            {
                Th_FIND_M_1.Abort();
                Th_FIND_M_1.Join();
            }

            
            //Th_M_1.Abort();
            //Th_M_2.Abort();
            //Th_M_5.Abort();

            
            //Th_M_1.Join();
            //Th_M_2.Join();
            //Th_M_5.Join();
        }



    }
}