using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Net;
using System.Net.NetworkInformation;

namespace POS
{
    public class pagoFonApi{
        // Key used to encrypt, it has to be this specific key.
    String Encryption_key = "lz3M0IH4swwYCR/vcOqXPg==";
    String Sign_Key = "lz3M0IH4swwYCR/vcOqXPg==";

    public static string GetMACAddress()
    {
        string macAddress =
            (
                from nic in NetworkInterface.GetAllNetworkInterfaces()
                where nic.OperationalStatus == OperationalStatus.Up
                select nic.GetPhysicalAddress().ToString()
            ).FirstOrDefault();

        char[] macAddressChars = macAddress.ToCharArray();

        for(int i = 0; i < macAddress.Length; i++)
        {
            if(macAddress[i] >= 65 && macAddress[i] <= 90)
            {
                macAddressChars[i] += (char)32;
            }
        }

        macAddress = new string(macAddressChars);

        for(int i = 2; i < macAddress.Length; i = i + 3)
        {
            macAddress = macAddress.Insert(i, ":");
        }
        Console.WriteLine(macAddress);
        return macAddress;
        //Format 50:8f:4c: 9f:39:65
    }

    public string GetBalance()
    {
        String Activation_Code = "1169325819";
        String RequestUniqueID = DateTime.Now.ToString("yyyyMMddHHmmssff");

        string hostName = Dns.GetHostName();
        string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString(); 

        String data = "{\"MethodName\":\"GetBalance\",\"ActivationCode\":\"" + Activation_Code + "\",\"RequestUniqueID\":\"" + RequestUniqueID + "\",\"RequestIP\":\"189.213.47.65\"}";

        return MessageServer(Activation_Code, data);
    }

    public string BillPay(string productCode, string billPayData, string amount, string loginPin, string email, string ani)
    {
        String Activation_Code = "1169325819";
        String RequestUniqueID = DateTime.Now.ToString("yyyyMMddHHmmssff");

        string hostName = Dns.GetHostName();
        // string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();

        String data = "{\"ActivationCode\":\"" + Activation_Code + "\",\"RequestUniqueID\":\"" + RequestUniqueID + 
            "\",\"ProductCode\":\"" + productCode + "\",\"BillPayData\":\"" + "{\\\"Field1\\\":\\\"9876543211\\\"}" + 
            "\",\"Amount\":\"" + amount + "\",\"MPin\":\"" + loginPin + 
            "\",\"Email\":\"" + email + "\",\"ANI\":\"" + ani + 
            "\",\"MethodName\":\"BillPay\",\"RequestIP\":\"" + "127.0.0.1" + "\"}";

        return MessageServer(Activation_Code, data);
    }

    public string MessageServer(string Activation_Code, string data)
    {
        pagoFonApi class1 = new pagoFonApi();

        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        String datos_post = Convert.ToBase64String(class1.encrypt(Encryption_key, Sign_Key, dataBytes));

        Console.WriteLine("Cadena cifrada: " + datos_post);
        Console.WriteLine();
        String data_response = "";

        try
        {
            Console.WriteLine("Inicia peticion API");

            data_response = send(Activation_Code, datos_post);   //URL CONNECT
            Console.WriteLine("Termina consumir API");
            Console.WriteLine();
            Console.WriteLine("Response API: " + data_response);
            Console.WriteLine();
            JObject jObject = JObject.Parse(data_response);

            // GET DATA of JSON
            String data_cipher = jObject["Data"].ToString();
            // Respuesta en claro a utilizar. 
            String response_clear =
            Encoding.UTF8.GetString((class1.decrypt(Encryption_key, Sign_Key, Convert.FromBase64String(data_cipher))));
            Console.WriteLine("Respuesta API descifrada: " + response_clear);

            return response_clear;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }

        Console.ReadLine();

        return "";
    }

    public string Base64Encode(string stringToEncode)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(stringToEncode);
        return Convert.ToBase64String(bytes);
    }

    public string Base64Decode(string base64String)
    {
        byte[] base64EncodedBytes = Convert.FromBase64String(base64String);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    public byte[] encrypt(String aesKey, String hmacKey, byte[] data)
    {
        byte[] encodeData = null;
        try
        {
            AesManaged aesCipher = new AesManaged();

            aesCipher.Mode = CipherMode.CBC;
            aesCipher.Padding = PaddingMode.PKCS7;
            aesCipher.Key = Convert.FromBase64String(aesKey);
            aesCipher.GenerateIV();
            ICryptoTransform encryptor = aesCipher.CreateEncryptor();

            byte[] encryptedMessage;

            encryptedMessage = encryptor.TransformFinalBlock(data, 0, data.Length);

            byte[] sign = Sign(hmacKey, encryptedMessage);

            if(sign == null)
            {
                return null;
            }

            encodeData = new byte[0];
            encodeData = encodeData.Concat(aesCipher.IV).ToArray();
            encodeData = encodeData.Concat(sign).ToArray();
            encodeData = encodeData.Concat(encryptedMessage).ToArray();

            return encodeData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return null;
        }
  
    }


    public byte[] Sign(String hmacKey, byte[] data)
    {
        HMACSHA1 hmac = new HMACSHA1(Convert.FromBase64String(hmacKey));
        hmac.Initialize();
        hmac.ComputeHash(data);

        return hmac.Hash;
    }

    public byte[] decrypt(String aesKey, String hmacKey, byte[] data)
    {
        Console.WriteLine("Inicia Desencriptación.");
        byte[] decryptByte = null;
        try
        {
            byte[] iv = data.Take(16).ToArray();
            byte[] sentSignature = data.Skip(16).Take(20).ToArray();
            byte[] encryptedMessage = data.Skip(36).ToArray();

            if(!verifySignature(hmacKey, sentSignature, encryptedMessage))
            {
                Console.WriteLine("Mala Firma.");
                return decryptByte;
            }

            AesManaged aesCipher = new AesManaged();
            aesCipher.Mode = CipherMode.CBC;
            aesCipher.Padding = PaddingMode.PKCS7;
            aesCipher.Key = Convert.FromBase64String(aesKey);
            aesCipher.IV = iv;
            ICryptoTransform decryptor = aesCipher.CreateDecryptor();

            byte[] decryptedMessage;

            decryptedMessage = decryptor.TransformFinalBlock(encryptedMessage, 0, encryptedMessage.Length);

            Console.WriteLine("Termina Desencriptación.");
            return decryptedMessage;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    private bool verifySignature(String hmacKey, byte[] sentSignature, byte[] data)
    {
        try
        {
            HMACSHA1 hmac = new HMACSHA1(Convert.FromBase64String(hmacKey));
            hmac.ComputeHash(data);

            return sentSignature.SequenceEqual(hmac.Hash);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            return false;
        }
        finally
        {
        }
    }


    private static RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();

        static pagoFonApi()
        {
            rngCSP = new RNGCryptoServiceProvider();
        }

        private void nextBytes(byte[] bytes)
        {
            rngCSP.GetBytes(bytes);
        }

    public static String send(String Activation_Code, String datos_post)
    {
        try
        {
            Uri url = new Uri("https://mw-uat.pagofon.net/securerest");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("ActivationCode", Activation_Code);
            parameters.Add("Data", datos_post);

            StringBuilder postData = new StringBuilder();

            foreach (KeyValuePair<string, object> entry in parameters)
            {
                if (postData.Length != 0)
                {
                    postData.Append('&');
                }
                postData.Append(HttpUtility.UrlEncode(entry.Key, new UTF8Encoding()));
                postData.Append('=');
                postData.Append(HttpUtility.UrlEncode(entry.Value.ToString(), new UTF8Encoding()));
            }

            byte[] postDataBytes = Encoding.UTF8.GetBytes(postData.ToString());
            Console.WriteLine("Peticion POST: " + postData.ToString());

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //SessionIDManager sidm = new SessionIDManager();
            //Console.WriteLine(sidm.CreateSessionID(HttpContext.Current));
            //Console.WriteLine(HttpContext.Current);

            /*
            if(HttpContext.Current == null)
            {
                Console.WriteLine("context");
            }
            */

            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            request.ContentLength = postDataBytes.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postDataBytes, 0, postDataBytes.Length);
            requestStream.Close();
            requestStream.Dispose();
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            
            StreamReader streamReader = new StreamReader(responseStream);
            string responseText = streamReader.ReadToEnd();
            responseStream.Dispose();
            
            return responseText;
        }
        catch (IOException e)
        {
            return e.ToString();
        }
    }
    
    
    }

}
