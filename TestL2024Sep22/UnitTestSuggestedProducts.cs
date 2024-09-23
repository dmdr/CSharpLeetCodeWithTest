using LeetCodeSolve;

namespace TestL2024Sep22;

[TestClass]
public class UnitTestSuggestedProducts
{
  [TestMethod]
  public void TestMethodSuggestedProductsCase1()
  {
    TestSuggestedProducts sp = new();

    string[] products = [
      "mobile","mouse","moneypot","monitor","mousepad"
      ];
    string searchWord = "mouse";

    var resp = sp.SuggestedProducts(products, searchWord);
    var resText = sp.GetResultText(ref resp);
    string sExpRep = "[[\"mobile\", \"moneypot\", \"monitor\"],[\"mobile\", \"moneypot\", \"monitor\"],[\"mouse\", \"mousepad\"],[\"mouse\", \"mousepad\"],[\"mouse\", \"mousepad\"]]";

    Assert.AreEqual(sExpRep, resText);
  }

  [TestMethod]
  public void TestMethodSuggestedProductsCase2()
  {
    string[] products = ["havana"];
    string searchWord = "havana";

    TestSuggestedProducts sp = new();
    var resp = sp.SuggestedProducts(products, searchWord);
    var resText = sp.GetResultText(ref resp);

    string sExpRep = "[[\"havana\"],[\"havana\"],[\"havana\"],[\"havana\"],[\"havana\"],[\"havana\"]]";

    Assert.AreEqual(sExpRep, resText);
  }

}

