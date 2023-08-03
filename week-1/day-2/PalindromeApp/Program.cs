namespace PalindromeApp;

class Palindrome
{
    public static void Main(string[] args)
    {
        string userWord;
        int i, left, right;
        bool isPalindrome;
        
        if (args.Length == 0)
        {
            while (true)
            {
                Console.WriteLine("\nEnter the word you want to check for if it is a palindrome. (Enter 0 to exit): ");
                userWord = Console.ReadLine();

                if (userWord == null)
                    break;

                if (userWord == "0")
                    break;

                left = 0;
                right = userWord.Length - 1;
                isPalindrome = true;
                while (left < right)
                {
                    if (userWord[left] != userWord[right])
                    {
                        isPalindrome = false;
                        break;
                    }

                    left += 1;
                    right -= 1;
                }

                if (!isPalindrome)
                    Console.WriteLine($"The word \"{userWord}\" is not a palindrome.");
                else
                    Console.WriteLine($"The word \"{userWord}\" is, in fact, a palindrome.");
            }
        }
        else
        {
            Console.WriteLine($"You have listed your words. We will check them one by one");
            Console.WriteLine("Report:");
            for (i = 0; i < args.Length; i++)
            {
                userWord = args[i];
                left = 0;
                right = userWord.Length - 1; 
                isPalindrome = true;
                while (left < right)
                {
                    if (userWord[left] != userWord[right])
                    {
                        isPalindrome = false;
                        break;
                    }
                    left += 1;
                    right -= 1;
                }
                if (!isPalindrome)
                    Console.WriteLine($"\t=> The word \"{userWord}\" is not a palindrome.");
                else 
                    Console.WriteLine($"\t=> The word \"{userWord}\" is, in fact, a palindrome.");
            }
        }
    }
}
