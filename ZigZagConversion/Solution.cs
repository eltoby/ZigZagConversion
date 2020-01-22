using System;
using System.Collections.Generic;
using System.Text;

namespace ZigZagConversion
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            var ls = new List<List<char>>();
            var pos = 0;
            var backing = true;
            var current = new List<char>();

            for (var i = 0; i < s.Length; i++)
            {
                if (pos == 0 || (numRows == 2 && pos % numRows == 0))
                {
                    current = new List<char>();
                    ls.Add(current);
                    current.Add(s[i]);
                    backing = false;
                    pos++;
                }
                else if (pos % numRows == 0)
                {
                    backing = true;
                    pos -= 2;
                    var value = s[i];
                    var zigZagList = GetZigZagList(numRows, pos, value);
                    ls.Add(zigZagList);
                    pos--;
                }
                else
                {
                    if (backing)
                    {
                        var value = s[i];
                        var zigZagList = GetZigZagList(numRows, pos, value);
                        ls.Add(zigZagList);
                        pos--;
                    }
                    else
                    {
                        current.Add(s[i]);
                        pos++;
                    }
                }
            }

            while (current.Count < numRows)
                current.Add('\0');

            var result = new StringBuilder();

            for (var i = 0; i < numRows; i++)
                foreach (var subList in ls)
                    if (subList[i] != '\0')
                        result.Append(subList[i]);

            return result.ToString();
        }

        private static List<char> GetZigZagList(int numRows, int pos, char value)
        {
            var zigZagList = new List<char>();
            for (var j = 0; j < numRows; j++)
            {
                if (pos == j)
                    zigZagList.Add(value);
                else
                    zigZagList.Add('\0');
            }

            return zigZagList;
        }
    }
}
