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

		// The code for calcuatoing the Hrange gets complex/hard to read, so I'm making my own function for it, so when I need to change it, I change it here.
		public static double TaxNum(int H, int L, double B ){
			double sum=Math.Round(B* (H-L));
			Console.WriteLine("At "+B+"% bracket, the amount due is  "+sum);
			return (sum);
		}
		// Given amount of taxable income, return the tax of it, from the highest bracket for a single person
		public static void FederalTax(int TaxableIncome, int Det=12200){
			int temp=TaxableIncome;
			TaxableIncome-=Det;

			//Console.Write(TaxableIncome+":\t");
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
			for(int i=1; i<Taxis.Length; i++){
				if(Taxis[i].LRange<TaxableIncome){
					Range++;
				}
			}
			Console.WriteLine(Range +"\t" + Taxis[Range].Bracket);

			double sum=0;
			for(int i=0; i<Range; i++){
				sum+=TaxNum(Taxis[i].HRange, Taxis[i].LRange, Taxis[i].Bracket);
			}
			sum+=TaxNum(TaxableIncome, Taxis[Range].LRange, Taxis[Range].Bracket);

			for(int i=Range; i<Taxis.Length; i++){

				Console.WriteLine("At "+Taxis[i].Bracket+"% bracket, the amount due is  "+0);
			}


			if ( sum<0)
				sum=0;

			Console.WriteLine("Your tax is " + sum +
					"$ with a gross income percentage of " + Math.Round(sum/temp,2)  
					+ "% adjected it's " + Math.Round(sum/TaxableIncome,2) + "%\n" +

					"At a dectuable rate of " + Det + "\n");



		}



		//User inputs income, and keeps adding to their income till entering 0
		//They will asked to either accept standard decuation, or manual detuection.
		//Get federal tax of the person at each bracket, and return total, as well as gross income/adjected growth income.
		static void Main(string[] args)
		{
			var temp = 33.0f;
			var weather = (temp >32)? "Rain" : "Snow";
			Console.WriteLine(weather);



		}
	}
}
