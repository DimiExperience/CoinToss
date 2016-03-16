using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinToss
{
    /// <summary>
    /// Homework: Do the experiment many times. The experiment consists of tossing a coin 100 times. Measure how many of those experiments yield 50 heads, 49 heads, 48 heads, 0 heads, etc... 
    /// Output a CSV file that Excel will be ready to turn into a spreadsheet.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var numOfHeads = 0;
            Console.WriteLine("How many 100 tosses?");
            var numOfTosses = Convert.ToInt32(Console.ReadLine());
            var dicVerovatnoca = new SortedDictionary<int, int>();
            for (var i = 0; i < numOfTosses; i++)
            {
                for (var x = 0; x < 100; x++)
                {
                    var number = random.Next(0, 2);
                    numOfHeads += number;
                }
                //dodati u dictionary
                if (dicVerovatnoca.ContainsKey(numOfHeads))//da li si na ovo mislio da mi treba TryGetValue, da bih lepse resio update? ako jesi nisam uspeo da nadjem kako
                {
                    dicVerovatnoca[numOfHeads] += 1;
                }
                else
                {
                    dicVerovatnoca.Add(numOfHeads, 1);
                }

                //clear numOfHeads za sledeci toss
                numOfHeads = 0;
            }
            foreach (var key in dicVerovatnoca.Keys)
            {
                Console.WriteLine("{0} : {1}", key, dicVerovatnoca[key]);//definitivno lepse resenje, nisam znao kako da ih ispisem, ali nije mi ovo palo na pamet, tako da cool!
            }



            string csv = string.Join(
                Environment.NewLine,
                dicVerovatnoca.Select(d => d.Key + ";" + d.Value + ";")
                );
            System.IO.File.WriteAllText(@"C:\Users\Dimi\Documents\myCSV.csv", csv);
        } //evo ga cointoss!:)
    }
}