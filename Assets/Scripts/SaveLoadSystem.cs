

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Find;
using UnityEngine;

public class SaveLoadSystem
{
    public static void SavePlayer(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.empcrft";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
     public static GameData LoadPlayer()
    {
        if (HasSaved())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/player.empcrft";
            FileStream stream = new FileStream(path, FileMode.Open);
            return formatter.Deserialize(stream) as GameData;
        }
        else
        {
          return  null;
        }
    }
    public static bool HasSaved()
    {
        string path = Application.persistentDataPath + "/player.empcrft";

        return File.Exists(path);
    }

}
