using System;

namespace FractionCollection
{
    public class Fraction
    {
        private int numerator { get; set; }
        private int denominator { get; set; }
        private int frontNum { get; set; }

        public Fraction(int numerator, int denominator) : this(numerator, denominator, 0) 
        {
            if (numerator != 0 && denominator != 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            else
            {
                this.numerator = 1;
                this.denominator = 1;
            }
        }

        public Fraction(int numerator, int denominator, int frontNum)
        {
            if (numerator != 0 && denominator != 0)
            {
                this.frontNum = frontNum;
                this.numerator = numerator;
                this.denominator = denominator;
            }
            else
            {
                this.frontNum = 0;
                this.numerator = 1;
                this.denominator = 1;
            }
        }

        ~Fraction()
        {
            Console.WriteLine("Fraction Deconstructed");
            this.frontNum = 0;
            this.numerator = 0;
            this.denominator = 0;
        }

        public void Reduce()
        {
            if (this.numerator > this.denominator) //Turns number into mixed number
            {
                this.frontNum = this.numerator / this.denominator; //Finds the Front Number
                this.numerator %= this.denominator; //Finds the Numerator

                if (this.numerator < 0 && this.frontNum < 0) //Checks if the numerator should be negative or not. If the front number is negative, then the numerator should
                {
                    this.numerator *= -1;
                }

                if (this.denominator < 0) //denominator should not be negative
                {
                    this.denominator *= -1;
                }
            }
            else if (FracMath.GCF(this.numerator,this.denominator) > 1) //Checks if the number can be simplifies (example: 2/4 to 1/2)
            {//Top and Bottom divided by the GCF gets the reduced fraction
                int gcf = FracMath.GCF(this.numerator, this.denominator);
                this.numerator /= gcf;
                this.denominator /= gcf;
            }
        }

        public Fraction getReciprocal()
        {//Returns a reverse of the fraction
            return new Fraction(this.denominator, this.numerator);
        }

        public static Fraction operator/(Fraction one, Fraction two)
        {
            try
            {
                int newDenominator = 1;
                int newNumerator = 1;
                Fraction reciprocal;
                Fraction newFrac;
                int GCFMath;

                reciprocal = two.getReciprocal(); //2nd number has to be reversed to do division properly

                newNumerator = one.numerator * reciprocal.numerator; //obtains the numerator
                newDenominator = one.denominator * reciprocal.denominator; //obtains the denominator

                GCFMath = FracMath.GCF(newNumerator, newDenominator); //gets the 

                newFrac = new Fraction(newNumerator / GCFMath, newDenominator / GCFMath);
                newFrac.Reduce();

                return newFrac;
            }
            catch (DivideByZeroException)
            {
                Console.Write("Error, Cannot divide by 0");
                return null;
            }
            
        }

        public static Fraction operator*(Fraction one, Fraction two)
        {
            int newDenominator = 1;
            int newNumerator = 1;

            newNumerator = one.numerator * two.numerator;
            newDenominator = one.denominator * two.denominator;

            Fraction newFrac = new Fraction(newNumerator, newDenominator);
            newFrac.Reduce();

            return newFrac;
        }

        public static Fraction operator-(Fraction one, Fraction two)
        {
            int newDenominator = 1;
            int newNumerator = 1;

            if (one.denominator == two.denominator)
            {
                newNumerator = one.numerator - two.numerator;
                newDenominator = one.denominator;
            }
            else
            {
                newDenominator = FracMath.LCM(one.denominator, two.denominator);
                newNumerator = (one.numerator * two.denominator) - (two.numerator * one.denominator);
            }

            Fraction newFrac = new Fraction(newNumerator, newDenominator);
            newFrac.Reduce();

            return newFrac;
        }

        public static Fraction operator+(Fraction one, Fraction two)    
        {
            int newDenominator = 1;
            int newNumerator = 1;

            if (one.denominator == two.denominator)
            {
                newNumerator = one.numerator + two.numerator;
                newDenominator = one.denominator;
            }
            else
            {
                newDenominator = FracMath.LCM(one.denominator, two.denominator);
                newNumerator = one.denominator + two.denominator;
            }

            Fraction newFrac = new Fraction(newNumerator, newDenominator);
            newFrac.Reduce();

            return newFrac;
        }

        public string returnFraction()
        {
            if (this.frontNum == 0)
            {
                return this.numerator + "/" + this.denominator;
            }
            else if (this.numerator == 0)
            {
                return this.frontNum.ToString();
            }
            else
            {
                return this.frontNum + " " + this.numerator + "/" + this.denominator;
            }
        }
    }
}
