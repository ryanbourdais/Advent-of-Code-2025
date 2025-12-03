List<string> ratings = new List<string>();

string filePath = "input.txt";

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
						ratings.Add(field);
                    }
                }
            }
}
catch(Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

// Part 1
// int totalVoltage = 0;
// foreach(string rating in ratings) {
// 	int biggest = 0;
// 	int biggestIndex = 0;
// 	int secondBiggest = 0;
// 	for(int i = 0; i < rating.Length - 1; i++)
// 	{
// 		int currentDigit = rating[i] - '0';
// 		if(currentDigit > biggest)
// 		{
// 			biggest = currentDigit;
// 			biggestIndex = i;
// 		}
// 	}
// 	for(int j = biggestIndex + 1; j < rating.Length; j++)
// 	{
// 		int currentDigit = rating[j] - '0';
// 		if(secondBiggest == 9) break;
// 		if(currentDigit > secondBiggest)
// 		{
// 			secondBiggest = currentDigit;
// 		}
// 	}
// 	int maxVoltage = (biggest * 10) + secondBiggest;
// 	totalVoltage += maxVoltage;
// }
// Console.WriteLine(totalVoltage);

ulong maxVoltage = 0;
foreach(string rating in ratings)
{	
	List<int> voltage = new List<int>();
	int previousIndex = -1;
    for(int i = 11; i >= 0; i--)
    {
        int[] currentDigit = RecursiveCheck(rating, i + 1, previousIndex);
		previousIndex = currentDigit[1];
		voltage.Add(currentDigit[0]);
    }
	ulong voltageValue = ulong.Parse(string.Join(string.Empty, voltage));
	Console.WriteLine(voltageValue);
	maxVoltage += (ulong)voltageValue;
}
Console.WriteLine(maxVoltage);

int[] RecursiveCheck(string item, int remainingDigits, int currentIndex)
{
	int biggest = 0;
	int biggestIndex = currentIndex;
	for(int i = currentIndex + 1; i <= item.Length - remainingDigits; i++)
    {
		
        int currentDigit = item[i] - '0';
		if(currentDigit > biggest)
        {
            biggest = currentDigit;
			biggestIndex = i;
        }
    }
    return new int[] { biggest, biggestIndex };
}
