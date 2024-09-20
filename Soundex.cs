using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);
        AppendCodes(name, soundex, prevCode);
        AppendZeroes(soundex, 4);

        return soundex.ToString();
    }

    private static void AppendCodes(string name, StringBuilder soundex, char prevCode)
    {
        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            isValidToAppend(soundex, code, prevCode);
        }
    }

    private static void isValidToAppend(StringBuilder soundex, char code, char prevCode)
    {
        if (code != '0' && code != prevCode)
            {
                soundex.Append(code);
                prevCode = code;
            }
    }

    private static void AppendZeroes(StringBuilder soundex, int length)
    {
        while (soundex.Length < length)
        {
            soundex.Append('0');
        }
    }
    
    private static char GetSoundexCode(char alphabet)
    {
        // Define a lookup table string where each position represents a letter from 'A' to 'Z'
        const string alphabetLookup = "012301200224550012623010202";

        // Convert character to uppercase
        alphabet = char.ToUpper(alphabet);

        // Check if index is from 'A' to 'Z'
        if (alphabet >= 'A' && alphabet <= 'Z')
        {
            // Calculate the index (0 for 'A', 1 for'B'... 25 for 'Z')
            int alphabetIndex = alphabet - 'A';

            // return the Soundex code based on caculated index
            return alphabetLookup[alphabetIndex];
        }
        return '0'; // for characters outside alphabets
    }
}
