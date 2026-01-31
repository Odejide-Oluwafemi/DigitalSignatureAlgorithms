using System.Numerics;

namespace Digital_Signatures;

public class Program
{
  public static void Main(String[] args)
  {
    // Samantha Info
    BigInteger largePrimeP = 1223;
    BigInteger largePrimeQ = 1987;
    BigInteger exponent = 948047;
    BigInteger document = 1070777;

    BigInteger publicMod = RSAKeyGen.GetPublicModulus(largePrimeP, largePrimeQ);
    BigInteger pSignKey = RSAKeyGen.ComputePrivateSigningKey(largePrimeP, largePrimeQ, exponent);
    BigInteger docSig = RSAKeyGen.GetDocumentSignature(document, publicMod, pSignKey);
    System.Console.WriteLine("Document:\t" + document);
    System.Console.WriteLine("Document Signature:\t" + docSig);
    System.Console.WriteLine("Verification Details:\n\tN: " + publicMod + "\n\te: " + exponent);

    BigInteger docToVerify = document;
    BigInteger docSigToVerify = docSig;
    BigInteger pubModVerify = publicMod;
    BigInteger expVerify = exponent;

    System.Console.WriteLine("Verify Document: " + docToVerify + "\nUsing:\n\tSignature: " + docSigToVerify + "\n\tN: " + pubModVerify + "\n\te: ", expVerify);
    System.Console.WriteLine(
      RSAKeyGen.VerifyDocument(docToVerify, docSig, pubModVerify, expVerify)
        ? "Document Verification Successful ✅" : "Failed to verify Document ❌"
    );
  }

}


