using System;
using System.Security.Cryptography;

namespace Engine {
    public static class RandomNumberGenerator {
        private static readonly RNGCryptoServiceProvider Generator = new RNGCryptoServiceProvider();

        public static int NumberBetween(int minVal, int maxVal) {
            byte[] randomNumber = new byte[1];
            Generator.GetBytes(randomNumber);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = maxVal - minVal + 1;
            double randomValueInRange = Math.Floor(multiplier * range);
            return (int)(minVal + randomValueInRange);
        }
    }
}