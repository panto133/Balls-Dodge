using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingSystem
{
    public static void SavePlayer(GameLogic gameLogic, Ball ball, Customize customize, Spawning spawning)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerSaveData.colex";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSaveData data = new PlayerSaveData(gameLogic, ball, customize, spawning);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerSaveData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/playerSaveData.colex";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSaveData data = formatter.Deserialize(stream) as PlayerSaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
