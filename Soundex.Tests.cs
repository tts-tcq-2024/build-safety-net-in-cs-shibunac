using Xunit;

public class SoundexTests
{

  [Fact]
  public static void GenerateSoundex_ShouldReturnEmptyString_ForEmptyInput()
  {
    var newTest = new Test("Testing - Empty String", "", "");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnThreePaddedZeroes_ForSingleCharacter()
  {
    var newTest = new Test("Testing - Single Character", "A", "A000");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnMappedCode_ForShortConsonents_PadZeroIfLessThanFour()
  {
    var newTest = new Test("Testing - Short Consonents", "WWW", "W000");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnMappedCode_ForLongConsonents()
  {
    var newTest = new Test("Testing - long Consonents", "ABCDFGJKLMNPQRTSVWXYZ", "A123");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldIgnoreRepeatedConsonents()
  {
    var newTest = new Test("Testing - Repeating Consonents", "WWWS", "W600");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnMappedCode_ForShortVowels_PadZeroIfLessThanFour()
  {
    var newTest = new Test("Testing - Short Vowels", "HI", "H000");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnMappedCode_ForLongVowels()
  {
    var newTest = new Test("Testing - Long Vowels", "AEIOUAEIOU", "A330");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldIgnoreRepeatedVowels()
  {
    var newTest = new Test("Testing - Repeating Vowels", "AAAA", "A000");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnMappedCode_ForShortAlphabets_PadZeroIfLessThanFour()
  {
    var newTest = new Test("Testing - Short Alphabet Characters", "JAM", "J500");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }
  [Fact]
  public static void GenerateSoundex_ShouldReturnMappedCode_ForLongAlphabets()
  {
    var newTest = new Test("Testing - Long Alphabet Characters", "YOUTUBEFACEBOOKINSTAGRAM", "Y331");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }


  [Fact]
  public static void GenerateSoundex_ShouldReturnZeroesExceptFirst_ForNumbers()
  {
    var newTest = new Test("Testing - Numbers", "1234", "1000");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnZeroesExceptFirst_ForSpecialCharacters()
  {
    var newTest = new Test("Testing - Special Characters", "$#@&", "$000");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldReturnZeroesExceptAlphabetsFirstCharacter_ForMixedCharacters()
  {
    var newTest = new Test("Testing - Mixed Characters", "G@@g!le123", "G400");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }

  [Fact]
  public static void GenerateSoundex_ShouldIgnoreEmptyExceptAlphabetsFirstCharacter_ForMixedCharacters()
  {
    var newTest = new Test("Testing - Mixed Characters", "You Tube", "Y331");
    var result = Soundex.GenerateSoundex(Test.Name);
    Assert.Equal(result, Test.SoundexCode);
  }
}

internal class Test
{
  public static string TestCaseName;
  public static string Name;
  public static string SoundexCode;

  public Test(string testcaseName, string inputName, string soundexCode)
  {
    TestCaseName = testcaseName;
    Name = inputName;
    SoundexCode = soundexCode;
  }
}
