using System;

// Mehmet Taşköprü - mtaskopru@gmail.com

public class DrawMenuExample
{
	public static string[] menuItems = new string[5]{"\t item 1 \t","\t item 2 \t","\t item 3 \t","\t item 4 \t","\t item 5 \t"};
	public static int menuCurrentItem = 0;
	
	public static void Main()
	{
			ConsoleKeyInfo cki;
			DrawMenu();
			cki = Console.ReadKey();
				
			while(cki.Key != ConsoleKey.Escape)
			{
				switch(cki.Key)
				{
					case ConsoleKey.UpArrow: 
						menuCurrentItem--;
						if(menuCurrentItem < 0) menuCurrentItem = menuItems.Length - 1;
						DrawMenu();
						break;
						
					case ConsoleKey.DownArrow: 
						menuCurrentItem++;
						if(menuCurrentItem > menuItems.Length - 1) menuCurrentItem = 0;
						DrawMenu();
						break;
						
					case ConsoleKey.Enter:
						MenuEnter();
						break;
				}

				cki = Console.ReadKey();
			}
	}

	public static void DrawMenu()
	{
		Console.Clear();
				
		for(int i=0; i<menuItems.Length;i++)
		{
			if(i != menuCurrentItem)
			{
				Console.WriteLine(menuItems[i]);
			}
			else if(i == menuCurrentItem)
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine('\u25BA' + menuItems[i]);	
				Console.ResetColor();
			}
		}
	}
	
	public static void MenuEnter()
	{
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("\n\nMenu Item " + (menuCurrentItem + 1).ToString() + " Selected");	
		Console.ResetColor();
	}
}