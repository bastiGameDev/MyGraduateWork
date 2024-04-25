using UnityEngine;

public class ObjectPositionSaver : MonoBehaviour
{
    private string positionKey;

    private void Awake()
    {
        positionKey = "ObjectPosition_" + gameObject.GetInstanceID();
        LoadPosition();
    }

    private void OnApplicationQuit()
    {
        SavePosition();
    }

    private void SavePosition()
    {
        PlayerPrefs.SetFloat(positionKey + "_X", transform.position.x);
        PlayerPrefs.SetFloat(positionKey + "_Y", transform.position.y);
        PlayerPrefs.SetFloat(positionKey + "_Z", transform.position.z);
        PlayerPrefs.Save();
    }

    private void LoadPosition()
    {
        if (PlayerPrefs.HasKey(positionKey + "_X") &&
            PlayerPrefs.HasKey(positionKey + "_Y") &&
            PlayerPrefs.HasKey(positionKey + "_Z"))
        {
            float x = PlayerPrefs.GetFloat(positionKey + "_X");
            float y = PlayerPrefs.GetFloat(positionKey + "_Y");
            float z = PlayerPrefs.GetFloat(positionKey + "_Z");
            transform.position = new Vector3(x, y, z);
        }
    }
}