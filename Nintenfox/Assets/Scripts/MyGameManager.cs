using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public Player player;
    string savePath;
    // Start is called before the first frame update
    void Awake()
    {
        savePath = Application.persistentDataPath + "/SaveData.json";
        player = new Player();

        if (File.Exists(savePath))
        {
            Debug.Log("Los datos de guardado se guardaran en: "+savePath);
            string contents = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(contents, player);
        } else
        {
            player.energia = 100;
            player.limpieza = 0;
            player.nMonedas = 0;
        }
    }

    public void SaveGame()
    {
        string playerToJson = JsonUtility.ToJson(player, true);
        File.WriteAllText(savePath, playerToJson);
    }
}

[System.Serializable]
public class Player
{
    public float nMonedas;
    public float limpieza;
    public float energia;

    public Player()
    {

    }
}