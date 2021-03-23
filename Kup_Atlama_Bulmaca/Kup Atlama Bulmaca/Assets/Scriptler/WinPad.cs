using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPad : MonoBehaviour
{
    private int yeniSeviye;
    void Start()
    {
        yeniSeviye = SceneManager.GetActiveScene().buildIndex + 1;
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
        SeviyeAtlama();
        }
    }
    private void SeviyeAtlama()
    {
        SceneManager.LoadScene("Menu");
    }
}
