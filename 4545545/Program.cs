using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4545545
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1112410051_羅郁琇
            // 取得使用者輸入
            Console.Write("請輸入圓的半徑: ");
            if (!double.TryParse(Console.ReadLine(), out double radius) || radius <= 0)
            {
                Console.WriteLine("半徑輸入錯誤，請輸入正數。");
                return;
            }

            Console.Write("請輸入圓週率的精度 (4 <= n <= 15): ");
            if (!int.TryParse(Console.ReadLine(), out int precision))
            {
                Console.WriteLine("精度輸入錯誤，請輸入整數。");
                return;
            }

            // 計算圓週率
            double pi = CountPi(precision);

            // 驗證精度是否正確
            if (pi == -1)
            {
                Console.WriteLine("精度輸入超出範圍，程式結束。");
                return;
            }

            // 輸出計算結果
            Console.WriteLine("使用精度 {0} 計算的圓週率: {1:g}", precision, pi);
            double circumference = GetCircumference(radius);
            Console.WriteLine("圓週長: {0:g}", circumference);
            double area = GetCircleArea(radius);
            Console.WriteLine("圓面積: {0:g}", area);
        }

        /// <summary>
        /// 使用 Leibniz 公式計算圓週率。
        /// </summary>
        /// <param name="n">計算次數，必須介於 4 和 15 之間。</param>
        /// <returns>若 n 在範圍內，返回計算的圓週率；否則返回 -1。</returns>
        static double CountPi(int n)
        {
            if (n < 4 || n > 15) return -1;

            double pi = 0.0;
            for (int i = 0; i < n; i++)
            {
                pi += Math.Pow(-1, i) / (2 * i + 1);
            }
            return pi * 4;
        }

        /// <summary>
        /// 計算圓的週長。
        /// </summary>
        /// <param name="r">圓的半徑。</param>
        /// <returns>圓的週長。</returns>
        static double GetCircumference(double r)
        {
            double pi = CountPi(15); // 預設使用最高精度
            return pi * r * 2;
        }

        /// <summary>
        /// 計算圓的面積。
        /// </summary>
        /// <param name="r">圓的半徑。</param>
        /// <returns>圓的面積。</returns>
        static double GetCircleArea(double r)
        {
            double pi = CountPi(15); // 預設使用最高精度
            return pi * r * r;
        }
    }   
}
