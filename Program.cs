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

    BigInteger publicMod = RSA_DSA.GetPublicModulus(largePrimeP, largePrimeQ);
    BigInteger pSignKey = RSA_DSA.ComputePrivateSigningKey(largePrimeP, largePrimeQ, exponent);
    BigInteger docSig = RSA_DSA.GetDocumentSignature(document, publicMod, pSignKey);
    System.Console.WriteLine("Document:\t" + document);
    System.Console.WriteLine("Document Signature:\t" + docSig + "\n");
    System.Console.WriteLine("Verification Details:\n\tN: " + publicMod + "\n\te: " + exponent);

    // Successful Verifcation by Victor
    System.Console.WriteLine("====================== Successful VERIFICATION by Victor ==========================");

    System.Console.WriteLine("Verify Document: " + document + "\nUsing:\n\tSignature: " + docSig + "\n\tN: " + publicMod + "\n\te: " + exponent);
    System.Console.WriteLine(
      RSA_DSA.VerifyDocument(document, docSig, publicMod, exponent)
        ? "Document Verification Successful ✅" : "Failed to verify Document ❌"
    );

    // Unsuccessful Verifcation by Eve
    System.Console.WriteLine("====================== Unsuccessful VERIFICATION by Eve ==========================");

    BigInteger docSigToVerify_x = docSig + 1;

    System.Console.WriteLine("Verify Document: " + document + "\nUsing:\n\tSignature: (" + docSigToVerify_x + ")\n\tN: " + publicMod + "\n\te: " + exponent);
    System.Console.WriteLine(
      RSA_DSA.VerifyDocument(document, docSigToVerify_x, publicMod, exponent) == true
        ? "Document Verification Successful ✅" : "Failed to verify Document ❌"
    );
  }

}


