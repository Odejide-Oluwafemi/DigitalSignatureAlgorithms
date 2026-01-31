using System.Numerics;

namespace Digital_Signatures;

public class Program
{
  public static void Main(String[] args)
  {
    RSA_Main();
    // Elgamal_Main();
  }

  private static void PrintVerificationMessage(bool verified, string msg = "")
  {
    System.Console.WriteLine(
      verified == true
      ?
        (msg.Trim() == "" ? "Document Verification Successful ✅" : msg)
        :
        (msg.Trim() == "" ? "Failed to verify Document ❌" : msg)
    );
  }

  private static void RSA_Main()
  {
    /*
      ============================
          RSA DIGITAL SIGNATURE
      ============================
    */

    System.Console.WriteLine("================================================================================================================");
    System.Console.WriteLine("\t\t\t\tRSA DIGITAL SIGNATURE");
    System.Console.WriteLine("================================================================================================================");

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
    PrintVerificationMessage(RSA_DSA.VerifyDocument(document, docSig, publicMod, exponent));

    // Unsuccessful Verifcation by Eve
    System.Console.WriteLine("====================== Unsuccessful VERIFICATION by Eve ==========================");

    BigInteger docSigToVerify_x = docSig + 1;

    System.Console.WriteLine("Verify Document: " + document + "\nUsing:\n\tSignature: (" + docSigToVerify_x + ")\n\tN: " + publicMod + "\n\te: " + exponent);
    System.Console.WriteLine(
      RSA_DSA.VerifyDocument(document, docSigToVerify_x, publicMod, exponent) == true
        ? "Document Verification Successful ✅" : "Failed to verify Document ❌"
    );
  }

  private static void Elgamal_Main()
  {
    /*
      =================================
          Elgamal DIGITAL SIGNATURE
      =================================
    */

    // Samantha Info

  }

}


