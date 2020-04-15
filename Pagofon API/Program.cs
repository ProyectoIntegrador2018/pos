using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
//using Microsoft.AspNetCore.Http.Connections.Client;
using System.Net;

//import java.io.BufferedReader;
//import java.io.IOException;
//import java.io.InputStreamReader;
//import java.io.Reader;
//import java.net.HttpURLConnection;
//import java.net.URL;
//import java.net.URLEncoder;
//import java.security.Key;
//import java.security.NoSuchAlgorithmException;
//import java.security.SecureRandom;
//import java.util.Arrays;
//import java.util.LinkedHashMap;
//import java.util.Map;

//import javax.crypto.Cipher;
//import javax.crypto.Mac;
//import javax.crypto.SecretKey;
//import javax.crypto.spec.IvParameterSpec;
//import javax.crypto.spec.SecretKeySpec;

//import org.apache.commons.codec.binary.Base64;
//import com.google.gson.JsonElement;
//import com.google.gson.JsonObject;
//import com.google.gson.JsonParser;

public class pagofonAPI
{
    public static void /*m*/Main(String[] args)
    {
        String Activation_Code = "1169325819";
        String Encryption_key = "lz3M0IH4swwYCR/vcOqXPg==";
        String Sign_Key = "lz3M0IH4swwYCR/vcOqXPg==";
        String RequestUniqueID = "3456673745482112";

        String data = "{\"MethodName\":\"GetBalance\",\"ActivationCode\":\"" + Activation_Code + "\",\"RequestUniqueID\":\"" + RequestUniqueID + "\",\"RequestIP\":\"189.213.47.65\"}";

        Console.WriteLine("Cadena: " + data); //- System.out.println("Cadena: " + data)
        pagofonAPI class1 = new pagofonAPI();

        // test
        //string encoded = class1.Base64Encode("Hello World!");
        //string decoded = class1.Base64Decode("SGVsbG8gV29ybGQh");
        //byte[] encodedBytes = Convert.FromBase64String(encoded);
        //Console.WriteLine(encoded);
        //foreach (byte b in encodedBytes)
        //{
        //    Console.Write(b);
        //}
        //Console.WriteLine();
        //Console.WriteLine(Convert.ToBase64String(encodedBytes));

        //Console.WriteLine(class1.Base64Encode("Hello World!"));
        //Console.WriteLine(class1.Base64Decode("SGVsbG8gV29ybGQh"));
        // test

        //-
        // String datos_post = Base64.encodeBase64String(class1.encrypt(Encryption_key, Sign_Key, data.getBytes()));
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        String datos_post = Convert.ToBase64String(class1.encrypt(Encryption_key, Sign_Key, dataBytes));
        //-

        Console.WriteLine("Cadena cifrada: " + datos_post); //- System.out.println("Cadena cifrada: " + datos_post)
        
        String data_response = "";
        //- JsonParser parser = new JsonParser();
        // https://stackoverflow.com/questions/4575445/c-sharp-class-to-parse-json-result

        try
        {
            Console.WriteLine("Inicia peticion API"); //- System.out.println("Inicia peticion API")

            data_response = send(Activation_Code, datos_post);   //URL CONNECT
            Console.WriteLine("Termina consumir API"); //- System.out.println("Termina consumir API")
            Console.WriteLine("Response API: " + data_response); //- System.out.println("Response API: " + data_response)
            // PARSE JSON
            //-
            //- JsonElement jsonTree = parser.parse(data_response);
            //- JsonObject jsonObject = jsonTree.getAsJsonObject();
            JObject jObject = JObject.Parse(data_response);
            //-
            // GET DATA of JSON
            //- String data_cipher = jsonObject.get("Data").getAsString();
            String data_cipher = jObject["Data"].ToString();
            // Respuesta en claro a utilizar. 
            //- String response_clear = new String(class1.decrypt(Encryption_key, Sign_Key, Base64.decodeBase64(data_cipher.getBytes())));
            byte[] dataCipherBytes = Encoding.UTF8.GetBytes(data_cipher);
            // This line below might be wrong. It might just be the bytes directly into string?
            // check link for proper encoding
            // https://stackoverflow.com/questions/11743160/how-do-i-encode-and-decode-a-base64-string
            // alt Encoding.Default.GetString
            String response_clear =
                Convert.ToBase64String(class1.decrypt(Encryption_key, Sign_Key, Convert.FromBase64String(data_cipher)));
            //-
            Console.WriteLine("Respuesta API descifrada: " + response_clear); //- System.out.println("Respuesta API descifrada: " + response_clear)


        }
        catch (Exception e)
        {

            Console.WriteLine(e.StackTrace); //- e.printStackTrace();
        }

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
            //- 
            //Cipher AES_CIPHER = Cipher.getInstance("AES/CBC/PKCS5Padding");

            //SecretKey secretKey = (SecretKey)generateSecretKey(Base64.decodeBase64(aesKey));
            //if (secretKey == null)
            //{
            //    return null;
            //}
            //byte[] randomIv = new byte[16];
            //nextBytes(randomIv);

            //AES_CIPHER.init(Cipher.ENCRYPT_MODE, secretKey, new IvParameterSpec(randomIv));
            ///*- final */
            //const byte[] encryptedMessage = AES_CIPHER.doFinal(data);

            AesManaged aesCipher = new AesManaged();

            aesCipher.Mode = CipherMode.CBC;
            aesCipher.Padding = PaddingMode.PKCS7;
            // Random key is generated instead of using the one declared near the beginning of the class.
            // aesCipher.GenerateKey();
            aesCipher.Key = Encoding.UTF8.GetBytes(aesKey);
            aesCipher.GenerateIV();
            ICryptoTransform encryptor = aesCipher.CreateEncryptor();

            byte[] encryptedMessage;

            encryptedMessage = encryptor.TransformFinalBlock(data, 0, data.Length);

            aesCipher.Dispose();

            foreach(byte b in encryptedMessage)
            {
                Console.Write(b);
            }
            Console.WriteLine(Convert.ToBase64String(encryptedMessage));
            Console.WriteLine(Convert.ToBase64String(encryptedMessage).Length);
            Console.ReadLine();

            //- final byte[] Sign = Sign(hmacKey, encryptedMessage);
            byte[] sign = Sign(hmacKey, encryptedMessage);

            if (sign == null)
            {
                return null;
            }

            Console.WriteLine(Convert.ToBase64String(sign).Length);
            Console.ReadLine();

            //- encodeData = new byte[sign.length + encryptedMessage.length + randomIv.length];
            encodeData = new byte[0];
            //- System.arraycopy(randomIv, 0, encodeData, 0, randomIv.length);
            encodeData = encodeData.Concat(aesCipher.IV).ToArray();
            //- System.arraycopy(sign, 0, encodeData, randomIv.length, sign.length);
            encodeData = encodeData.Concat(sign).ToArray();
            //- System.arraycopy(encryptedMessage, 0, encodeData, randomIv.length + sign.length, encryptedMessage.length);
            encodeData = encodeData.Concat(encryptedMessage).ToArray();

            Console.WriteLine(Convert.ToBase64String(encodeData).Length);
            Console.ReadLine();

            return encodeData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace); //- e.printStackTrace();
            return null;
        }
    }

    //- AESManaged generates the key.
    //public Key generateSecretKey(byte[] keyBytes)
    //{
    //    SecretKey aesKey = null;
    //    try
    //    {
    //        aesKey = new SecretKeySpec(keyBytes, 0, keyBytes.length, "AES");
    //    }
    //    finally
    //    {
    //        return aesKey;
    //    }
    //}
    //-

    //- HMACSHA1 does it directly.
    //public SecretKeySpec HMACSHA1 generateHMAC(byte[] keyByte)
    //{
    //    if (keyByte == null)
    //    {
    //        return null;
    //    }
    //    SecretKeySpec signingKey = new SecretKeySpec(keyByte, "HMAC-SHA-1");

    //    return signingKey;
    //}
    //-

    public byte[] Sign(String hmacKey, byte[] data)
    {
        //-
        //byte[] signData = null;
        //try
        //{
        //    SecretKey signingKey = generateHMAC(Base64.decodeBase64(hmacKey));
        //    if (signingKey == null)
        //    {
        //        return null;
        //    }
        //    Mac senderMac = Mac.getInstance("HmacSHA1");
        //    senderMac.init(signingKey);
        //    signData = senderMac.doFinal(data);
        //    return signData;
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e.StackTrace); //- e.printStackTrace();
        //    return null;
        //}
        //finally
        //{

        //}

        // Converting to the string from the key to bytes might result in data loss of 2 bytes are needed
        // for the character. Consult ASCII table for reference.
        // posible base 64 decode error
        //* Call .Initialize()?
        HMACSHA1 hmac = new HMACSHA1(Encoding.ASCII.GetBytes(Base64Decode(hmacKey)));
        hmac.ComputeHash(data);
        return hmac.Hash;

        //-
    }

    public byte[] decrypt(String aesKey, String hmacKey, byte[] data)
    {
        byte[] decryptByte = null;
        try
        {
            //- byte[] iv = Arrays.copyOfRange(data, 0, 16);
            byte[] iv = data.Take(16).ToArray();
            //- byte[] sentSignature = Arrays.copyOfRange(data, 16, 16 + 20);
            byte[] sentSignature = data.Skip(16).Take(20).ToArray();
            //- byte[] encryptedMessage = Arrays.copyOfRange(data, 16 + 20, data.length);
            byte[] encryptedMessage = data.Skip(36).ToArray();

            if (!verifySignature(hmacKey, sentSignature, encryptedMessage))
            {
                return decryptByte;
            }

            //-
            //SecretKey secretKey = (SecretKey)generateSecretKey(Base64.decodeBase64(aesKey));
            //if (secretKey == null)
            //{
            //    return decryptByte;
            //}

            //Cipher AES_CIPHER = Cipher.getInstance("AES/CBC/PKCS5Padding");
            //AES_CIPHER.init(Cipher.DECRYPT_MODE, secretKey, new IvParameterSpec(iv));
            //decryptByte = AES_CIPHER.doFinal(encryptedMessage);
            //return decryptByte;

            AesManaged aesCipher = new AesManaged();
            aesCipher.Mode = CipherMode.CBC;
            aesCipher.Padding = PaddingMode.PKCS7;
            aesCipher.IV = iv;
            // Base 64 possible error and UTF8 or ASCII?
            aesCipher.Key = Encoding.ASCII.GetBytes(Base64Decode(aesKey));
            ICryptoTransform decryptor = aesCipher.CreateDecryptor();

            return decryptor.TransformFinalBlock(data, 0, data.Length);
            //-
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace); //- e.printStackTrace();
            return null;
        }
    }

    private bool/*ean*/ verifySignature(String hmacKey, byte[] sentSignature, byte[] data)
    {
        try
        {
            //-
            //SecretKey signingKey = generateHMAC(Base64.decodeBase64(hmacKey));
            //if (signingKey == null)
            //{
            //    return false;
            //}
            //Mac senderMac = Mac.getInstance("HmacSHA1");
            //senderMac.init(signingKey);
            //return Arrays.equals(sentSignature, senderMac.doFinal(data));

            // Converting to the string from the key to bytes might result in data loss of 2 bytes are needed
            // for the character. Consult ASCII table for reference.
            // posible base 64 decode error
            //* Call .Initialize()?

            HMACSHA1 hmac = new HMACSHA1(Encoding.ASCII.GetBytes(Base64Decode(hmacKey)));
            hmac.ComputeHash(data);
            return sentSignature == hmac.Hash;
            //-
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace); //- e.printStackTrace();
            return false;
        }
        finally
        {
        }
    }

    //-
    // private static SecureRandom secureRandom = null;
    // static {
    //    try {
    //    	secureRandom = SecureRandom.getInstance("SHA1PRNG");
    //    } catch (NoSuchAlgorithmException e) {
    //    } 
    //}
    // not sure if "SHA1PRNG"
    private static RNGCryptoServiceProvider rngCSP = new RNGCryptoServiceProvider();

    static pagofonAPI()
    {
        rngCSP = new RNGCryptoServiceProvider();
    }
    //-


    private void nextBytes(byte[] bytes)
    {
        //-secureRandom.nextBytes(bytes);
        rngCSP.GetBytes(bytes);
    }


    public static String send(String Activation_Code, String datos_post) //- throws IOException
    {
        //+ Placed the code inside the try.
        try //+
        {
            //- URL url = new URL("https://mw-uat.pagofon.net/securerest");
            //* Url url = new Url("https://mw-uat.pagofon.net/securerest");
            Uri url = new Uri("https://mw-uat.pagofon.net/securerest");
            //- Map < String, Object > params = new LinkedHashMap<>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            //- params.put("ActivationCode", Activation_Code);
            parameters.Add("ActivationCode", Activation_Code);
            //- params.put("Data", datos_post);
            parameters.Add("Data", datos_post);

            StringBuilder postData = new StringBuilder();

            //-
            //for (Map.Entry<String, Object> param : params.entrySet()) {
            //    if (postData.length() != 0)
            //        postData.append('&');
            //    postData.append(URLEncoder.encode(param.getKey(), "UTF-8"));
            //    postData.append('=');
            //    postData.append(URLEncoder.encode(String.valueOf(param.getValue()),
            //            "UTF-8"));
            //}

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
            //-

            //- byte[] postDataBytes = postData.toString().getBytes("UTF-8");
            byte[] postDataBytes = Encoding.UTF8.GetBytes(postData.ToString());
            //- System.out.println("Peticion POST: " + new String(postData.toString()));
            Console.WriteLine("Peticion POST: " + postData.ToString());

            //-
            //HttpURLConnection conn = (HttpURLConnection)url.openConnection();
            //conn.setRequestMethod("POST");
            //conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
            //conn.setRequestProperty("Content-Length", String.valueOf(postDataBytes.length));
            //conn.setDoOutput(true);
            //conn.getOutputStream().write(postDataBytes);
            //String response = "";
            //Reader in = new BufferedReader(new InputStreamReader(
            //        conn.getInputStream(), "UTF-8"));

            //for (int c = in.read(); c != -1; c = in.read()){
            //    //System.out.print((char) c);
            //    response = response + (char)c;
            //}
            //return response;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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
            //-
        }
        catch (IOException e) //+
        {
            return e.ToString();
        }
    }
}

