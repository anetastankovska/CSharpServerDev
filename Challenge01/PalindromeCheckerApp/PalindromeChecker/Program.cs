using System.Diagnostics;
using System.Text;

namespace PalindromeChecker
{
    public class Program
    {
        static string[] test1 = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
        static string[] test2 = new string[] { "bat", "tab", "cat" };
        static string[] test3 = new string[] { "a", "" };

        public static bool isPalindrome(string word1, string word2)
        {
            string result = word1 += word2;
            for (int i = 0; i < result.Length / 2; i++)
            {
                if (result[i] != result[result.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isPalindrome2(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    return false;
                }
            }
            GC.Collect();
            GC.WaitForFullGCComplete();
            return true;
        }

        public static int[][] CheckStrings(string[]strArr)
        {
            var output = new List<int[]>();
            for (int i = 0; i < strArr.Length; i++)
            {
                for (int j = 0; j < strArr.Length; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }
                    if(isPalindrome(strArr[i], strArr[j]))
                    {
                        output.Add(new int[2] {i, j});
                    }
                }
            }
            return output.ToArray();
        }

        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();

            //sw.Start();
            //for (int i = 0; i < 10; i++)
            //{
            //    var result1 = (CheckStrings(test1));
            //    var result2 = (CheckStrings(test2));
            //    var result3 = (CheckStrings(test3));
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedTicks);

            var result1 = (CheckStrings(test1));
            var result2 = (CheckStrings(test2));
            var result3 = (CheckStrings(test3));

            Console.WriteLine("Test input: { 'abcd', 'dcba', 'lls', 's', 'sssll' } \nTest output:");
            foreach (var item in result1)
            {
                Console.WriteLine($"[{string.Join(',', item)}]");
            }

            Console.WriteLine("Test input:{ 'bat', 'tab', 'cat' } \nTest output:");
            foreach (var item in result2)
            {
                Console.WriteLine($"[{string.Join(',', item)}]");
            }

            Console.WriteLine("Test input: { 'a', '' } \nTest output:");
            foreach (var item in result3)
            {
                Console.WriteLine($"[{string.Join(',', item)}]");
            }

        }

    }
}