using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedChecker : MonoBehaviour
{
    [SerializeField] private FadeOutScreen fadeOutScreen;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartEndingScene());
    }

    private IEnumerator StartEndingScene()
    {
        //проиграть звук как ложится спатть чел
        fadeOutScreen.StartFadeOut();
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Scene_2");
    }
}
