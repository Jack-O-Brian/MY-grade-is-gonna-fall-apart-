using System;

namespace Jan9th
{
	class Program
	{

		//This is the range of the income, and the bracket it is.
		public struct TaxBrack{
			public double Bracket;
			public int LRange;
			public int HRange;

			public TaxBrack(double A, int B, int C){
				Bracket=A;
				LRange=B;
				HRange=C;
			}
		}

		// Given amount of taxable income, return the tax of it, from the highest bracket for a single person
		public static void FederalTax(int TaxableIncome){

			Console.WriteLine(TaxableIncome);
			TaxBrack[] Taxis={
				new TaxBrack(.10,0,9700),		//0
				new TaxBrack(.12,9700,39475),		//1
				new TaxBrack(.22,39475,84200),		//2
				new TaxBrack(.24,84200,160725),		//3
				new TaxBrack(.32,160725,204100),	//4
				new TaxBrack(.35,204100,510300),	//5
				new TaxBrack(.37, 510300,-1) 		//6
			};
			int Range=0;
			for(int i=0; i<Taxis.Length; i++){
				if(Taxis[i].LRange<TaxableIncome)
					Range++;
			}
			Console.WriteLine(Range +"\t" + Taxis[Range].Bracket);

			double Sum=0;
			for(int i=0; i<Range-1; i++){
				Console.WriteLine(i + ":\t" + Taxis[i].Bracket*(
				Taxis[i].HRange - Taxis[i].LRange ) + "\t" + Taxis[i].LRange + "\t" + Taxis[i].HRange +"\t" + Taxis[i].Bracket);
				Sum+=(Taxis[i].Bracket*(Taxis[i].HRange - Taxis[i].LRange ));
			}

			Console.WriteLine(Range + ":\t" + Taxis[Range].Bracket*(
			TaxableIncome - Taxis[Range].LRange ) + "\t" + Taxis[Range].LRange + "\t" + TaxableIncome +"\t" + Taxis[Range].Bracket);
			Sum+=(Taxis[Range].Bracket*(TaxableIncome - Taxis[Range].LRange ));
			Console.WriteLine(Sum+"\n\n");
		}

		//User inputs income, and keeps adding to their income till entering 0
		//They will asked to either accept standard decuation, or manual detuection.
		//Get federal tax of the person at each bracket, and return total, as well as gross income/adjected growth income.
		static void Main(string[] args)
		{
			FederalTax(8000);
			FederalTax(16000);
			FederalTax(32000);
			FederalTax(64000);
			FederalTax(128000);
		}
	}
}
