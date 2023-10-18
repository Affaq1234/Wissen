using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class general()
    {
        public bool is_same(string a, string b)
        {
            if (a == b)
            {
                return true;
            }
            return false;
        }
        public bool is_of_minimum_length(string a, int length)
        {
            if (a.Length >= length)
            {
                return true;
            }
            return false;
        }
        public bool IsInteger(string s)
        {
            if (s == "")
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int a = (int)s[i];
                if (a < 48 || a > 57)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsAlphabet(string s)
        {
            if (s == "")
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int a = (int)s[i];
                if (s[i]==' ')
                {
                    continue;
                }
                if (!((a >= 65 && a <= 90) || (a >= 97 && a <= 122)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
