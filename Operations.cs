using System.Numerics;
public static class Operations
{
  public static BigInteger GCD(BigInteger a, BigInteger b)
  {
    if (b == 0) return a;
    else return GCD(b, Mod(a, b));
  }

  public static BigInteger Mod(BigInteger a, BigInteger m)
  {
    return a % m;
  }

  public static (BigInteger, BigInteger, BigInteger) ExtendedGCD(BigInteger a, BigInteger b)
    {
        if (b == 0)
            return (a, 1, 0);

        var (gcd, x1, y1) = ExtendedGCD(b, a % b);
        BigInteger x = y1;
        BigInteger y = x1 - (a / b) * y1;
        return (gcd, x, y);
    }

    public static BigInteger ModInverse(BigInteger a, BigInteger n)
    {
        var (gcd, x, _) = ExtendedGCD(a, n);
        if (gcd != 1)
            throw new Exception("Inverse does not exist");
        return (x % n + n) % n;
    }
}