// List<int> numbers = new List<int>();
// for(int i = 0; i <= 99; i++)
// {
//     numbers.Add(i);
// }

// int ActiveNumber = numbers[50];

string filePath = "input.txt";

List<Combination> combinations = new List<Combination>();

try
{
    Console.WriteLine($"Reading file: {filePath}");
    int lineCount = 0;
    foreach (string line in File.ReadLines(filePath))
    {
        char direction = line[0];
        int count = int.Parse(line[1..]);
        combinations.Add(new Combination{direction = direction, count = count});
        lineCount++;
    }
}
catch(Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

int Position = 50;
int Zeroes = 0;
foreach(Combination rotation in combinations)
{
    int localRotation = rotation.count;
    int direction = 1;
    if(rotation.direction == 'L')
    {
        localRotation *= -1;
        direction = -1;
    }
    int start = Position;
    Position += localRotation;
    Position %= 100;
    if (Position < 0 ) Position += 100;
    int steps = Math.Abs(localRotation % 100);
    Zeroes += (int)(MathF.Abs(localRotation) / 100);
    if(MathF.Abs(localRotation) % 100 != 0)
    if(start == 0 && localRotation <= 99) continue;
    {
        if(direction == -1 && Position != 0)
        {
            int distToZeroLeft = start;
            if(steps > distToZeroLeft) Zeroes++;
        }
        else if(Position != 0 && direction == 1)
        {
            int distToZeroRight = (100 - start);
            if (steps > distToZeroRight) Zeroes++;
        }
    }
    if(Position == 0)
    {
        Zeroes++;
    }


    // Step 1
    // if(Position % 100 == 0)
    // {
    //     Zeroes++;
    // }

}

Console.WriteLine(Zeroes);
class Combination
{
    public char direction { get; set; }
    public int count { get; set;}
}