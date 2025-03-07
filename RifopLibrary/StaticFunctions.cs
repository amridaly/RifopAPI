using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RifopLibrary
{
    public static class StaticFunctions
    {
        public static bool IsValidNinu(this string ninu) =>
               !string.IsNullOrWhiteSpace(ninu) && ninu.Length == 10 && long.TryParse(ninu, out _);

        public static bool IsValidNif(this string nif) =>
                !string.IsNullOrWhiteSpace(nif) && nif.Length == 13;


        
    }
}
