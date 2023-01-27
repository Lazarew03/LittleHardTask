using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHardTask
{
    public class SpearmanCorrelation
    {
        public class Variables
        {
            public double x, y, rx, ry, dr;
        }
        public class Sort_Rank
        {
            public void QuickX(int left, int right, ref Variables[] a)
            {
                int l, r;
                Variables mid = new Variables();
                l = left; r = right; mid = a[l];
                do
                {
                    while ((a[r].x >= mid.x) & (l < r)) r = r - 1;
                    a[l] = a[r]; a[r] = mid;
                    while ((a[l].x <= mid.x) & (l < r)) l = l + 1;
                    a[r] = a[l]; a[l] = mid;
                } while (l != r); a[l] = mid;
                if (left < l - 1) QuickX(left, l - 1, ref a);
                if (l + 1 < right) QuickX(l + 1, right, ref a);
            }

            public void QuickY(int left, int right, ref Variables[] a)
            {
                int l, r;
                Variables mid = new Variables();
                l = left; r = right; mid = a[l];
                do
                {
                    while ((a[r].y >= mid.y) & (l < r)) r = r - 1;
                    a[l] = a[r]; a[r] = mid;
                    while ((a[l].y <= mid.y) & (l < r)) l = l + 1;
                    a[r] = a[l]; a[l] = mid;
                } while (l != r); a[l] = mid;
                if (left < l - 1) QuickY(left, l - 1, ref a);
                if (l + 1 < right) QuickY(l + 1, right, ref a);
            }
            public void RankX(int n, ref double t_a, ref Variables[] a)
            {
                int k, j = -1;
                double s;
                do
                {
                    j = j + 1;

                    if ((j != n) && (a[j].x == a[j + 1].x))
                    {
                        k = j + 1;
                        while ((k <= n) && (a[j].x == a[k].x)) k++;
                        k = k - 1;
                        s = (double)((k * (k + 1) / 2) - ((j - 1) * j / 2)) / (k - j + 1);
                        for (int h = j; h <= k; h++) a[h].rx = s + 1;
                        s = k - j + 1;
                        t_a = t_a + s * (s * s - 1) / 12;
                        j = k;
                    }
                    else
                    {
                        a[j].rx = j + 1;
                    }
                } while (j != n);
            }

            public void RankY(int n, ref double t_b, ref Variables[] a)
            {
                int k, j = -1;
                double s;
                do
                {
                    j = j + 1;

                    if ((j != n) && (a[j].y == a[j + 1].y))
                    {
                        k = j + 1;
                        while ((k <= n) && (a[j].y == a[k].y)) k++;
                        k = k - 1;
                        s = (double)((k * (k + 1) / 2) - ((j - 1) * j / 2)) / (k - j + 1);
                        for (int h = j; h <= k; h++) a[h].ry = s + 1;
                        s = k - j + 1;
                        t_b = t_b + s * (s * s - 1) / 12;
                        j = k;
                    }
                    else
                    {
                        a[j].ry = j + 1;
                    }
                } while (j != n);
            }

        }

       
        
    }
}

