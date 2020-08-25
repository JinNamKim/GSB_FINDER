using System;
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
using System.Media;


namespace GSBM_FINDER
{
    public partial class Form1 : Form
    {

        Thread Th_TIME;
        //Thread Th_M_1;
        //Thread Th_M_2;
        //Thread Th_M_5;
        Thread Th_FIND_M_1;
        Thread Th_FIND_M_2;
        Thread Th_FIND_M_5;

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

            comboBox1.Text = "3";
            comboBox2.Text = "3";
            comboBox3.Text = "3";

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

            Th_FIND_M_2 = new Thread(FIND_M_2);
            Th_FIND_M_2.Priority = ThreadPriority.Normal;
            Th_FIND_M_2.Start();

            Th_FIND_M_5 = new Thread(FIND_M_5);
            Th_FIND_M_5.Priority = ThreadPriority.Normal;
            Th_FIND_M_5.Start();
        }


        public void FIND_M_1()
        {
            int CHECK_COUNT = 2;
            while (true)
            {
                GC.Collect();
                if (DATA_M_1.Count == 15)
                {
                    int count = 0;

                    if (DATA_M_1[0].state == "0")
                    {
                        int index = 2;
                        if (DATA_M_1[1].result == DATA_M_1[index].result)
                        {
                            index += 1;
                            if (DATA_M_1[1].result == DATA_M_1[index].result)
                            {
                                index += 1;
                                count = 2;

                                if (DATA_M_1[0].result == DATA_M_1[index].result)
                                {
                                    index += 1;
                                    count = 3;
                                    if (DATA_M_1[0].result == DATA_M_1[index].result)
                                    {
                                        index += 1;
                                        count = 4;
                                        if (DATA_M_1[0].result == DATA_M_1[index].result)
                                        {
                                            index += 1;
                                            count = 5;
                                            if (DATA_M_1[0].result == DATA_M_1[index].result)
                                            {
                                                index += 1;
                                                count = 6;
                                                if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                {
                                                    index += 1;
                                                    count = 7;
                                                    if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                    {
                                                        index += 1;
                                                        count = 8;
                                                        if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                        {
                                                            index += 1;
                                                            count = 9;
                                                            if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                            {
                                                                index += 1;
                                                                count = 10;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        

                        if (DATA_M_1[1].result == "매수")
                        {
                            SetLabelText(label5, string.Format("SU : {0}", count));
                        }
                        else if (DATA_M_1[1].result == "매도")
                        {
                            SetLabelText(label5, string.Format("DO : {0}", count));
                        }
                    }
                    else
                    {
                        int index = 1;
                        if (DATA_M_1[0].result == DATA_M_1[index].result)
                        {
                            count = 2;
                            index += 1;
                            if (DATA_M_1[0].result == DATA_M_1[index].result)
                            {
                                index += 1;
                                count = 3;

                                if (DATA_M_1[0].result == DATA_M_1[index].result)
                                {
                                    index += 1;
                                    count = 4;
                                    if (DATA_M_1[0].result == DATA_M_1[index].result)
                                    {
                                        index += 1;
                                        count = 5;
                                        if (DATA_M_1[0].result == DATA_M_1[index].result)
                                        {
                                            index += 1;
                                            count = 6;
                                            if (DATA_M_1[0].result == DATA_M_1[index].result)
                                            {
                                                index += 1;
                                                count = 7;
                                                if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                {
                                                    index += 1;
                                                    count = 8;
                                                    if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                    {
                                                        index += 1;
                                                        count = 9;
                                                        if (DATA_M_1[0].result == DATA_M_1[index].result)
                                                        {
                                                            index += 1;
                                                            count = 10;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if(DATA_M_1[1].result == "매수")
                        {
                            SetLabelText(label5, string.Format("SU : {0}", count));
                        }
                        else if(DATA_M_1[1].result == "매도")
                        {
                            SetLabelText(label5, string.Format("DO : {0}", count));
                        }

                        //if (count > 0)
                        if (count >=  Convert.ToInt32(comboBox1.Text))
                        {
                            string PATH = System.Environment.CurrentDirectory.ToString();
                            SoundPlayer wp = new SoundPlayer(PATH + @"\1분.wav");
                            wp.Play();
                            MessageBox.Show("1");
                        }
                        
                    }
                }
                Thread.Sleep(1000 * 10);
            }
        }

        public void FIND_M_2()
        {
            int CHECK_COUNT = 2;
            while (true)
            {
                GC.Collect();
                if (DATA_M_2.Count == 15)
                {
                    int count = 0;

                    if (DATA_M_2[0].state == "0")
                    {
                        int index = 2;
                        if (DATA_M_2[1].result == DATA_M_2[index].result)
                        {
                            index += 1;
                            if (DATA_M_2[1].result == DATA_M_2[index].result)
                            {
                                index += 1;

                                count = 2;

                                if (DATA_M_2[0].result == DATA_M_2[index].result)
                                {
                                    index += 1;
                                    count = 3;
                                    if (DATA_M_2[0].result == DATA_M_2[index].result)
                                    {
                                        index += 1;
                                        count = 4;
                                        if (DATA_M_2[0].result == DATA_M_2[index].result)
                                        {
                                            index += 1;
                                            count = 5;
                                            if (DATA_M_2[0].result == DATA_M_2[index].result)
                                            {
                                                index += 1;
                                                count = 6;
                                                if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                {
                                                    index += 1;
                                                    count = 7;
                                                    if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                    {
                                                        index += 1;
                                                        count = 8;
                                                        if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                        {
                                                            index += 1;
                                                            count = 9;
                                                            if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                            {
                                                                index += 1;
                                                                count = 10;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        if (DATA_M_2[1].result == "매수")
                        {
                            SetLabelText(label6, string.Format("SU : {0}", count));
                        }
                        else if (DATA_M_2[1].result == "매도")
                        {
                            SetLabelText(label6, string.Format("DO : {0}", count));
                        }
                    }
                    else
                    {
                        int index = 1;
                        if (DATA_M_2[0].result == DATA_M_2[index].result)
                        {
                            count = 2;
                            index += 1;
                            if (DATA_M_2[0].result == DATA_M_2[index].result)
                            {
                                index += 1;
                                count = 3;

                                if (DATA_M_2[0].result == DATA_M_2[index].result)
                                {
                                    index += 1;
                                    count = 4;
                                    if (DATA_M_2[0].result == DATA_M_2[index].result)
                                    {
                                        index += 1;
                                        count = 5;
                                        if (DATA_M_2[0].result == DATA_M_2[index].result)
                                        {
                                            index += 1;
                                            count = 6;
                                            if (DATA_M_2[0].result == DATA_M_2[index].result)
                                            {
                                                index += 1;
                                                count = 7;
                                                if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                {
                                                    index += 1;
                                                    count = 8;
                                                    if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                    {
                                                        index += 1;
                                                        count = 9;
                                                        if (DATA_M_2[0].result == DATA_M_2[index].result)
                                                        {
                                                            index += 1;
                                                            count = 10;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (DATA_M_2[1].result == "매수")
                        {
                            SetLabelText(label6, string.Format("SU : {0}", count));
                        }
                        else if (DATA_M_2[1].result == "매도")
                        {
                            SetLabelText(label6, string.Format("DO : {0}", count));
                        }

                        //if (count > 0)
                        if (count >= Convert.ToInt32(comboBox2.Text))
                        {
                            string PATH = System.Environment.CurrentDirectory.ToString();
                            SoundPlayer wp = new SoundPlayer(PATH + @"\2분.wav");
                            wp.Play();
                            MessageBox.Show("2");
                        }

                    }
                }
                Thread.Sleep(1000 * 10);
            }
        }


        public void FIND_M_5()
        {
            int CHECK_COUNT = 2;
            while (true)
            {
                GC.Collect();
                if (DATA_M_5.Count == 15)
                {
                    int count = 0;

                    if (DATA_M_5[0].state == "0")
                    {
                        int index = 2;
                        if (DATA_M_5[1].result == DATA_M_5[index].result)
                        {
                            index += 1;
                            if (DATA_M_5[1].result == DATA_M_5[index].result)
                            {
                                index += 1;
                                count = 2;

                                if (DATA_M_5[0].result == DATA_M_5[index].result)
                                {
                                    index += 1;
                                    count = 3;
                                    if (DATA_M_5[0].result == DATA_M_5[index].result)
                                    {
                                        index += 1;
                                        count = 4;
                                        if (DATA_M_5[0].result == DATA_M_5[index].result)
                                        {
                                            index += 1;
                                            count = 5;
                                            if (DATA_M_5[0].result == DATA_M_5[index].result)
                                            {
                                                index += 1;
                                                count = 6;
                                                if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                {
                                                    index += 1;
                                                    count = 7;
                                                    if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                    {
                                                        index += 1;
                                                        count = 8;
                                                        if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                        {
                                                            index += 1;
                                                            count = 9;
                                                            if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                            {
                                                                index += 1;
                                                                count = 10;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        if (DATA_M_5[1].result == "매수")
                        {
                            SetLabelText(label7, string.Format("SU : {0}", count));
                        }
                        else if (DATA_M_5[1].result == "매도")
                        {
                            SetLabelText(label7, string.Format("DO : {0}", count));
                        }
                    }
                    else
                    {
                        int index = 1;
                        if (DATA_M_5[0].result == DATA_M_5[index].result)
                        {
                            count = 2;
                            index += 1;
                            if (DATA_M_5[0].result == DATA_M_5[index].result)
                            {
                                index += 1;
                                count = 3;

                                if (DATA_M_5[0].result == DATA_M_5[index].result)
                                {
                                    index += 1;
                                    count = 4;
                                    if (DATA_M_5[0].result == DATA_M_5[index].result)
                                    {
                                        index += 1;
                                        count = 5;
                                        if (DATA_M_5[0].result == DATA_M_5[index].result)
                                        {
                                            index += 1;
                                            count = 6;
                                            if (DATA_M_5[0].result == DATA_M_5[index].result)
                                            {
                                                index += 1;
                                                count = 7;
                                                if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                {
                                                    index += 1;
                                                    count = 8;
                                                    if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                    {
                                                        index += 1;
                                                        count = 9;
                                                        if (DATA_M_5[0].result == DATA_M_5[index].result)
                                                        {
                                                            index += 1;
                                                            count = 10;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (DATA_M_5[1].result == "매수")
                        {
                            SetLabelText(label7, string.Format("SU : {0}", count));
                        }
                        else if (DATA_M_5[1].result == "매도")
                        {
                            SetLabelText(label7, string.Format("DO : {0}", count));
                        }

                        //if (count > 0)
                        if (count >= Convert.ToInt32(comboBox3.Text))
                        {
                            string PATH = System.Environment.CurrentDirectory.ToString();
                            SoundPlayer wp = new SoundPlayer(PATH + @"\5분.wav");
                            wp.Play();
                            MessageBox.Show("5");
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
                GSBM_temp.MINUTE = "2";
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
                GSBM_temp.MINUTE = "5";
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

            if (Th_FIND_M_2.IsAlive)
            {
                Th_FIND_M_2.Abort();
                Th_FIND_M_2.Join();
            }

            if (Th_FIND_M_5.IsAlive)
            {
                Th_FIND_M_5.Abort();
                Th_FIND_M_5.Join();
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
