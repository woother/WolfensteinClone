using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject fadeOut;

    public int loadScene;
    public int loadLives;
    public int loadScore;
    public int loadAmmo;

    public void NewGame()
    {
        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine()
    {
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("SceneToLoad",0);
        PlayerPrefs.SetInt("LivesSaved", 0);
        PlayerPrefs.SetInt("ScoreSaved", 0);
        PlayerPrefs.SetInt("AmmoSaved", 0);
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine()
    {
        loadScene = PlayerPrefs.GetInt("SceneToLoad");
        loadLives = PlayerPrefs.GetInt("LivesSaved");
        loadScore = PlayerPrefs.GetInt("LivesSaved");
        loadAmmo = PlayerPrefs.GetInt("AmmoSaved");
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        GlobalComplete.nextFloor = loadScene;
        GlobalLife.lifeValue = loadLives;
        GlobalScore.scoreValue = loadScore;
        GlobalAmmo.handgunAmmo = loadAmmo;
        SceneManager.LoadScene(loadScene);
    }

    public void CreditButton()
    {
        SceneManager.LoadScene(4);
    }
}
