using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }


    //what we want to save
    public int highScore;

    private void Awake()
    {
        //if (!instance && instance != this)
        //Destroy(gameObject);
        //print("obj would be destroyed");
        //else
        //  instance = this;
        if (!instance)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = bf.Deserialize(file) as PlayerData_Storage;

            highScore = data.highScore;

            file.Close();

            print("file created");
        }
        else
        {
            highScore = 0;
            print("high score set to 0");
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();
        
        data.highScore = highScore;
        
        bf.Serialize(file, data);
        file.Close();
    }
}


[Serializable]
class PlayerData_Storage
{
    public int highScore;
}