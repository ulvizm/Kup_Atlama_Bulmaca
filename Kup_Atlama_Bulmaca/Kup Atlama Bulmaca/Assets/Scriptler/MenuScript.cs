using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour

{
    public AudioMixer mixer;
    //
    [Header("UIPages")]
    [SerializeField] GameObject Ayarlar;
    [SerializeField] GameObject anaMenu;
    [SerializeField] GameObject Seviyeler;
    [SerializeField] GameObject Seviyeler2;
    [SerializeField] GameObject Seviyeler3;
    void Start() 
    {
        anaMenu.SetActive(true);
        Ayarlar.SetActive(false);
        Seviyeler.SetActive(false);
        Seviyeler2.SetActive(false);
        Seviyeler3.SetActive(false);
    }

    void Update()
    {

    }

    public void SesDuzeyi(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) * 20);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ayar2Menu()
    {
        Ayarlar.SetActive(false);
        anaMenu.SetActive(true);
    }
    public void seviye2Menu()
    {
        Seviyeler.SetActive(false);
        anaMenu.SetActive(true);
    }
    public void seviye22Menu()
    {
        Seviyeler2.SetActive(false);
        anaMenu.SetActive(true);
    }
    public void menu2Ayarlar()
    {
        anaMenu.SetActive(false);
        Ayarlar.SetActive(true);
    }
    public void menu2Seviyeler()
    {
        anaMenu.SetActive(false);
        Seviyeler.SetActive(true);
    }
    public void seviyeler2seviye2()
    {
        Seviyeler.SetActive(false);
        Seviyeler2.SetActive(true);
    }
    public void seviye22seviye3()
    {
        Seviyeler2.SetActive(false);
        Seviyeler3.SetActive(true);
    }
    public void seviye32seviye2()
    {
        Seviyeler3.SetActive(false);
        Seviyeler2.SetActive(true);
    }
    public void seviye32menu()
    {
        Seviyeler3.SetActive(false);
        Seviyeler2.SetActive(true);
    }
    public void seviye22seviyeler()
    {
        Seviyeler2.SetActive(false);
        Seviyeler.SetActive(true);
    }

    public void seviye1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void seviye2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void seviye3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void seviye4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void seviye5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void seviye6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void seviye7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void seviye8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void seviye9()
    {
        SceneManager.LoadScene("Level9");
    }

    /* public void Exit()
     {
         Application.Quit();
     }
    */
}

