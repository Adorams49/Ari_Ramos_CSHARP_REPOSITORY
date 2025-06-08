using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("   XML Data Protection - Encrypt Credit Cards & Hash Passwords");
        Console.WriteLine(new string('-', 50));

        string filePath = "customers.xml";

        // Check if  XML file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("ERROR: XML file not found! Please ensure 'customers.xml' is in the project folder.");
            return;
        }

        Console.WriteLine("Loading XML file...");
        XDocument doc = XDocument.Load(filePath);

        // Process each customer
        foreach (var customer in doc.Descendants("customer"))
        {
            // Get original credit card and password
            string creditCard = customer.Element("creditcard").Value;
            string password = customer.Element("password").Value;

            // Encrypt credit card
            string encryptedCard = EncryptString(creditCard);
            customer.Element("creditcard").Value = encryptedCard;

            // Hash the password
            string hashedPassword = HashPassword(password);
            customer.Element("password").Value = hashedPassword;
        }

        // Save the modified XML to a new file
        string newFilePath = "customers_protected.xml";
        doc.Save(newFilePath);

        Console.WriteLine($"Protected XML file saved as: {newFilePath}");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Operation completed successfully!");
        Console.WriteLine(new string('-', 50));
    }

    // Method to encrypt a string using AES
    static string EncryptString(string plainText)
    {
        // Create AES encryption object
        using Aes aes = Aes.Create();

        // Key and IV must be 32 bytes and 16 bytes
        aes.Key = Encoding.UTF8.GetBytes("0123456789ABCDEF0123456789ABCDEF"); // 32 chars = 256 bits key
        aes.IV = Encoding.UTF8.GetBytes("ABCDEF9876543210"); // 16 chars = 128 bits IV

        using MemoryStream ms = new MemoryStream();
        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (StreamWriter sw = new StreamWriter(cs))
        {
            sw.Write(plainText);
            sw.Flush(); // Flush the StreamWriter buffer
            cs.FlushFinalBlock(); // Flush the CryptoStream final block
        }

        // Return encrypted data as Base64 string
        return Convert.ToBase64String(ms.ToArray());
    }

    // Method to hash a password with a randomly generated salt via SHA256
    static string HashPassword(string password)
    {
        // Generate a 16-byte (128-bit) salt
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Combine salt + password bytes
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

        Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
        Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);

        // Hash the salted password
        using SHA256 sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(saltedPassword);

        // Store salt and hash together as Base64 strings separated by ':'
        return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }
}