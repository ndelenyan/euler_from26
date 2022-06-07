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
        public static Fraction operator +(long start, Fraction f) => new Fraction() {nominator = f.nominator + start * f.denominator, denominator = f.denominator};
        public static Fraction operator +(Fraction f, Fraction g) => new Fraction() {nominator = f.nominator * g.denominator + g.nominator * f.denominator, denominator = f.denominator * g.denominator};
        public static bool operator == (Fraction f, long i) => f.nominator / f.denominator == i && f.nominator % f.denominator == 0;
        public static bool operator != (Fraction f, long i) => f.nominator / f.denominator != i || f.nominator % f.denominator != 0;

        public Fraction inverse() => new Fraction(){nominator = this.denominator, denominator = this.nominator};

        public override string ToString() => nominator.ToString() + "/" + denominator.ToString();
    }
}