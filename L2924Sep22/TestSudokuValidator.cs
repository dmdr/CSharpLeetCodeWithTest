namespace LeetCodeSolve;
public class TestIsValidSudoku
{

  /*
      Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.

      Constraints:

      board.length == 9
      board[i].length == 9
      board[i][j] is a digit 1-9 or '.'.
  */
  public void RunTest()
  {
    // char[][] boardDataExam0 = [['5','3','.','.','7','.','.','.','.']
    //   ,['6','.','.','1','9','5','.','.','.']
    //   ,['.','9','8','.','.','.','.','6','.']
    //   ,['8','.','.','.','6','.','.','.','3']
    //   ,['4','.','.','8','.','3','.','.','1']
    //   ,['7','.','.','.','2','.','.','.','6']
    //   ,['.','6','.','.','.','.','2','8','.']
    //   ,['.','.','.','4','1','9','.','.','5']
    //   ,['.','.','.','.','8','.','.','7','9']];
    // Console.WriteLine($"Sudoku (Board 1) Valid: {IsValidSudoku(boardDataExam0)}");

    char[][] boardDataExam1 = [['5','3','.','.','7','.','.','.','.']
      ,['6','.','.','1','9','5','.','.','.']
      ,['.','9','8','.','.','.','.','6','.']
      ,['8','.','.','.','6','.','.','.','3']
      ,['4','.','.','8','.','3','.','.','1']
      ,['7','.','.','.','2','.','.','.','6']
      ,['.','6','.','.','.','.','2','8','.']
      ,['.','.','.','4','1','9','.','.','5']
      ,['.','.','.','.','8','.','.','7','9']];
    Console.WriteLine($"Sudoku (Board 1) Valid: {IsValidSudoku(boardDataExam1)}");

    char[][] boardDataExam2 = [['8','3','.','.','7','.','.','.','.']
      ,['6','.','.','1','9','5','.','.','.']
      ,['.','9','8','.','.','.','.','6','.']
      ,['8','.','.','.','6','.','.','.','3']
      ,['4','.','.','8','.','3','.','.','1']
      ,['7','.','.','.','2','.','.','.','6']
      ,['.','6','.','.','.','.','2','8','.']
      ,['.','.','.','4','1','9','.','.','5']
      ,['.','.','.','.','8','.','.','7','9']];
    Console.WriteLine($"Sudoku (Board 1) Valid: {IsValidSudoku(boardDataExam2)}");
  }

  public bool IsValidSudoku(char[][] board)
  {
    int nBoardLen = board.Length;
    var boardCol = new char[nBoardLen];
    for (var i = 0; i < nBoardLen; i++)
    {
      // Validate Row
      if (!Validate9x1Row(board[i]))
      {
        return false;
      }
      // Validate Column
      for (var j = 0; j < nBoardLen; j++)
      {
        boardCol[j] = board[j][i];
      }
      // Validate Column
      if (!Validate9x1Row(boardCol))
      {
        return false;
      }
    }
    for (var mr = 0; mr < nBoardLen; mr += 3)
    {
      for (var mc = 0; mc < nBoardLen; mc += 3)
      {
        for (var r = 0; r < 3; r++)
        {
          for (var c = 0; c < 3; c++)
          {
            //Console.WriteLine($"i={i}, j={j}, k={k}");
            boardCol[r * 3 + c] = board[mr + r][mc + c];
          }
        }
        if (!Validate9x1Row(boardCol))
        {
          return false;
        }
      }
    }

    return true;
  }

  public void ShowSudokuData(char[][] board)
  {
    bool bFirstRow = true;
    foreach (var boardRow in board)
    {
      bool bFirstCol = true;
      Console.Write((bFirstRow) ? "[" : ",[");
      foreach (var boardCol in boardRow)
      {
        Console.Write((bFirstCol) ? "" : ",");
        bFirstCol = false;
        Console.Write((boardCol == '.') ? "." : Convert.ToInt16(boardCol - '0'));
      }
      Console.WriteLine("]");
    }
    Console.WriteLine("]");
  }

  public void ShowSudokuDataRow(char[] boardRow)
  {
    foreach (var boardCol in boardRow)
    {
      Console.Write((boardCol == '.') ? "." : Convert.ToInt16(boardCol - '0'));
    }
  }

  private bool Validate9x1Row(char[] row)
  {
    HashSet<int> cellMap = new HashSet<int>();

    foreach (char rowChar in row)
    {
      if (rowChar != '.')
      {
        if (!cellMap.Add(Convert.ToInt16(rowChar - '0')))
        {
          return false;
        }
      }
    }

    return true;
  }


  // LeetCode - Fastest Solution
  public bool IsValidSudoku_Fast(char[][] board)
  {
    HashSet<string> seen = new HashSet<string>();

    for (int row = 0; row < 9; row++)
    {
      for (int col = 0; col < 9; col++)
      {
        char num = board[row][col];

        if (num != '.')
        {
          // Check row
          if (!seen.Add($"{num} in row {row}")) return false;
          // Check column
          if (!seen.Add($"{num} in col {col}")) return false;
          // Check sub-box
          int subBoxIndex = (row / 3) * 3 + (col / 3);
          if (!seen.Add($"{num} in box {subBoxIndex}")) return false;
        }
      }
    }

    return true;
  }

}


