using System.Numerics;

public class RSAKeyGen
{
  private BigInteger p;
  private BigInteger q;
  public BigInteger e;
  public BigInteger N;
  private BigInteger d;

  public RSAKeyGen(BigInteger _p, BigInteger _q, BigInteger _e)
  {
    if (Operations.GCD(_e, ((_p - 1) * (_q - 1))) != 1) throw new Exception("Invalid Exponent: gcd(e, (p - 1)(q - 1)) != 1");

    p = _p;
    q = _q;
    e = _e;
    N = p * q;

    ComputePrivateSigningKey();
  }

  private void ComputePrivateSigningKey()
  {
    BigInteger mod = (p - 1) * (q - 1);
    d = Operations.ModInverse(e, mod);
    System.Console.WriteLine(d);
  }
}