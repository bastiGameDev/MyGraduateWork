using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveLoadData : MonoBehaviour
{
    //public List<GameObject> items; // список предметов, которые нужно сохранять
    private string filePath;
    
    public List<ItemPosition> itemPositions = new List<ItemPosition>();
    
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
        itemPositions.Clear();

        // Замените 'PickUp' на тег ваших объектов, которые нужно сохранять и загружать
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickUp"))
        {
            ItemPosition itemPosition = new ItemPosition();
            itemPosition.name = item.name;
            itemPosition.position = item.transform.position;
            itemPositions.Add(itemPosition);
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
            List<ItemPosition> loadedItemPositions = JsonConvert.DeserializeObject<List<ItemPosition>>(jsonData);

            // Замените 'PickUp' на тег ваших объектов, которые нужно сохранять и загружать
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("PickUp"))
            {
                foreach (ItemPosition itemPosition in loadedItemPositions)
                {
                    if (item.name == itemPosition.name)
                    {
                        item.transform.position = itemPosition.position;
                        break;
                    }
                }
            }
        }
    }



    }
