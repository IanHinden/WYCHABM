using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private static string saveFilePath = Application.persistentDataPath + "/savefile.json";
    private static readonly byte[] encryptionKey = Encoding.UTF8.GetBytes("RinaSawayama,Hey");

    public static string Encrypt(string plainText)
    {
        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
        using (Aes aes = Aes.Create())
        {
            aes.Key = encryptionKey;
            aes.GenerateIV();
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                        return System.Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }
    }

    public static string Decrypt(string encryptedText)
    {
        byte[] cipherBytes = System.Convert.FromBase64String(encryptedText);
        using (Aes aes = Aes.Create())
        {
            aes.Key = encryptionKey;
            byte[] iv = new byte[aes.BlockSize / 8];
            System.Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
            using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
            {
                using (var ms = new MemoryStream())
                {
                    ms.Write(cipherBytes, iv.Length, cipherBytes.Length - iv.Length);
                    ms.Position = 0;
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] plainBytes = new byte[cipherBytes.Length - iv.Length];
                        cs.Read(plainBytes, 0, plainBytes.Length);
                        return Encoding.UTF8.GetString(plainBytes).TrimEnd('\0');
                    }
                }
            }
        }
    }

    public static void Save(BoolArrayWrapper data)
    {
        string json = JsonUtility.ToJson(data);
        string encryptedJson = Encrypt(json);
        File.WriteAllText(saveFilePath, encryptedJson);
    }

    public static BoolArrayWrapper Load(int arraySize)
    {
        BoolArrayWrapper data = new BoolArrayWrapper(arraySize);

        if (File.Exists(saveFilePath))
        {
            string encryptedJson = File.ReadAllText(saveFilePath);
            string json = Decrypt(encryptedJson);

            BoolArrayWrapper loadedData = JsonUtility.FromJson<BoolArrayWrapper>(json);

            if (loadedData.unlockedBonuses.Length == arraySize)
            {
                data.unlockedBonuses = loadedData.unlockedBonuses;
            } else
            {
                for (int i = 0; i < arraySize && i < loadedData.unlockedBonuses.Length; i++)
                {
                    data.unlockedBonuses[i] = loadedData.unlockedBonuses[i];
                }
            }
        }
        return data;
    }
}
