using System;
using System.Text;

namespace euler_from26
{
    public static class Poker
    {
        public static char[] SuitChar = { 'S', 'C', 'D', 'H' };
        public static int[] SuitValue = { 1, 2, 4, 8 };
        public static char[] FaceChar = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};
        public static int[] FacePrimeValue = { 2, 3, 5,   7,   11,  13,  17,  19,  23,  29,  31,  37,  41 }; // <= 63 = 2 ^ 8

        public static int Card(string S)
        {
            // 8C
            int fpv = FacePrimeValue[Array.IndexOf(FaceChar, S[0])];
            int sv = SuitValue[Array.IndexOf(SuitChar, S[1])] << 8;
            return sv | fpv;
        }

        public static int suit(int card) => card >> 8;
        public static int face(int card) => card & 63;
        public static string CardString(int card)
        {
            StringBuilder SB = new();
            int s = suit(card);
            int f = face(card);
            SB.Append(FaceChar[Array.IndexOf(FacePrimeValue, f)]);
            SB.Append(SuitChar[Array.IndexOf(SuitValue, s)]);
            return SB.ToString();
        }

        public static bool isFlush(int[] hand) => (hand[0] & hand[1] & hand[2] & hand[3] & hand[4] & 63) > 0;
    }
}