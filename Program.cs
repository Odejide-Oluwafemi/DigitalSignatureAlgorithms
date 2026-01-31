using System.Numerics;

namespace Digital_Signatures;

public class Program
{
  public static void Main(String[] args)
  {
    RSA_Main();
    Elgamal_Main();
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

    BigInteger docSigToVerify_x = docSig + 1; // Test with Invalid Document Signature

    System.Console.WriteLine("Verify Document: " + document + "\nUsing:\n\tSignature: (" + docSigToVerify_x + ")\n\tN: " + publicMod + "\n\te: " + exponent);
    PrintVerificationMessage(RSA_DSA.VerifyDocument(document, docSigToVerify_x, publicMod, exponent));
  }

  private static void Elgamal_Main()
  {
    /*
      ===================================
          Elgamal DIGITAL SIGNATURE
      ===================================
    */

    System.Console.WriteLine("================================================================================================================");
    System.Console.WriteLine("\t\t\t\tElgamal DIGITAL SIGNATURE");
    System.Console.WriteLine("================================================================================================================");

    // Samantha Info
    BigInteger largePrime = 21739;
    BigInteger primitiveRoot = 7;
    BigInteger secretExponent = 15140;
    BigInteger document = 5331;
    BigInteger randomElement = 10727;

    BigInteger pVerKey = ElgamalDSA.GetPublicVerificationKey(primitiveRoot: primitiveRoot, secretExponent: secretExponent, prime: largePrime);
    (BigInteger S1, BigInteger S2) = ElgamalDSA.SignDocument(doc: document, prime: largePrime, primitiveRoot: primitiveRoot, secretExponent: secretExponent, randomElement: randomElement);


    // Successful Verifcation by Victor
    System.Console.WriteLine("====================== Successful VERIFICATION by Victor ==========================");

    System.Console.WriteLine("Verify Document: " + document + "\nUsing:\n\tA: " + pVerKey + "\n\tG: " + primitiveRoot + "\n\tk: " + randomElement + "\n\tS1: " + S1 + "\n\tS2: " + S2);
    PrintVerificationMessage(ElgamalDSA.VerifyDocument(
      doc: document,
      docSig: (S1, S2),
      prime: largePrime,
      pubKey_A: pVerKey,
      primitiveRoot_G: primitiveRoot
    ));

    // Unsuccessful Verifcation by Eve
    System.Console.WriteLine("====================== Unsuccessful VERIFICATION by Eve ==========================");

    (BigInteger fakeS1, BigInteger fakeS2) fakeDocSig = (S1, S2 + Operations.GenerateRandomBigInt(max: (long)randomElement)); // Test with Invalid Document Signature

    System.Console.WriteLine("Verify Document: " + document + "\nUsing:\n\tA: " + pVerKey + "\n\tG: " + primitiveRoot + "\n\tk: " + randomElement + "\n\tS1: " + S1 + "\n\tS2: " + S2);
    PrintVerificationMessage(ElgamalDSA.VerifyDocument(
      doc: document,
      docSig: fakeDocSig,
      prime: largePrime,
      pubKey_A: pVerKey,
      primitiveRoot_G: primitiveRoot
    ));


  }
  
}


