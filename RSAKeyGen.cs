using System.Numerics;

public class RSAKeyGen
{
  /*
  private BigInteger p;
  private BigInteger q;
  public BigInteger e;
  public BigInteger N;
  private BigInteger d;
  private BigInteger D;
  private BigInteger S;

  public RSAKeyGen(BigInteger _p, BigInteger _q, BigInteger _e, BigInteger _D)
  {
    if (Operations.GCD(_e, ((_p - 1) * (_q - 1))) != 1) throw new Exception("Invalid Exponent: gcd(e, (p - 1)(q - 1)) != 1");
    p = _p;
    q = _q;
    N = p * q;

    if (!((1 <= _D) && _D < N)) throw new Exception("Invalid Digital document: does not satisfy 1 ≤ D < N");

    e = _e;
    D = _D;

    ComputePrivateSigningKey();
  } */

  public static BigInteger ComputePrivateSigningKey(BigInteger p, BigInteger q, BigInteger e)
  {
    BigInteger mod = (p - 1) * (q - 1);
    return Operations.ModInverse(e, mod);
  }

  public static BigInteger GetDocumentSignature(BigInteger doc, BigInteger pubMod, BigInteger psk)
  {
    if (!((1 <= doc) && doc < pubMod)) throw new Exception("Invalid Digital document: does not satisfy 1 ≤ D < N");

    return Operations.Mod(Operations.BigIntPow(doc, psk), pubMod);
  }

  public static bool VerifyDocument(BigInteger doc, BigInteger docSig, BigInteger N, BigInteger e)
  {
    return (
      Operations.Mod(Operations.BigIntPow(docSig, e), N) == doc
      );
  }

  public static BigInteger GetPublicModulus(BigInteger _p, BigInteger _q)
  {
    return _p * _q;
  }
}