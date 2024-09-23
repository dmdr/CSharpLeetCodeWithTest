// See https://aka.ms/new-console-template for more information
namespace LeetCodeSolve
{

  public class Solution
  {

    public static void Main(string[] args)
    {
      var vp = new TestVowelsProblem();
      vp.RunTest();

      var lo = new TestLongestOnes();
      lo.RunTest();

      var sp = new TestSuggestedProducts();
      sp.RunTest();

      var dfita = new TestFindDifferenceInTwoArrays();
      dfita.RunTest();

      TestIsValidSudoku vs = new();
      vs.RunTest();
    }

  }
}
