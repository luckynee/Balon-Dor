using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
   private string dataDirPath = "";
   private string dataFileName = "";
   private bool useEncryption = false;
   private readonly string ecryptionCodeWord = "Word";

   public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
   {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
   }


   public GameData Load()
   {
      string fullpath = Path.Combine(dataDirPath, dataFileName);
      GameData loadedData = null;
      if(File.Exists(fullpath))
      {
         try
         {
            string dataToLoad = "";
            using (FileStream stream = new FileStream(fullpath, FileMode.Open))
            {
               using (StreamReader reader = new StreamReader(stream))
               {
                  dataToLoad = reader.ReadToEnd();
               }
            }

            if(useEncryption)
            {
               dataToLoad = EncryptDecrypt(dataToLoad);
            }

            loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

         }
         catch (Exception e)
         {
            Debug.LogError("Error loading data from : " + fullpath + "\n " + e);
         }
      }
      return loadedData;
   }

   public void Save(GameData data)
   {
      string fullpath = Path.Combine(dataDirPath, dataFileName);
      try
      {
         Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

         string dataToStore = JsonUtility.ToJson(data, true);

         if(useEncryption)
         {
            dataToStore = EncryptDecrypt(dataToStore);
         }

         using (FileStream stream = new FileStream(fullpath, FileMode.Create))
         {
            using (StreamWriter writer = new StreamWriter(stream))
            {
               writer.Write(dataToStore);
            }
         }
      }
      catch(Exception e)
      {
         Debug.LogError("Error saving data to : " + fullpath + "\n " + e);
      }


   }
   private string EncryptDecrypt(string data)
   {
      string modifiedData = "";
      for (int i = 0; i < data.Length; i++)
      {
         modifiedData += (char) (data[i] ^ ecryptionCodeWord[i % ecryptionCodeWord.Length]);
      }
      return modifiedData;
   }
}
