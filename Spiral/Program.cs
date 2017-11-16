using System;

namespace Spiral
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите любое число: ");
			int counter = Int32.Parse(Console.ReadLine());
			Spiral spiral;

			spiral = new Spiral(counter);
			spiral.getSpiral();

			Console.ReadKey();
		}
	}

	class Spiral
	{
		private string[,] spiral;
		private int UserNumber, x, y;
		private int SpiralSideLength = 1;
		private int Counter = 0;
		private int Step = 1;
		private int StepCounter = 1;
		private enum Direction 
		{
			Top,
			Right,
			Down,
			Left
		}

		public Spiral(int number)
		{
			UserNumber = number;
			int LocalCounter = 1;
			while (LocalCounter < UserNumber)
			{
				LocalCounter += SpiralSideLength * 4 + 4;
				SpiralSideLength += 2;
			}

			x = y = SpiralSideLength / 2;
			spiral = new string[SpiralSideLength, SpiralSideLength];

			createLine(Direction.Top);
		}

		private void MoveCursor(Direction d)
		{
			switch (d) 
			{
				case Direction.Top:
					y--;
					break;
				case Direction.Right:
					x++;
					break;
				case Direction.Down:
					y++;
					break;
				case Direction.Left:
					x--;
					break;
			}
		}

		private Direction NextDirection(Direction d)
		{
			switch (d)
			{
				case Direction.Top:
					return Direction.Right;
				case Direction.Right:
					return Direction.Down;
				case Direction.Down:
					return Direction.Left;
				case Direction.Left:
					return Direction.Top;
				default:
					return Direction.Top;
			}
		}

		private void createLine(Direction d)
		{
			for (int i = 0; i < Step; i++)
			{
				++Counter;
				string Prefix = "";
				if (Counter < 10)
				{
					Prefix = " ";
				}
				spiral[y, x] = Prefix + " " + Counter;
				MoveCursor(d);
				if (UserNumber == Counter) 
					return;
			}
			if (StepCounter % 2 == 0) Step++;
			StepCounter++;
			createLine(NextDirection(d));
		}

		public void getSpiral()
		{
			for (int i = 0; i < SpiralSideLength; i++)
			{
				for (int j = 0; j < SpiralSideLength; j++)
				{
					Console.Write(spiral[i, j]);
				}
				Console.WriteLine("\n");
			}
		}
	}
}
