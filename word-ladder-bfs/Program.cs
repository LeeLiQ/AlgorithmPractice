using System;
using System.Collections.Generic;
using System.Linq;

namespace word_ladder_bfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordList = new List<string>
            {
                "hot",
                "dot",
                "dog",
                "lot",
                "log",
                "cog"
            };
            var result = LadderLength("hit", "cog", wordList);
            System.Console.WriteLine(result);

            // var wordList2 = new List<string>
            // {
            //     "lest","leet","lose","code","lode","robe","lost"
            // };

            // var result2 = LadderLength("leet", "code", wordList2);
            // System.Console.WriteLine(result2);
        }

        private static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var count = 1;

            var qu = new Queue<string>();
            var map = new HashSet<string>(wordList);
            if (map.Contains(beginWord))
                map.Remove(beginWord);
            qu.Enqueue(beginWord);

            while (qu.Count != 0)
            {
                var levelSize = qu.Count;
                var list = new List<string>();

                for (var i = 0; i < levelSize; i++)
                {
                    var node = qu.Dequeue();
                    var chars = node.ToCharArray();

                    for (var j = 0; j < chars.Length; j++)
                    {
                        var old = chars[j];
                        for (var ch = 'a'; ch <= 'z'; ch++)
                        {
                            if (old != ch)
                            {
                                chars[j] = ch;
                                var newWord = new string(chars);
                                if (map.Contains(newWord))
                                {
                                    if (newWord.Equals(endWord))
                                        return count + 1;
                                    list.Add(newWord);
                                    map.Remove(newWord);
                                }
                            }
                        }
                        chars[j] = old;
                    }
                }
                if (list.Count == 0)
                    return 0;

                foreach (var item in list)
                    qu.Enqueue(item);

                count++;
            }

            return count;
        }
    }
}
