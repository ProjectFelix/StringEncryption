using System;

namespace StringEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's encrypt and decrypt some strings!");
            Console.WriteLine("Enter a string to work with: ");
            string userString = Console.ReadLine();
            string cleanString = Encryption.CleanString(userString);

            Encryption.SetCypherKey();
            Encryption.SetCypherWord();

            Console.WriteLine($"\nString cleaned: {cleanString}");

            string singleyKeyEncrypted = Encryption.EncryptWithKey(cleanString);
            Console.WriteLine($"\nEncrypted with key: {singleyKeyEncrypted}");
            Console.WriteLine($"Decrypted: {Encryption.DecryptWithKey(singleyKeyEncrypted)}");

            string wordKeyEncrypted = Encryption.EncryptWithWord(cleanString);
            Console.WriteLine($"\nEncrypted with word: {wordKeyEncrypted}");
            Console.WriteLine($"Decrypted: {Encryption.DecryptWithWord(wordKeyEncrypted)}");

            string stringKeyEncrypted = Encryption.EncryptWithString(cleanString);
            Console.WriteLine($"\nEncrypted with word + string: {stringKeyEncrypted}");
            Console.WriteLine($"Decrypted: {Encryption.DecryptWithString(stringKeyEncrypted)}");

            Console.ReadLine();
        }
    }
}
