namespace euler_from26
{
    public struct Fraction
    {
        public long nominator, denominator;

        public Fraction()
        {
            nominator = 1;
            denominator = 1;
        }
        public Fraction(long n, long d)
        {
            nominator = n;
            denominator = d;
        }

        public static Fraction operator +(long start, Fraction f) => new Fraction(f.nominator + start * f.denominator, f.denominator);
        public static Fraction operator +(Fraction f, Fraction g) => new Fraction(f.nominator * g.denominator + g.nominator * f.denominator, f.denominator * g.denominator);
        public static bool operator == (Fraction f, long i) => (f.nominator / f.denominator == i) && (f.nominator % f.denominator == 0);
        public static bool operator != (Fraction f, long i) => (f.nominator / f.denominator != i) || (f.nominator % f.denominator != 0);

        public static bool operator > (Fraction f, Fraction g) => f.nominator * g.denominator > g.nominator * f.denominator;
        public static bool operator < (Fraction f, Fraction g) => f.nominator * g.denominator < g.nominator * f.denominator;

        public Fraction inverse() => new Fraction(){nominator = this.denominator, denominator = this.nominator};

        public override string ToString() => nominator.ToString() + "/" + denominator.ToString();
    }
}