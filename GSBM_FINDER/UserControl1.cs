using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSBM_FINDER
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public void init()
        {
            SetLabelText(result_01, "NO");
            SetLabelText(result_02, "NO");
            SetLabelText(result_03, "NO");
            SetLabelText(result_04, "NO");
            SetLabelText(result_05, "NO");
            SetLabelText(result_06, "NO");
            SetLabelText(result_07, "NO");
            SetLabelText(result_08, "NO");
            SetLabelText(result_09, "NO");
            SetLabelText(result_10, "NO");
            SetLabelText(result_11, "NO");
            SetLabelText(result_12, "NO");
            SetLabelText(result_13, "NO");
            SetLabelText(result_14, "NO");
            SetLabelText(result_15, "NO");

            SetLabelBackColor(result_01, Color.Transparent);
            SetLabelBackColor(result_02, Color.Transparent);
            SetLabelBackColor(result_03, Color.Transparent);
            SetLabelBackColor(result_04, Color.Transparent);
            SetLabelBackColor(result_05, Color.Transparent);
            SetLabelBackColor(result_06, Color.Transparent);
            SetLabelBackColor(result_07, Color.Transparent);
            SetLabelBackColor(result_08, Color.Transparent);
            SetLabelBackColor(result_09, Color.Transparent);
            SetLabelBackColor(result_10, Color.Transparent);
            SetLabelBackColor(result_11, Color.Transparent);
            SetLabelBackColor(result_12, Color.Transparent);
            SetLabelBackColor(result_13, Color.Transparent);
            SetLabelBackColor(result_14, Color.Transparent);
            SetLabelBackColor(result_15, Color.Transparent);

        }

        public void View_Result(List<GSBM_FINDER.Form1.GSBM_DATA> result_list)
        {
            init();

            for (int i = 0; i < result_list.Count; i++)
            {

                string result = "";
                if (result_list[i].state == "0")
                {
                    result = "NO";
                }
                else
                {
                    if (result_list[i].result == "매수")
                    {
                        result = "SU";
                    }
                    else if (result_list[i].result == "매도")
                    {
                        result = "DO";
                    }
                }

                if (i == 0)
                {
                    Set_data(result_01, result);
                }
                else if(i == 1)
                {
                    Set_data(result_02, result);
                }
                else if (i == 2)
                {
                    Set_data(result_03, result);
                }
                else if (i == 3)
                {
                    Set_data(result_04, result);
                }
                else if (i == 4)
                {
                    Set_data(result_05, result);
                }

                else if (i == 5)
                {
                    Set_data(result_06, result);
                }
                else if (i == 6)
                {
                    Set_data(result_07, result);
                }
                else if (i == 7)
                {
                    Set_data(result_08, result);
                }
                else if (i == 8)
                {
                    Set_data(result_09, result);
                }
                else if (i == 9)
                {
                    Set_data(result_10, result);
                }
                else if (i == 10)
                {
                    Set_data(result_11, result);
                }
                else if (i == 11)
                {
                    Set_data(result_12, result);
                }
                else if (i == 12)
                {
                    Set_data(result_13, result);
                }
                else if (i == 13)
                {
                    Set_data(result_14, result);
                }
                else if (i == 14)
                {
                    Set_data(result_15, result);
                }
                
                    
                
                
            }
        }


        public void Set_data(Label label_name, string result)
        {
            SetLabelText(label_name, result);
            if (result == "NO")
            {
                SetLabelBackColor(label_name, Color.Transparent);
            }
            else if (result == "SU")
            {
                SetLabelBackColor(label_name, Color.Red);
            }
            else if (result == "DO")
            {
                SetLabelBackColor(label_name, Color.DodgerBlue);
            }
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
    }
}
