using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(shortNumber("66-Н3-17 - перевод договора с корректировками контрагента"));
            IsPalindrome("A man, a plan, a canal: Panama");
        }

        //static public string shortNumber(string str)
        //{
        //    string[] str.Split('-');

        //    return ;

        //}

        static public bool IsPalindrome(string s)
        {
            s = s.ToLower().Replace("[^a-zA-Z0-9]", "");
            return true;
        }

        static public void Rotate(int[] nums, int k)
        {
            int[] tempArr = new int[nums.Length];
            k = k % nums.Length;
            for (int i = 0; i < nums.Length; i++)
                tempArr[(i + k)% nums.Length] = nums[i];
            tempArr.CopyTo(nums, 0);

        }

        static public string RepeatLimitedString(string s, int repeatLimit)
        {
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 'a']++;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 25; i >= 0; i--)
            {
                int pos = i;
                int limit = Math.Min(freq[pos], repeatLimit);
                for (int j = 0; j < limit; j++)
                {
                    sb.Append((char)((pos) + 'a'));
                    freq[pos]--;
                }
                if (freq[pos] >= 1)
                {
                    pos--;
                    while (pos >= 0 && freq[pos] == 0)
                    {
                        pos--;
                    }
                    if (pos < 0) break;
                    sb.Append((char)((pos) + 'a'));
                    freq[pos]--;
                    i++;
                }
            }
            return sb.ToString();
        }
    }
}
