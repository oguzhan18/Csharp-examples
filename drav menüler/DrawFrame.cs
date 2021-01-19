using System;

// Mehmet Taşköprü - mtaskopru@gmail.com

public class DrawFrameExample
{
	public enum FrameBorder {NoBorder,SingleLine,DoubleLine}
	
	public static void Main()
	{
		DrawFrame(5,1,55,5,ConsoleColor.Blue,ConsoleColor.White,FrameBorder.DoubleLine);
		DrawFrame(5,8,55,12,ConsoleColor.Blue,ConsoleColor.White,FrameBorder.SingleLine);
		DrawFrame(5,15,55,19,ConsoleColor.Blue,ConsoleColor.White,FrameBorder.NoBorder);
				
		Console.Read();
	}

	public static void DrawFrame(int x1, int y1, int x2, int y2, ConsoleColor bColor, ConsoleColor fColor,FrameBorder frameBorder)
	{
		char[] symbol = null;
		char[] noBorder = new char[6]{' ',' ',' ',' ',' ',' '};
		char[] doubleLine = new char[6]{'\u2554','\u2550','\u2557','\u255A','\u255D','\u2551'};
		char[] singleLine = new char[6]{'\u250C','\u2500','\u2510','\u2514','\u2518','\u2502'};
		
		if(frameBorder == FrameBorder.NoBorder) 
			symbol = noBorder;
		else if(frameBorder == FrameBorder.SingleLine) 
			symbol = singleLine;
		else if(frameBorder == FrameBorder.DoubleLine) 
			symbol = doubleLine;
		
		Console.BackgroundColor = bColor;
		Console.ForegroundColor = fColor;
		
		string[] lines = new String[3]{"","",""};
		lines[0] = symbol[0] + lines[0].PadRight(x2-x1,symbol[1]) + symbol[2];
		lines[1] = symbol[3] + lines[1].PadRight(x2-x1,symbol[1]) + symbol[4];
		lines[2] = lines[2].PadRight(x2-x1,' ');

		Console.SetCursorPosition(x1,y1);
		Console.Write(lines[0]);
		Console.SetCursorPosition(x1,y2);
		Console.Write(lines[1]);
		
		for(int i=y1+1; i<(y2-y1)+y1; i++)
		{
			Console.SetCursorPosition(x1,i);
			Console.Write(symbol[5] + lines[2] + symbol[5]);
		}
	}
}