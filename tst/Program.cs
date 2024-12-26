using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(HIndex(new int[] { 1,2,3,4,4,5 }));
            Console.Read();
        }

        //https://leetcode.com/problems/h-index/?envType=study-plan-v2&envId=top-interview-150
        static public int HIndex(int[] citations)
        {
            Array.Sort(citations);
            int buf = 0;
            for(int i = citations.Length-1;i>-1;i--)
            {
                if (buf < citations[i])
                    buf++;
                else
                    return buf;

            }
            return buf;
        }

        //https://leetcode.com/problems/word-pattern/?envType=study-plan-v2&envId=top-interview-150
        static public bool WordPattern(string pattern, string s)
        {
            string[] str = s.Split(' ');
            if (pattern.Length != str.Length) return false;
            Dictionary<char, string> map = new Dictionary<char, string>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if (map.ContainsKey(pattern[i]))
                {
                    if (map[pattern[i]] != str[i]) return false;
                }
                else
                {
                    if (map.ContainsValue(str[i])) return false;
                    map.Add(pattern[i], str[i]);
                }
            }
            return true;
        }        

        //https://leetcode.com/problems/valid-anagram/?envType=study-plan-v2&envId=top-interview-150
        static public bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length) return false;
            Dictionary<char, int> dicS = new Dictionary<char, int>();
            Dictionary<char, int> dicT = new Dictionary<char, int>();
            foreach (char c in s)
                if (!dicS.ContainsKey(c))
                    dicS.Add(c, 1);
                else
                    dicS[c]++;
            foreach (char c in t)
                if (!dicT.ContainsKey(c))
                    dicT.Add(c, 1);
                else
                    dicT[c]++;
            foreach (char c in dicS.Keys)
            {
                if (!dicT.ContainsKey(c))
                    return false;
                if (dicS[c] != dicT[c])
                    return false;
            }
            return true;
        }

        //https://leetcode.com/problems/ransom-note/?envType=study-plan-v2&envId=top-interview-150
        static public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> rn = new Dictionary<char, int>();
            Dictionary<char, int> mag = new Dictionary<char, int>();
            foreach (char c in ransomNote)
                if (!rn.ContainsKey(c))
                    rn.Add(c, 1);
                else
                    rn[c]++;
            foreach (char c in magazine)
                if (!mag.ContainsKey(c))
                    mag.Add(c, 1);
                else
                    mag[c]++;
            foreach (char c in rn.Keys)
            {
                if (!mag.ContainsKey(c))
                    return false;
                if (rn[c] > mag[c])
                    return false;
            }
            return true;
        }

        //https://leetcode.com/problems/is-subsequence/?envType=study-plan-v2&envId=top-interview-150
        static public bool IsSubsequence(string s, string t)
        {            
            int index = 0;
            foreach (char chr in t)
            {
                if (index == s.Length)
                    return true;
                if (chr == s[index])
                    index++;
            }
            return index == s.Length;
        }

        //https://leetcode.com/problems/length-of-last-word/submissions/1485561199/?envType=study-plan-v2&envId=top-interview-150
        static public int LengthOfLastWord(string s)
        {
            string[] buf = s.Trim().Split(' ');
            return buf[buf.Count()-1].Length;
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/?envType=study-plan-v2&envId=top-interview-150
        static public int MaxProfit(int[] prices)
        {
            int res = 0;
            int min = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min)
                    min = prices[i];
                if (prices[i] - min > res)
                    res = prices[i] - min;
            }
            return res;
        }

        static public int RemoveDuplicates(int[] nums)
        {
            Dictionary <int,int> dic = new Dictionary<int, int> ();
            int res = 0;
            foreach (int num in nums)
            {
                if(!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else if (dic[num] < 2)
                    dic[num] = 2;
            }
            Array.Clear(nums, 0, nums.Length);
            int i = 0;
            foreach(int key in dic.Keys)
            {
                res += dic[key];
                for(int j = 0; j < dic[key];j++)
                {
                    nums[i] = key;
                    i++;
                }
            }
            return res;

        }
        static public string shortNumber(string str)
        {
            if (str.Length > 49)
            {
                string[] s = str.Trim().Split('-');
                return s[0] + '-' + s[1] + '-' + s[2];
            }
            else return str;

        }        

        static public bool IsPalindrome(string s)
        {
            s = Regex.Replace(s, "[^a-zA-Z0-9]+", "").ToLower();
            int len = s.Length;
            if (len == 0)
                return true;
            for (int i = 0; i < len; i++)
                if (s[i] != s[len - 1 - i])
                    return false;
            return true;
        }

        static public void Rotate(int[] nums, int k)
        {
            int[] tempArr = new int[nums.Length];
            k = k % nums.Length;
            for (int i = 0; i < nums.Length; i++)
                tempArr[(i + k) % nums.Length] = nums[i];
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
