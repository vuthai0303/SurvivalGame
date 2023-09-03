using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.U2D.Animation;
using UnityEngine;

public static class SaveLoad
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.streamingAssetsPath + "/GameData" + "/Character.save";
        FileStream stream = new FileStream(path, FileMode.Create);

    }

    public static void LoadData() 
    {
        string path = Application.persistentDataPath + "/Game.weeklyhow";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //CharacterData data = formatter.Deserialize(stream) as CharacterData;

            stream.Close();

            //return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            //return null;
        }
    }
}
