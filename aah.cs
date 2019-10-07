public class Aah{
public static void Main()
{
	string ability = Console.ReadLine();
	string requirement = Console.ReadLine();
	
	if (ability.Length >= requirement.Length)
	{
		Console.WriteLine("go");	
	}
	else 
	{
		Console.WriteLine("no");
	}
}
}