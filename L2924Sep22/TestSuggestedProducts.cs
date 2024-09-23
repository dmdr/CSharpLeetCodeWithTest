namespace LeetCodeSolve;
public class TestSuggestedProducts
{
  public void RunTest()
  {
    // Case 1
    string[] products = [
      "mobile","mouse","moneypot","monitor","mousepad"
      ];
    string searchWord = "mouse";
    var resp = SuggestedProducts(products, searchWord);
    var resText = GetResultText(ref resp);
    Console.WriteLine($"Result (Case 1):\n{resText}\n");

    // Case 2
    products = ["havana"];
    searchWord = "havana";
    resp = SuggestedProducts(products, searchWord);
    resText = GetResultText(ref resp);
    Console.WriteLine($"Result (Case 2):\n{resText}\n");
  }

  /*
    1268. Search Suggestions System
    Medium
    Topics
    Companies
    Hint
    You are given an array of strings products and a string searchWord.

    Design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.

    Return a list of lists of the suggested products after each character of searchWord is typed.

    Example 1:
      Input: products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = "mouse"
      Output: [["mobile","moneypot","monitor"],["mobile","moneypot","monitor"],["mouse","mousepad"],["mouse","mousepad"],["mouse","mousepad"]]
      Explanation: products sorted lexicographically = ["mobile","moneypot","monitor","mouse","mousepad"].
      After typing m and mo all products match and we show user ["mobile","moneypot","monitor"].
      After typing mou, mous and mouse the system suggests ["mouse","mousepad"].

    Example 2:
      Input: products = ["havana"], searchWord = "havana"
      Output: [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]]
      Explanation: The only word "havana" will be always suggested while typing the search word.

  */

  //
  public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
  {
    var resp = new List<IList<string>>();

    List<string> data = new List<string>();
    int nLen = searchWord.Length;
    string searchText = "";
    for (int i = 0; i < nLen; i++)
    {
      searchText += searchWord[i];
      var thisData = products.Where(x => x.Length >= (i + 1) && x.Substring(0, i + 1) == searchText).OrderBy(x => x).Take(3).ToList();
      resp.Add(thisData);
    }

    return resp;
  }

  public string GetResultText(ref IList<IList<string>> data)
  {
    string res = "[";
    bool bFirstRow = true;
    foreach (var item in data)
    {
      if (bFirstRow)
      {
        res += "[";
      }
      else
      {
        res += ",[";
      }
      bFirstRow = false;
      bool bFirst = true;
      foreach (var item2 in item)
      {
        if (!bFirst)
        {
          res += ", ";
        }
        bFirst = false;
        res += $"\"{item2}\"";
      }
      res += "]";
    }
    res += "]";

    return res;
  }
}
