using System;
using System.Collections.Generic;

public class Queen
{
  public int CoordX;
  public int CoordY;

  public Queen(int x, int y)
  {
    CoordX = x;
    CoordY = y;
  }
  public bool CanHitHorizontal(Queen q2) 
  {
    return q2.CoordX == CoordX;
  }
  
  public bool CanHitVertical(Queen q2)
  {
    return q2.CoordY == CoordY;
  }
  public bool CanHitDiagonal(Queen q2)
  {
    return (CoordX + CoordY == q2.CoordX + q2.CoordY) || (CoordX - CoordY == q2.CoordX - q2.CoordY);
  }
  public bool CanHit(Queen q2)
  {
    return CanHitDiagonal(q2) || CanHitHorizontal(q2) || CanHitVertical(q2);
  }
}

class Program
{
  static void Main()
  {
    Dictionary<char, int> xCoords = new Dictionary<char, int>() {{'A', 1}, {'B', 2}, {'C', 3}, {'D', 4}, {'E', 5}, {'F', 6}, {'G', 7}, {'H', 8}};
    Console.WriteLine("Enter your queens coordinates");
    string xy = Console.ReadLine();
    char[] q1Coords = xy.ToCharArray();
    int x = xCoords[Char.ToUpper(q1Coords[0])];
    int y = (int)Char.GetNumericValue(q1Coords[1]);

    Console.WriteLine("Enter their piece's coordinates");
    string xyPrime = Console.ReadLine();
    char[] q2Coords = xyPrime.ToCharArray();
    int xPrime = xCoords[Char.ToUpper(q2Coords[0])];
    int yPrime = (int)Char.GetNumericValue(q2Coords[1]);

      if(x > 8 || y > 8 || xPrime > 8 || yPrime > 8)
    {
      Console.WriteLine("Incorrect Coords Try Again");
      Main();
    }
    Queen q1 = new Queen(x, y);
    Queen q2 = new Queen(xPrime, yPrime);
    Console.WriteLine("Can hit " + q1.CanHit(q2));
  }
}