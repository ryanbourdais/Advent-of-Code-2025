List<string> Rows = new List<string>();


// Example input string with line breaks
string filePath = "input.txt";

try
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string? line;
        // Read the string line by line until the end
        while ((line = reader.ReadLine()) != null)
        {
            // Split the line by the comma delimiter
            string[] fields = line.Split(',');

            // Process each field (e.g., add to Rows)
            foreach (string field in fields)
            {
                Rows.Add(field);
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}


// Determine dimensions
int height = Rows.Count;
int width = Rows[0].Length;


char[,] grid = new char[height, width];

for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        grid[i, j] = Rows[i][j];
    }
}


int safeRolls = removeRolls(grid, 0);

int removeRolls(char[,]rolls, int count)
{
    bool removed = false;
    int newCount = count;
    int height = rolls.GetLength(0);
    int width = rolls.GetLength(1);
    for(int i = 0; i < height; i++)
    {
        for(int j = 0; j < width; j++)
        {
            if(rolls[i,j] != '@') continue;

            int unSafeSpots = 0;

            int[] rowOffsets = { -1, -1, -1,  0, 0,  1,  1, 1 };
            int[] columnOffsets = { -1,  0,  1, -1, 1, -1,  0, 1 };

            for (int k = 0; k < rowOffsets.Length; k++)
            {
                int rowOffset = i + rowOffsets[k];
                int columnOffset = j + columnOffsets[k];
                if (rowOffset >= 0 && rowOffset < height && columnOffset >= 0 && columnOffset < width)
                {
                    if (rolls[rowOffset,columnOffset] == '@')
                        unSafeSpots++;
                }
            }
            if(unSafeSpots < 4 )
            {
                newCount++;
                removed = true;
                rolls[i,j] = '.';
            }
        }
    }
    
// Example: print the grid
for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        Console.Write(grid[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine();

    if(removed) return removeRolls(rolls, newCount);
    return newCount;
}
Console.WriteLine(safeRolls);