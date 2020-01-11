using System;

namespace Jan9th
{
	class Program
	{

		//This is the range of the income, and the bracket it is.
		public struct TaxBrack{
			public int Bracket;
			public int LRange;
			public int HRange;

			public TaxBrack(int A, int B, int C){
				Bracket=A;
				LRange=B;
				HRange=C;
			}
		}

		// Given amount of taxable income, return the tax of it, from the highest bracket for a single person
		public static void FederalTax(int TaxableIncome){

			TaxBrack[] Taxis={
				new TaxBrack(10,0,9700),
				new TaxBrack(12,9700,39475),
				new TaxBrack(22,39475,84200),
				new TaxBrack(24,84200,160725),
				new TaxBrack(32,160725,204100),
				new TaxBrack(35,204100,510300),
				new TaxBrack(37, 510300,-1)
			};
			int Range=0;
			for(int i=0; i<Taxis.Length; i++){
				Console.WriteLine(Taxis[i].Bracket);
			}


		}

		//User inputs income, and keeps adding to their income till entering 0
		//They will asked to either accept standard decuation, or manual detuection.
		//Get federal tax of the person at each bracket, and return total, as well as gross income/adjected growth income.
		static void Main(string[] args)
		{
			FederalTax(3999);
		}
	}
}
