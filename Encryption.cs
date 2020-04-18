using System;
using System.Collections.Generic;
using System.Text;

namespace StringEncryption
{
    public static class Encryption
    {
        public static char SingleKeyChar { get; set; } = 'a';
        public static int SingleKeyValue { get; set; } = 1;

        public static string WordKey { get; set; } = "CAT";

        public static string CleanString(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c >= 97 && c <= 122) output += c.ToString().ToUpper();
                else if (c >= 65 && c <= 90) output += c;
            }
            return output;
        }

        public static int GetKeyValue(char c)
        {
            if (c >= 97 && c <= 122) return c - 96;
            if (c >= 65 && c <= 90) return c - 64;
            return 0;
        }

        public static void SetCypherKey()
        {
            while (true) { 
                Console.WriteLine("Enter a character to use as a cypher key:");
                char userInput = Console.ReadLine()[0];
                int value = GetKeyValue(userInput);
                if (value > 0)
                {
                    SingleKeyChar = userInput;
                    SingleKeyValue = value;
                    Console.WriteLine($"Single key set to: {Encryption.SingleKeyChar} Value: {Encryption.SingleKeyValue}");
                    return;
                }
                Console.WriteLine("Not a valid entry!");
            }
        }

        public static void SetCypherWord()
        {
            Console.WriteLine("Enter a word to use as a cipher:");
            string word = CleanString(Console.ReadLine());
            WordKey = word;
            Console.WriteLine($"New word cipher set to \"{WordKey}\"");

        }

        public static string EncryptWithKey(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                int value = c + SingleKeyValue;
                if (value >= 91) value -= 26;
                output += (char)value;
            }
            return output;
        }

        public static string DecryptWithKey(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                int value = c - SingleKeyValue;
                if (value < 65) value += 26;
                output += (char)value;
            }
            return output;
        }

        public static string EncryptWithWord(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i] + GetKeyValue(WordKey[i%WordKey.Length]);
                if (value >= 91) value -= 26;
                output += (char)value;
            }
            return output;
        }

        public static string DecryptWithWord(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i] - GetKeyValue(WordKey[i % WordKey.Length]);
                if (value < 65) value += 26;
                output += (char)value;
            }
            return output;
        }

        public static string EncryptWithString(string input)
        {
            string newKey = WordKey + input;
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i] + GetKeyValue(newKey[i]);
                if (value >= 91) value -= 26;
                output += (char)value;
            }
            return output;
        }

        public static string DecryptWithString(string input)
        {
            string newKey = WordKey;
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                int value = input[i] - GetKeyValue(newKey[i]);
                if (value < 65) value += 26;
                char n = (char)value;
                newKey += n;
                output += n;
            }
            return output;
        }
    }
}
