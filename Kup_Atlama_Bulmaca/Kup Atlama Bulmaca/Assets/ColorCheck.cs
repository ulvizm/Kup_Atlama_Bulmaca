using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorCheck : MonoBehaviour
{
    public GameObject yanmaMenuUI;
    //
    private int currentSeviye;
    //
    private Color oyuncuRenk;
    private Color kupRenk;
    //
    [SerializeField] ParticleSystem failParticle;
    [SerializeField] ParticleSystem winParticle;
    //
    [SerializeField] AudioClip failSong;
    [SerializeField] AudioClip winSong;
    AudioSource audioSource;
    void Start()
    {
        yanmaMenuUI.SetActive(false);
        currentSeviye = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
        kupRenk = GetComponent<Renderer>().material.color;
        gameObject.tag = "WinPad";
    }
    private void OnCollisionEnter(Collision collision)
    {
        oyuncuRenk = collision.gameObject.GetComponent<Renderer>().material.color;

        if (collision.gameObject.tag == "WinPad")
        {
            winParticle.Play();
            audioSource.PlayOneShot(winSong);
        }
        
        else if (oyuncuRenk != kupRenk)
        {
            failParticle.Play();
            audioSource.PlayOneShot(failSong);
            yanmaMenuUI.SetActive(true);
        }
    }
    private void SeviyeTekrar()
    {
        SceneManager.LoadScene(currentSeviye);
    }
}
