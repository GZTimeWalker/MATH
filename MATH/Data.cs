using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MATH
{
    class Data
    {
        /// <summary>
        /// 项目列表
        /// </summary>
        public string[] Items =
        {
                Properties.Resources.TwoLinePoint,
                Properties.Resources.SymmetryPointAboutLine,
                Properties.Resources.ThreePointArea,
                Properties.Resources.ThreePointCricle,
                Properties.Resources.TwoPointMidperpendicular
            };
        /// <summary>
        /// 获取项目数量
        /// </summary>
        /// <returns></returns>
        public int GetItemsCount() { return Items.Count(); }
        /// <summary>
        /// 求最大公因数
        /// </summary>
        /// <param name="x">整数x(int)</param>
        /// <param name="y">整数y(int)</param>
        /// <returns>x与y的最大公因数</returns>
        public double GCD(double x,double y)
        {
            double t;
            while (y != 0)
            {
                t = x % y;
                x = y;
                y = t;
            }
            return x;
        }
        private static string _OutPutText = "";
        /// <summary>
        /// 输出文本
        /// </summary>
        public static string OutPutText
        {
            get { return _OutPutText; }
            set { _OutPutText = value; }
        }
        private static string _OutPutTitle = "";
        /// <summary>
        /// 输出标题
        /// </summary>
        public static string OutPutTitle
        {
            get { return _OutPutTitle; }
            set { _OutPutTitle = value; }
        }
    }
}
