using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private string lastSceneName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        /*if (PlayerPrefs.HasKey("lastScene"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
        }*/
    }

    private void OnApplicationQuit()
    {
        lastSceneName = SceneManager.GetActiveScene().name;
        
        PlayerPrefs.SetString("lastScene", lastSceneName);
    }
}
