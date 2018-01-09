using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATH
{
    class Point
    {
        public double x;
        public double y;
    }
    class Line
    {
        public double A;
        public double B;
        public double C;
    }
    class Circle
    {
        /// <summary>
        /// 圆的标准式参数a
        /// </summary>
        public double a;
        /// <summary>
        /// 圆的标准式参数b
        /// </summary>
        public double b;
        /// <summary>
        /// 圆的标准式参数r的平方
        /// </summary>
        public double r;
    }
    class Calculate
    {
        Data data = new Data();
        public string Point_To_String(Point point)
        {
            return "(" + point.x + "," + point.y + ")";
        }
        public string Line_To_String(Line line)
        {
            string str = "";
            if (line.A != 0) { str = line.A + "x"; }
            if (line.B < 0) { str += line.B + "y"; }
            else if (line.B > 0 && line.A != 0) { str += "+" + line.B + "y"; }
            else if (line.B > 0 && line.A == 0) { str += line.B + "y"; }
            if (line.C < 0) { str += line.C; }
            else if (line.C > 0) { str += "+" + line.C; }
            str += "=0";
            return str;
        }
        public string Circle_To_String(Circle circle)
        {
            string str = "";
            str = "(x";
            if(circle.a < 0) { str += circle.a + ")^2+(y"; }
            else if (circle.a > 0) { str += "+" + circle.a + ")^2+(y"; }
            else { str += ")^2+(y"; }
            if (circle.b < 0) { str += circle.b + ")^2="; }
            else if (circle.b > 0) { str += "+" + circle.b+ ")^2="; }
            else { str += ")^2="; }
            str += circle.r;
            return str;
        }
        /// <summary>
        /// 两直线交点
        /// </summary>
        /// <param name="l1">直线一</param>
        /// <param name="l2">直线二</param>
        /// <returns>交点</returns>
        public Point TwoLinePoint(Line l1,Line l2)
        {
            if(l1.B * l2.A - l1.A * l2.B == 0)
            {
                Data.OutPutText = Line_To_String(l1) + "与\n";
                Data.OutPutText += Line_To_String(l2) + "\n";
                Data.OutPutText += "所表示直线平行或重合，无交点";
                Data.OutPutTitle = "输入直线无交点";
                return null;
            }
            Point point = new Point();
            point.x = (l1.C * l2.B - l1.B * l2.C) / (l1.B * l2.A - l1.A * l2.B);
            point.y = (l1.A * l2.C - l1.C * l2.A) / (l1.B * l2.A - l1.A * l2.B);
            Data.OutPutTitle += "得到直线交点";
            Data.OutPutText += Line_To_String(l1) + "与\n";
            Data.OutPutText += Line_To_String(l2) + "\n";
            Data.OutPutText += "的交点为" + Point_To_String(point) + "\n";
            Data.OutPutText += "-------------------------\r\n";
            return point;
        }
        /// <summary>
        /// 点关于直线的对称点
        /// </summary>
        /// <param name="l">对称轴直线</param>
        /// <param name="P">原来的点</param>
        /// <returns>对称点</returns>
        public Point SymmetryPointAboutLine(Line l,Point P)
        {
            if (l.A * P.x + l.B * P.y + l.C == 0)
            {
                Data.OutPutText += Point_To_String(P) + "在直线\n";
                Data.OutPutText += Line_To_String(l) + "上\n";
                Data.OutPutText += "对称点为它本身";
                Data.OutPutTitle = "对称结果";
                return P;
            }
            Point reP = new Point();
            double k;
            k = (l.A * P.x + l.B * P.y + l.C) / (Math.Pow(l.A, 2) + Math.Pow(l.B, 2));
            reP.x = P.x - 2 * l.A * k;
            reP.y = P.y - 2 * l.B * k;
            Data.OutPutText += Point_To_String(P) + "关于直线\n";
            Data.OutPutText += Line_To_String(l) + "\n";
            Data.OutPutText += "的对称点为"+Point_To_String(reP)+"\n";
            Data.OutPutText += "-------------------------\r\n";
            Data.OutPutTitle = "对称结果";
            return reP;
        }
        /// <summary>
        /// 两点中垂线
        /// </summary>
        /// <param name="P1">点一</param>
        /// <param name="P2">点二</param>
        /// <returns>中垂线</returns>
        public Line TwoPointMidperpendicular(Point P1,Point P2)
        {
            if (P1.x == P2.x && P1.y == P2.y)
            {
                Data.OutPutTitle = "两点重合无中垂线";
                Data.OutPutText += "点" + Point_To_String(P1) + "和\n";
                Data.OutPutText += "点" + Point_To_String(P2) + "重合\n";
                Data.OutPutText += "-------------------------\r\n";
                return null;
            }
            Line line = new Line();
            line.A = 2 * (P2.x - P1.x);
            line.B = 2 * (P2.y - P1.y);
            line.C = Math.Pow(P1.x, 2) + Math.Pow(P1.y, 2) - Math.Pow(P2.x, 2) - Math.Pow(P2.y, 2);
            Data.OutPutTitle = "得到中垂线";
            Data.OutPutText += "点" + Point_To_String(P1) + "和\n";
            Data.OutPutText += "点" + Point_To_String(P2) + "的中垂线为\n";
            Data.OutPutText += Line_To_String(line) + "\n";
            double k = data.GCD(data.GCD(line.A, line.B), line.C);
            line.A = line.A / k;
            line.B = line.B / k;
            line.C = line.C / k;
            if(line.A<0)
            {
                line.A = -line.A;
                line.B = -line.B;
                line.C = -line.C;
            }
            Data.OutPutText += "化简结果为:\n"+Line_To_String(line) + "\n(小数分数求最大公因数会遇到问题)\n";
            Data.OutPutText += "-------------------------\r\n";
            return line;
        }
        /// <summary>
        /// 三点求圆
        /// </summary>
        /// <param name="P1">点一</param>
        /// <param name="P2">点二</param>
        /// <param name="P3">点三</param>
        /// <returns>圆</returns>
        public Circle ThreePointCricle(Point P1,Point P2,Point P3)
        {
            Circle circle = new Circle();
            Point center = new Point();
            Line l1 = new Line();
            Line l2 = new Line();
            if (P1.x == P3.x && P1.y == P3.y)
            {
                Data.OutPutText += "点" + Point_To_String(P1) + "和\n";
                Data.OutPutText += "点" + Point_To_String(P3) + "重合\n";
                Data.OutPutTitle = "中垂线出错";
                Data.OutPutText += "\n已终止计算\n";
                Data.OutPutText += "-------------------------\r\n";
                return null;
            }
            l1 = TwoPointMidperpendicular(P1, P2);
            if (l1 == null)
            {
                Data.OutPutTitle = "中垂线出错";
                Data.OutPutText += "\n已终止计算\n";
                Data.OutPutText += "-------------------------\r\n";
                return null;
            }
            l2 = TwoPointMidperpendicular(P2, P3);
            if (l2 == null)
            {
                Data.OutPutTitle = "中垂线出错";
                Data.OutPutText += "\n已终止计算\n";
                Data.OutPutText += "-------------------------\r\n";
                return null;
            }
            center = TwoLinePoint(l1,l2);
            if (center == null)
            {
                Data.OutPutTitle = "圆心出错";
                Data.OutPutText += "\n已终止计算";
                Data.OutPutText += "-------------------------\r\n";
                return null;
            }
            circle.a = center.x;
            circle.b = center.y;
            circle.r = Math.Pow(center.x - P1.x, 2) + Math.Pow(center.y - P1.y, 2);
            if (circle.r == 0)
            {
                Data.OutPutTitle = "圆为一点";
                Point p = new Point();
                p.x = circle.a;
                p.y = circle.b;
                Data.OutPutText += "结果为点" + Point_To_String(p)+"\n";
                Data.OutPutText += "-------------------------\r\n";
                return circle;
            }
            Data.OutPutTitle = "求解圆方程成功";
            Data.OutPutText += "过点:" + Point_To_String(P1) + "," + Point_To_String(P2) + "," + Point_To_String(P3) + "\n";
            Data.OutPutText += "的圆为" + Circle_To_String(circle)+"\n";
            Data.OutPutText += "-------------------------\r\n";
            return circle;
        }
        /// <summary>
        /// 三点求面积
        /// </summary>
        /// <param name="P1">点一</param>
        /// <param name="P2">点二</param>
        /// <param name="P3">点三</param>
        /// <returns>面积</returns>
        public double ThreePointArea(Point P1, Point P2, Point P3)
        {
            double S=0;
            S = Math.Abs(P1.x * (P2.y - P3.y) + P2.x * (P3.y - P1.y) + P3.x * (P1.y - P2.y)) / 2;
            if (S == 0)
            {
                Data.OutPutTitle = "三点共线";
                Data.OutPutText += Point_To_String(P1) + "," + Point_To_String(P2) + "," + Point_To_String(P3) + "三点共线\n";
                Line line = new Line();
                line.A = (P1.y - P2.y);
                line.B = (P2.x - P1.x);
                line.C = P1.x * P2.y - P1.y * P2.x;
                Data.OutPutText += "于直线"+Line_To_String(line) + "\n";
                double k = data.GCD(data.GCD(line.A, line.B), line.C);
                line.A = line.A / k;
                line.B = line.B / k;
                line.C = line.C / k;
                if (line.A < 0)
                {
                    line.A = -line.A;
                    line.B = -line.B;
                    line.C = -line.C;
                }
                Data.OutPutText += "化简结果为:\n" + Line_To_String(line) + "\n(小数分数求最大公因数会遇到问题)\n";
                Data.OutPutText += "-------------------------\r\n";
            }
            Data.OutPutTitle = "成功求得面积";
            Data.OutPutText += Point_To_String(P1) + "," + Point_To_String(P2) + "," + Point_To_String(P3) + "三点的面积为\n";
            Data.OutPutText += S + "\n";
            return S;
        }
    }
}
