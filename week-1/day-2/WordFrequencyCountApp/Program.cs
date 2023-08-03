namespace WordFrequencyCountApp
{
    class WordFrequencyCount
    {
        public static void Main()
        {
            Console.WriteLine("Write the paragraph you want the word frequency counts of.");
            string? paragraph = Console.ReadLine();

            if (paragraph != null)
            {
                Dictionary<string, int> wordFrequencyCounts = WordFrequencyCount.CountFrequency(paragraph);
                Console.WriteLine("Report:");
                foreach (KeyValuePair<string, int> wordFrequencyCount in wordFrequencyCounts)
                    Console.WriteLine($"| {wordFrequencyCount.Key}: {wordFrequencyCount.Value}");
            }
        }

        public static Dictionary<string, int> CountFrequency(string paragraph)
        {
            string[] words = paragraph.Split(' ', '?');
            Dictionary<string, int> wordFrequencyCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordFrequencyCounts.ContainsKey(word))
                    wordFrequencyCounts[word] += 1;
                else
                    wordFrequencyCounts[word] = 1;
            }

            return wordFrequencyCounts;
        }
    }
}
