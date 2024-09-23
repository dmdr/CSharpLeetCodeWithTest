namespace LeetCodeSolve;
public class TestLongestOnes
{
  public void RunTest()
  {
    int res = 0;
    res = LongestOnes([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2);
    Console.WriteLine($"TestLongestOnes Case 1: {res}");

    res = LongestOnes([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3);
    Console.WriteLine($"TestLongestOnes Case 2: {res}");

    res = LongestOnes_Leetcode_Fast([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2);
    Console.WriteLine($"TestLongestOnes Case 1 (fast): {res}");

    res = LongestOnes_Leetcode_Fast([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3);
    Console.WriteLine($"TestLongestOnes Case 2 (fast): {res}");

  }

  public int LongestOnes(int[] nums, int k)
  {
    int nMaxCount = 0;

    int nStart = 0;
    while ((nums.Length - nStart) > nMaxCount)
    {
      int nCount = 0;
      int nflipped = 0;
      for (int idx = nStart; idx < nums.Length; idx++)
      {
        if (nums[idx] == 1)
        {
          nCount++;
        }
        else if (nflipped < k)
        {
          nflipped++;
          nCount++;
        }
        else
        {
          break;
        }
      }
      nMaxCount = Math.Max(nMaxCount, nCount);
      nStart++;
    }

    return nMaxCount;
  }

  // Faster
  public int LongestOnes_Leetcode_Fast(int[] nums, int k)
  {
    int len = nums.Length;
    int ans = 0;

    // optimized O(n)
    int nflipped = 0;
    int left = 0;
    for (int right = 0; right < len; right++)
    {
      if (nums[right] == 0) nflipped++;
      if (nflipped > k)
      {
        if (nums[left] == 0) nflipped--;
        left++;
      }
      // check the ans
      ans = Math.Max(ans, right - left + 1);
    }
    return ans;
  }
}
