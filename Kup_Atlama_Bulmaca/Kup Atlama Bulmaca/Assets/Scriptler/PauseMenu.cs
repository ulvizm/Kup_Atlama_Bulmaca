using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private int currentSeviye;

    public GameObject yanmaMenuUI;
    public GameObject pauseMenuUI;
    public GameObject SolUst;

    private void Start()
    {
        currentSeviye = SceneManager.GetActiveScene().buildIndex;
        pauseMenuUI.SetActive(false);
    }
    public void YandiktanSonraDevam()
    {
        yanmaMenuUI.SetActive(false);
    }
    public void Resume()
    {
        SolUst.SetActive(true);
        pauseMenuUI.SetActive(false);
        yanmaMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BastanBasla()
    {
        SceneManager.LoadScene(currentSeviye);
    }
    public void Pause()
    {
        SolUst.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
