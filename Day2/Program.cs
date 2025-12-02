// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

string filePath = "input.txt";

List<ulong> ids = new List<ulong>();
try
{
    using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                // Read the file line by line until the end
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line by the comma delimiter
                    string[] fields = line.Split(',');

                    // Process each field (e.g., print to console)
                    foreach (string field in fields)
                    {
                        ulong start = ulong.Parse(field.Split('-')[0]);
                        ulong end = ulong.Parse(field.Split('-')[1]);
                        ulong current = start;
                        while (current != end + 1)
                        {
                            ids.Add(current);
                            current++;
                        }
                    }
                }
            }
}
catch(Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

ulong total = 0;
foreach( ulong id in ids)
{
    string idString = id.ToString();
    int len = idString.Length;
    int midIndex = Math.Abs(len / 2);
    for(int i = 1; i <= midIndex; i++)
    {
        if (len % i != 0) continue;
        List<string> splitParts = new List<string>();
        int partLength = i;
        for (int j = 0; j < idString.Length; j += partLength)
        {
            int length = Math.Min(partLength, idString.Length - j);
            splitParts.Add(idString.Substring(j, length));
        }
        if(splitParts.Distinct().Count() == 1)
        {
            Console.WriteLine(id);
            total += (ulong)id;
            break;
        }
    }
    //Part 1
    // string subString1 = idString.Substring(0, midIndex);
    // string subString2 = idString.Substring(midIndex);
    // if(subString1 == subString2)
    // {
    //     Console.WriteLine(subString1 + " " + subString2);
    //     total += (ulong)id;
    // }
}

Console.WriteLine(total);