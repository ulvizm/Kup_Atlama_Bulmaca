using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] float hiz = 0;
    [SerializeField] public Vector3 target = new Vector3(0, 1, 0);
    [SerializeField] public Vector3 currentPosition = new Vector3(0, 0, 0);
    [SerializeField] private bool moving = false;
    Rigidbody rb;
    //
    [SerializeField] AudioClip boink;
    [SerializeField] AudioClip falling;
    AudioSource audioSource;
    //
    private bool tap, solaKayma, sagaKayma, yukariKayma, asagiKayma, sagUstKayma, solUstKayma, sagAltKayma, solAltKayma;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    //
    private int currentSeviye;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentSeviye = SceneManager.GetActiveScene().buildIndex;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Hareket();
        Dusme();
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
    public void Hareket()
    {
        // bu kısım touch için yapıldı
        sagaKayma = solaKayma = yukariKayma = asagiKayma = sagUstKayma = solUstKayma = sagAltKayma = solAltKayma = false;

        #region Bilgisayar Input
        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }
        #endregion

        #region Distance ve Aci

        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
        if (swipeDelta.magnitude > 100)
        {

            float x = swipeDelta.x;
            float y = swipeDelta.y;
            float aci = Vector2.SignedAngle(startTouch, swipeDelta);
            Debug.Log(aci);

            if (aci > -4.5 && aci < 40.5)
            {
                sagUstKayma = true;
            }
            else if (aci > 40.5 && aci < 85.5)
            {
                yukariKayma = true;
            }
            else if (aci > 85.5 && aci < 130.5)
            {
                solUstKayma = true;
            }
            else if (aci > 130.5 && aci < 175.5)
            {
                solaKayma = true;
            }
            else if (aci < -4.5 && aci > -49.5)
            {
                sagaKayma = true;
            }
            else if (aci < -49.5 && aci > -94.5)
            {
                sagAltKayma = true;
            }
            else if (aci < -94.5 && aci > -139.5)
            {
                asagiKayma = true;
            }
            else
            {
                solAltKayma = true;
            }

            Reset();
        }
        #endregion

        //////////////
        float mesafe = Time.deltaTime * hiz;
        if (transform.position == target)
        {
            moving = false;
        }
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, mesafe);
            if (audioSource.isPlaying == false)
                audioSource.PlayOneShot(boink);
        }
        if (solUstKayma && (rb.velocity.y == 0)) // QQ (0,0,1.5)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(0, 0, 1.5f);
        }
        else if (yukariKayma && (rb.velocity.y == 0)) // WW (1.5,0,1.5) 
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(1.5f, 0, 1.5f);
        }
        else if (sagUstKayma && (rb.velocity.y == 0)) // EE (1.5,0,0)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(1.5f, 0, 0);
        }
        else if (sagaKayma && (rb.velocity.y == 0)) // DD (1.5,0,-1.5)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(1.5f, 0, -1.5f);
        }
        else if (solaKayma && (rb.velocity.y == 0)) // AA (-1.5,0,1.5)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(-1.5f, 0, 1.5f);
        }
        else if (sagAltKayma && (rb.velocity.y == 0)) // CC (-1.5,0,1.5)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(0, 0, -1.5f);
        }
        else if (solAltKayma && (rb.velocity.y == 0)) // ZZ (-1.5,0,1.5)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(-1.5f, 0, 0);
        }
        else if (asagiKayma && (rb.velocity.y == 0)) // XX Input.GetKeyDown(KeyCode.X) (-1.5,0,1.5)
        {
            rb.velocity = new Vector3(0, 5, 0);
            moving = true;
            target = transform.position + new Vector3(-1.5f, 0, -1.5f);
        }
    }
    public void Dusme()
    {
        if (transform.position.y > -3 && transform.position.y < 0)
        {
            if (audioSource.isPlaying == false)
                audioSource.PlayOneShot(falling);
            Invoke("SeviyeTekrar", 1f);
        }
    }
    private void SeviyeTekrar()
    {
        SceneManager.LoadScene(currentSeviye);
    }
}