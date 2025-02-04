using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Utill
    {
        public static string LetterSpacing(string text, int width)
        {
            int textWidth = 0;

            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))   //공백 체크
                    textWidth += 1;
                else if (c > 255)
                    textWidth += 2;  // 255 이상은 한글 -> 2칸
                else
                    textWidth += 1;  // 나머지 1칸
            }

            return text + new string(' ', Math.Max(0, width - textWidth));
        }
    }
}
