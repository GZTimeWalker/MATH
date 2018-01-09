using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MATH
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Data data = new Data();
        Calculate calculate = new Calculate();
        Point Point_1 = new Point();
        Point Point_2 = new Point();
        Point Point_3 = new Point();
        Line Line_1 = new Line();
        Line Line_2 = new Line();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < data.GetItemsCount(); i++)
            {
                ItemsBox.Items.Add(data.Items[i]);
            }
        }
        private int Get_Item_Count()
        {
            for (int i = 0; i < data.GetItemsCount(); i++)
            {
                if (ItemsBox.SelectedItem.ToString() == data.Items[i]) return i;
            }
            return -1;
        }
        private void isLine1(bool isEnabled)
        {
            Line_1_A.IsEnabled = isEnabled;
            Line_1_B.IsEnabled = isEnabled;
            Line_1_C.IsEnabled = isEnabled;
        }
        private void isLine2(bool isEnabled)
        {
            Line_2_A.IsEnabled = isEnabled;
            Line_2_B.IsEnabled = isEnabled;
            Line_2_C.IsEnabled = isEnabled;
        }
        private void isPoint1(bool isEnabled)
        {
            Point_1_x.IsEnabled = isEnabled;
            Point_1_y.IsEnabled = isEnabled;
        }
        private void isPoint2(bool isEnabled)
        {
            Point_2_x.IsEnabled = isEnabled;
            Point_2_y.IsEnabled = isEnabled;
        }
        private void isPoint3(bool isEnabled)
        {
            Point_3_x.IsEnabled = isEnabled;
            Point_3_y.IsEnabled = isEnabled;
        }
        private void Try_Int(object sender, TextChangedEventArgs e)
        {
            Point_1.x = TryGetValue(Point_1_x);
            Point_1.y = TryGetValue(Point_1_y);
            Point_2.x = TryGetValue(Point_2_x);
            Point_2.y = TryGetValue(Point_2_y);
            Point_3.x = TryGetValue(Point_3_x);
            Point_3.y = TryGetValue(Point_3_y);
            Line_1.A = TryGetValue(Line_1_A);
            Line_1.B = TryGetValue(Line_1_B);
            Line_1.C = TryGetValue(Line_1_C);
            Line_2.A = TryGetValue(Line_2_A);
            Line_2.B = TryGetValue(Line_2_B);
            Line_2.C = TryGetValue(Line_2_C);
        }
        private double TryGetValue(TextBox box)
        {
            if (box.Text == "") return 0;
            if (box.Text == "-") return -1;
            double i;
            if (double.TryParse(box.Text, out i)) { return i; }
            else { MessageBox.Show("请输入一个数字！", "错误"); box.Text=""; return 0; }
        }
        private void ItemsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Get_Item_Count())
            {
                case 0:
                    //TwoLinePoint两线交点
                    isPoint1(false);
                    isPoint2(false);
                    isPoint3(false);
                    isLine1(true);
                    isLine2(true);
                    break;
                case 1:
                    //SymmetryPointAboutLine点关于线的对称点
                    isPoint1(true);
                    isPoint2(false);
                    isPoint3(false);
                    isLine1(true);
                    isLine2(false);
                    break;
                case 2:
                    //ThreePointArea三点求面积
                    isPoint1(true);
                    isPoint2(true);
                    isPoint3(true);
                    isLine1(false);
                    isLine2(false);
                    break;
                case 3:
                    //ThreePointCricle三点求圆
                    isPoint1(true);
                    isPoint2(true);
                    isPoint3(true);
                    isLine1(false);
                    isLine2(false);
                    break;
                case 4:
                    //TwoPointMidperpendicular两点中垂线
                    isPoint1(true);
                    isPoint2(true);
                    isPoint3(false);
                    isLine1(false);
                    isLine2(false);
                    break;
                default:
                    MessageBox.Show("错误的命令指示");
                    break;
            }
        }
        private void Run_Botton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsBox.SelectedItem == null)
            {
                MessageBox.Show("请选择计算需求", "错误");
                return;
            }
            ClearOutPut();
            switch (Get_Item_Count())
            {
                case 0:
                    //TwoLinePoint两线交点
                    Point tlp = new Point();  
                    tlp = calculate.TwoLinePoint(Line_1,Line_2);
                    if (tlp == null) { ErrorMessage(); }
                    else { ShowMessage(); }
                    break;
                case 1:
                    //SymmetryPointAboutLine点关于线的对称点
                    Point spa = new Point();
                    spa = calculate.SymmetryPointAboutLine(Line_1,Point_1);
                    if (spa == null) { ErrorMessage(); }
                    else { ShowMessage(); }
                    break;
                case 2:
                    //ThreePointArea三点求面积
                    double S = 0;
                    S = calculate.ThreePointArea(Point_1, Point_2, Point_3);
                    ShowMessage();
                    break;
                case 3:
                    //ThreePointCricle三点求圆
                    Circle tpc = new Circle();
                    tpc = calculate.ThreePointCricle(Point_1,Point_2,Point_3);
                    if (tpc == null) { ErrorMessage(); }
                    else { ShowMessage(); }
                    break;
                case 4:
                    //TwoPointMidperpendicular两点中垂线
                    Line tpm = new Line();
                    tpm = calculate.TwoPointMidperpendicular(Point_1,Point_2);
                    if (tpm == null) { ErrorMessage(); }
                    else { ShowMessage(); }
                    break;
                default:
                    MessageBox.Show("错误的命令指示");
                    break;
            }
        }
        public  void ChangeOutPutText(string OutPut,bool is_Add)
        {
            if (is_Add)
            {
                OutPutTextBox.Text += OutPut;
            }
            else
            {
                OutPutTextBox.Text = OutPut;
            }
        }
        private void Clear_Botton_Click(object sender, RoutedEventArgs e)
        {
            Point_1_x.Text="";
            Point_1_y.Text="";
            Point_2_x.Text="";
            Point_2_y.Text="";
            Point_3_x.Text="";
            Point_3_y.Text="";
            Line_1_A.Text="";
            Line_1_B.Text="";
            Line_1_C.Text="";
            Line_2_A.Text="";
            Line_2_B.Text="";
            Line_2_C.Text="";
            ClearOutPut();
            MessageBox.Show("已清空输出","信息");
        }
        private void ClearOutPut()
        {
            Data.OutPutText = "";
            Data.OutPutTitle = "";
            OutPutTextBox.Text = "";
        }
        /// <summary>
        /// 错误反馈
        /// </summary>
        public void ErrorMessage()
        {
            string reText = "----------Error----------\r\n";
            reText += "错误：" + Data.OutPutTitle+ "\r\n";
            reText += "错误信息:\r\n";
            reText +=  Data.OutPutText + "\r\n";
            ChangeOutPutText(reText, false);
            MessageBox.Show(Data.OutPutText, Data.OutPutTitle);
        }
        public void ShowMessage()
        {
            string reText = "---------Success---------\r\n";
            reText += "任务：" + Data.OutPutTitle + "\r\n";
            reText += "任务信息:\r\n";
            reText += Data.OutPutText + "\r\n";
            ChangeOutPutText(reText, false);
        }
    }
}
