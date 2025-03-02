using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotecaMiranda
{
    public static class InputValidator
    {
        public static bool IsNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        public static bool IsText(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
    }
}