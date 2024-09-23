using System.Globalization;

namespace LeetCodeSolve;
public class TestFindDifferenceInTwoArrays
{
  public void RunTest()
  {
    int[] nums1 = [1, 2, 3];
    int[] nums2 = [2, 4, 6];

    var resp = FindDifferenceInTwoArrays(nums1, nums2);
    string textRes = GenerateOutput(resp);
    Console.WriteLine($"Results (Case 1):\n{textRes}\n");

    resp = FindDifference_Fast(nums1, nums2);
    textRes = GenerateOutput(resp);
    Console.WriteLine($"Results (Case 1 Fast):\n{textRes}\n");


    nums1 = [1, 2, 3, 3];
    nums2 = [1, 1, 2, 2];
    resp = FindDifferenceInTwoArrays(nums1, nums2);
    textRes = GenerateOutput(resp);
    Console.WriteLine($"Results (Case 2):\n{textRes}\n");

    resp = FindDifference_Fast(nums1, nums2);
    textRes = GenerateOutput(resp);
    Console.WriteLine($"Results (Case 2 Fast):\n{textRes}\n");

  }

  public IList<IList<int>> FindDifferenceInTwoArrays(int[] nums1, int[] nums2)
  {
    var resp = new List<IList<int>>
    {
        nums1.Where(i => !nums2.Contains(i)).Distinct().ToArray(),
        nums2.Where(i => !nums1.Contains(i)).Distinct().ToArray()
    };

    return resp;
  }

  // Leetcode - Fast Version
  public IList<IList<int>> FindDifference_Fast(int[] nums1, int[] nums2)
  {
    HashSet<int> set1 = new(nums1), set2 = new(nums2);
    List<int> res1 = new(), res2 = new();

    foreach (int num in set1)
    {
      if (!set2.Contains(num))
      {
        res1.Add(num);
      }
    }
    foreach (int num in set2)
    {
      if (!set1.Contains(num))
      {
        res2.Add(num);
      }
    }
    return new List<IList<int>> { res1, res2 };
  }

  private string GenerateOutput(IList<IList<int>> data)
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
          res += ",";
        }
        bFirst = false;
        res += $"{item2}";
      }
      res += "]";
    }
    res += "]";

    return res;
  }
}
