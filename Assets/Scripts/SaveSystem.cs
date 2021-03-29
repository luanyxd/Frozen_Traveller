using UnityEngine;
using System.IO; // assess system file
using System.Runtime.Serialization.Formatters.Binary; // access binary formatter

public static class SaveSystem
{
    public static void SavePlayer (playercontroller_2 player, int levelNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            FileStream previousStream = new FileStream(path, FileMode.Open);
            PlayerData previousData = formatter.Deserialize(previousStream) as PlayerData;
            previousStream.Close();
            if (previousData.level > levelNumber)
            {
                return;
            }
            File.Delete(path);
        }

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, levelNumber);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
