using LeetCodeSolve;

namespace TestL2024Sep22;

[TestClass]
public class UnitTestSudokuValid
{

  [TestMethod]
  public void TestMethodIsValidSudoku()
  {
    var isv = new TestIsValidSudoku();

    char[][] boardDataExam0 = [['5','3','.','.','7','.','.','.','.']
            ,['6','.','.','1','9','5','.','.','.']
            ,['.','9','8','.','.','.','.','6','.']
            ,['8','.','.','.','6','.','.','.','3']
            ,['4','.','.','8','.','3','.','.','1']
            ,['7','.','.','.','2','.','.','.','6']
            ,['.','6','.','.','.','.','2','8','.']
            ,['.','.','.','4','1','9','.','.','5']
            ,['.','.','.','.','8','.','.','7','9']];

    var res = isv.IsValidSudoku(boardDataExam0);
    Assert.IsTrue(res);
  }

}