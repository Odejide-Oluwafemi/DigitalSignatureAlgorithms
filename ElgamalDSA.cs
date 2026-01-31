using System.Numerics;

static class ElgamalDSA
{
  public static BigInteger GetPublicVerificationKey(BigInteger primitiveRoot, BigInteger secretExponent, BigInteger prime)
  {
    BigInteger A = Operations.Mod(Operations.BigIntPow(primitiveRoot, secretExponent), prime);
    return A;
  }

  public static (BigInteger S1, BigInteger S2) SignDocument(BigInteger doc, BigInteger prime, BigInteger primitiveRoot, BigInteger secretExponent, BigInteger randomElement)
  {
    if (Operations.GCD(randomElement, prime - 1) != 1) throw new Exception("Random Element (k) does not satisfy: gcd(k, p - 1) = 1");

    BigInteger S1 = Operations.Mod(
      Operations.BigIntPow(primitiveRoot, randomElement),
      prime
    );

    BigInteger S2 = Operations.Mod(
      (doc - (secretExponent * S1)) * Operations.ModInverse(randomElement, prime - 1),
      prime - 1
    );
    if (S2 < 0) S2 += prime - 1;

    return (S1, S2);
  }

  public static bool VerifyDocument(BigInteger doc, (BigInteger S1, BigInteger S2) docSig, BigInteger prime, BigInteger pubKey_A, BigInteger primitiveRoot_G)
  {
    BigInteger a = Operations.Mod(Operations.BigIntPow(pubKey_A, docSig.S1) * Operations.BigIntPow(docSig.S1, docSig.S2), prime);
    BigInteger b = Operations.Mod(Operations.BigIntPow(primitiveRoot_G, doc), prime);
    return a == b;
  }
}