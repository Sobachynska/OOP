string input = "0101010101";
int startIndex = 3; // Початкова позиція для заміни символів
string output = "";
for (int i = 0; i < input.Length; i++)
{
    if (i < startIndex)
    {
        output += input[i];
    }
    else
    {
        if (input[i] == '0')
        {
            output += '1';
        }
        else if (input[i] == '1')
        {
            output += '0';
        }
    }
}
Console.WriteLine(output);