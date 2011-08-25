using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGenerate;

namespace GDNET.Extensions.QuickGenerate
{
    public class WordGenerator : Generator<string>
    {
        private string[] words = null;
        private int minValue;
        private int maxValue;

        /// <summary>
        /// Create new Word generator
        /// </summary>
        /// <param name="minValue">Minimine number of words will be generated</param>
        /// <param name="maxValue">Maximine number of words will be generated</param>
        /// <param name="availableWords">All available words</param>
        public WordGenerator(int minValue, int maxValue, string availableWords)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.words = availableWords.Split(" ".ToCharArray());
        }

        public override string GetRandomValue()
        {
            int nbOfWords = new Random().Next(minValue, maxValue);
            int count = 0;
            int lastIndex = -1;
            StringBuilder sb = new StringBuilder();

            do
            {
                int wordIndex = 0;
                do
                {
                    wordIndex = new Random().Next(0, this.words.Length);
                }
                while (lastIndex == wordIndex);
                lastIndex = wordIndex;

                sb.AppendFormat("{0} ", this.words[wordIndex]);
                count += 1;
            }
            while (count < nbOfWords);

            return sb.ToString().Substring(0, sb.Length - 1);
        }
    }
}
