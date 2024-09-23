using LeetCodeSolve;

namespace TestL2024Sep22;

[TestClass]
public class UnitTestLongestOnes
{
    [TestMethod]
    public void TestMethodLongestOnes1()
    {
        TestLongestOnes lo = new();
        int res = lo.LongestOnes([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2);
        Assert.AreEqual(res, 6);
    }

    [TestMethod]
    public void TestMethodLongestOnes2()
    {
        TestLongestOnes lo = new();
        int res = lo.LongestOnes([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3);
        Assert.AreEqual(res, 10);
    }

    [TestMethod]
    public void TestMethodLongestOnes1and2Fast()
    {
        TestLongestOnes lo = new();
        int res = lo.LongestOnes_Leetcode_Fast([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2);
        Assert.AreEqual(res, 6);

        res = lo.LongestOnes_Leetcode_Fast([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3);
        Assert.AreEqual(res, 10);

    }

}