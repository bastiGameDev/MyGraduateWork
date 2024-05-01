using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveLoadData : MonoBehaviour
{
    public List<GameObject> items; // список предметов, которые нужно сохранять
    private string filePath;

    // класс для хранения данных о предмете
    [System.Serializable]
    public class ItemData
    {
        public string name;
        public Vector3 position;
        public Quaternion rotation;
    }
    
    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "itemPositions.json");
    }


    private void Start()
    {
        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    // метод для сохранения данных
    public void SaveData()
    {
        List<Vector3> itemPositions = new List<Vector3>();

        // Замените 'YourItemObject' на имя вашего объекта, который нужно сохранять и загружать
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickUp"))
        {
            itemPositions.Add(item.transform.position);
        }

        string jsonData = JsonConvert.SerializeObject(itemPositions);
        File.WriteAllText(filePath, jsonData);
    }

    public void DeleteSaveData()
    {
        Debug.Log("Detete data..");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }


    // метод для загрузки данных
    public void LoadData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            List<Vector3> loadedItemPositions = JsonConvert.DeserializeObject<List<Vector3>>(jsonData);

            // Замените 'YourItemObject' на имя вашего объекта, который нужно сохранять и загружать
            int i = 0;
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickUp"))
            {
                if (i < loadedItemPositions.Count)
                {
                    item.transform.position = loadedItemPositions[i];
                    i++;
                }
            }
        }
    }


    }
