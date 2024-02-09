using static doginals.Program;

namespace doginals
{
    internal partial class Program
    {
        static void Main(string[] args)
        {


            var doginal = new Doginal();
            var result = doginal.GetItems(1).Result;
            var fullResults = new List<DoginalResultData>();
            var totalPage = result.totalPages;
           // totalPage = 2;
            for (int i = 1; i <= totalPage; i++)
            {
                Console.WriteLine($"Getting {i}. page...");
                result = doginal.GetItems(i).Result;
                fullResults.AddRange(result.data);

                Thread.Sleep(100);
            }
            var nonMinted = fullResults.Where(c => c.minted < c.supply && c.holders > 9).OrderByDescending(c => c.holders).ToList();
            var outputFile = @"c:\temp\doginal.txt";
            var holderHeader = "";
            for (int i = 0; i < 10; i++)
            {
                holderHeader += $"\tHolder {(i+1).ToString()}";
            }
            holderHeader = $"Tick\tHolders\tLimitPerMint\tTotalSupply\tMinted{holderHeader}\r\n";
            File.WriteAllText(outputFile, holderHeader);
            Console.WriteLine(holderHeader);
            foreach (var item in nonMinted)
            {
                var output = $"{item.tick}\t{item.holders}\t{item.limitPerMint}\t{item.supply}\t{item.minted}";

                var holderpercs = "";
                try
                {
                    var holderInfo = doginal.GetHolderInfo(item.tick).Result;
                    foreach (var holder in holderInfo)
                    {
                        holderpercs += $"\t{holder.percentage}";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"error happened for ticker {item.tick}");
                }
                output += holderpercs;
                Console.WriteLine(output);
                File.AppendAllText(outputFile, output + "\r\n");
                Thread.Sleep(100);
            }


            Console.WriteLine("finished...");

        }

    }
}