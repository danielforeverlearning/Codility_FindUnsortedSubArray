using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility_FindUnsortedSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //********************************************************
            //PREREQUISITES
            //********************************************************
            //duplicate array values are allowed for example [1, 1, 1, 2, 3, 4]
            //Call the array AA
            //sorted means goes from smaller to larger numbers
            //input array is unsorted and each array value is 0 to MAX.INT
            //solution is to find the begin and end index of the middle subarray so that if you sort the middle subarray, the whole array is sorted

            //********************************************************
            //ALGORITHM
            //********************************************************
            //(1) Find candidate unsorted subarray
            //(1A)    search begin to end find first index where its out of sort, call it sb for searchbegin
            //(1B)    search end to begin find first index where its out of sort, call it se for searchend
            //(1C)    se may be bigger than sb so we may need to swap
            //(2) Find min and max values in subarray from index sb to se, callthem submin and submax
            //(3) Now we may need to make this subarray bigger
            //(3A) if between indexes 0  to sb          there is an index called sb2  bigger than submin   then sb = sb2  else sb unchanged
            //(3B) if between indexes se to AA.Length-1 there is an index called se2  smaller than submax  then se = se2  else se unchanged
            //(4) Answer is se and sb

            Console.WriteLine("Input unsorted array separated by commas:");
            string inputline = Console.ReadLine();
            string[] splitarray = inputline.Split(',');
            List<int> intlist = new List<int>();
            int ii;
            try
            {
                for (ii=0; ii < splitarray.Length; ii++)
                {
                    int value = int.Parse(splitarray[ii]);
                    if (value < 0)
                        throw new Exception("Values in array must be between 0 and MAX.INT");

                    intlist.Add(value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please enter a valid unsorted array of ints where values are 0 to MAX.INT");
                return;
            }

            //(1A)    search begin to end find first index where its out of sort, call it sb for searchbegin
            int oldvalue = int.MinValue;
            ii = 0;
            while (ii < intlist.Count)
            {
                if (intlist[ii] < oldvalue)
                    break;
                else
                {
                    oldvalue = intlist[ii];
                    ii++;
                }
            }

            if (ii == intlist.Count)
            {
                Console.WriteLine("The input array was already sorted correctly, please give me an unsorted array");
                return;
            }

            int sb = ii;

            //(1B)    search end to begin find first index where its out of sort, call it se for searchend
            oldvalue = int.MaxValue;
            ii = intlist.Count - 1;
            while (ii >= 0)
            {
                if (intlist[ii] > oldvalue)
                    break;
                else
                {
                    oldvalue = intlist[ii];
                    ii--;
                }
            }

            int se = ii;
            Console.WriteLine("BEFORE SWAP CHECK sb={0} se={1}", sb, se);
            //(1C)    se may be bigger than sb so we may need to swap
            if (se < sb)
            {
                oldvalue = se;
                se = sb;
                sb = oldvalue;
            }
            Console.WriteLine("AFTER SWAP CHECK sb={0} se={1}", sb, se);


            //(2) Find min and max values in subarray from index sb to se, callthem submin and submax
            int submin = int.MaxValue;
            int submax = int.MinValue;
            for (int xx=sb; xx <= se; xx++)
            {
                if (intlist[xx] < submin)
                    submin = intlist[xx];
                if (intlist[xx] > submax)
                    submax = intlist[xx];
            }
            Console.WriteLine("submin={0} submax={1}", submin, submax);
            
            //(3A) if between indexes 0  to sb          there is an index called sb2  bigger than submin   then sb = sb2  else sb unchanged
            ii = 0;
            while (ii <= sb)
            {
                if (intlist[ii] > submin)
                    break;
                else
                    ii++;
            }
            sb = ii;

            //(3B) if between indexes se to AA.Length-1 there is an index called se2  smaller than submax  then se = se2  else se unchanged
            ii = intlist.Count - 1;
            while (ii >= se)
            {
                if (intlist[ii] < submax)
                    break;
                else
                    ii--;
            }
            se = ii;

            
            Console.WriteLine("ANSWER sb={0} se={1}", sb, se);

        }
    }
}
