using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{
    Transform player;
    GameManager manager;
    PlayerInfo playerSave = new PlayerInfo();
    public GameObject saveInformation;

    private string gameDataFileName;
    string saveInfo;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        manager = GetComponent<GameManager>();
        gameDataFileName = Application.dataPath + "/save.json";
        saveInfo = PlayerPrefs.GetString("Saves", saveInfo);
        CheckSave(saveInfo);
    }


    public void SaveGame()
    {
        playerSave.playerPosition = new Vector3(player.position.x, player.position.y, player.position.z);
        playerSave.hasTeleported = manager.teleported;
        playerSave.gotTeleportationStone = manager.hasTeleportationStone;
        playerSave.gotFirstCrystal = manager.FirstCrystal;
        playerSave.gotSecondCrystal = manager.SecondCrystal;
        playerSave.gotThirdCrystal = manager.ThirdCrystal;

        string json = JsonUtility.ToJson(playerSave);
        File.WriteAllText(gameDataFileName, json);
        StartCoroutine("ShowInfo", 1f);
    }

    public void LoadSave()
    {
        string json = File.ReadAllText(gameDataFileName);
        JsonUtility.FromJsonOverwrite(json, playerSave);
        player.transform.position = new Vector3(playerSave.playerPosition.x,playerSave.playerPosition.y,playerSave.playerPosition.z);
        manager.hasTeleportationStone = playerSave.gotTeleportationStone;
        manager.teleported = playerSave.hasTeleported;
        manager.FirstCrystal = playerSave.gotFirstCrystal;
        manager.SecondCrystal = playerSave.gotSecondCrystal;
        manager.ThirdCrystal = playerSave.gotThirdCrystal;
    }

    void CheckSave(string check)
    { 
       if (check == "1")
       {
            LoadSave();
            saveInfo = "0";
            PlayerPrefs.SetString("Saves", saveInfo);
        }
    }

    IEnumerator ShowInfo(float time)
    {
        saveInformation.SetActive(true);
        yield return new WaitForSeconds(time);
        saveInformation.SetActive(false);
    }
}

[System.Serializable]
public class PlayerInfo
{
    public Vector3 playerPosition;
    public bool hasTeleported;
    public bool gotTeleportationStone;
    public bool gotFirstCrystal;
    public bool gotSecondCrystal;
    public bool gotThirdCrystal;
}

