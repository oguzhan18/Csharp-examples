using System;

// Mehmet Taşköprü - mtaskopru@gmail.com

public class DrawProgressBarExample
{
	public static void Main()
	{
		DrawProgressBar(2,1,100,0,ConsoleColor.White);
		DrawProgressBar(2,5,50,1,ConsoleColor.Red);
		DrawProgressBar(2,10,40,2,ConsoleColor.Green);
		DrawProgressBar(2,15,100,3,ConsoleColor.Cyan);
		DrawProgressBar(2,20,65,4,ConsoleColor.Yellow);
		
		Console.Read();
	}
	
	public static void DrawProgressBar(int left, int top, int value, int symbolType, ConsoleColor color )
	{
		char[] symbol = new char[5]{'\u25A0','\u2592','\u2588','\u2551','\u2502'};

		int maxBarSize = Console.BufferWidth-1;
		int barSize = value; 
		decimal f = 1;
		
		if(barSize + left > maxBarSize)
		{
			barSize = maxBarSize - (left + 5); // first 5 character "%100 "
			f = (decimal)value / (decimal)barSize;
		}
		
		Console.CursorVisible = false;
		Console.ForegroundColor = color;
		
		Console.SetCursorPosition(left + 5, top);
		
		for(int i=0;i<barSize+1;i++)
		{
			System.Threading.Thread.Sleep(10);
			Console.Write(symbol[symbolType]); 
			Console.SetCursorPosition(left, top);
			Console.Write("%" + (i * f).ToString("0,0"));
			Console.SetCursorPosition(left+5+i, top);
		}
		
		Console.ResetColor();
	}
}