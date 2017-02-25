using System;

class Program
{

	static List<int> bodek = new List<int>() ;

		const int bodekSzama = 10;



		static bool ellenorzes(int sor, int oszlop)
		{

			if (bodek.Contains(oszlop))
			{

				return false;
			}

			for (int i = 0; i < bodek.Count; i++)
			{
				
				if (Math.Abs(sor-(i + 1)) == Math.Abs(oszlop-bodek[i]))
					{
					return false;
				}
			}

			return true;
		}

		static bool elhelyezes(int sor)
									{

			if (sor > bodekSzama)
			{
	
				foreach (int hely in bodek)
				{
					
					Console.WriteLine(hely);
				}
				return true;
			}

			else {

				for (int i = 1; i <= bodekSzama; i++)
				{

					if (ellenorzes(sor, i))
					{

						bodek.Add(i);

						if (elhelyezes(sor + 1))
						{
							return true;
						}

						bodek.RemoveAt(bodek.Count - 1);

					}

				}

			}

			return false;
		}
	static void Main(string[] args)
	{
		Console.WriteLine("Hello World!");
	}
}
