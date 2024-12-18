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
            Rotate(new int[] { -1, -100, 3, 99 },2);
        }

        static public void Rotate(int[] nums, int k)
        {
            int temp1 = nums[0];
            int temp2 = 0;
            int index = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (index == 0 && j != 0)
                {
                    index++;
                    temp1 = nums[index];
                    temp1 = 0;
                }
                if (index + k < nums.Length)
                {
                    if (temp1 != 0)
                    {
                        temp2 = nums[index + k];
                        nums[index + k] = temp1;
                        temp1 = 0;
                        index = index + k;
                        continue;
                    }
                    if (temp2 != 0)
                    {
                        temp1 = nums[index + k];
                        nums[index + k] = temp2;
                        temp2 = 0;
                        index = index + k;
                        continue;
                    }
                }
                else
                {
                    index = ((index + k) - nums.Length);
                    if (temp1 != 0)
                    {
                        temp2 = nums[index];
                        nums[index] = temp1;
                        temp1 = 0;                        
                        continue;
                    }
                    if (temp2 != 0)
                    {
                        temp1 = nums[index];
                        nums[index] = temp2;
                        temp2 = 0;                        
                        continue;
                    }
                }
            }
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
