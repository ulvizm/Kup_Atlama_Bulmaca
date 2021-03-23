using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KupMesh : MonoBehaviour
{
                                                          //private MeshRenderer rend;
    private Animator anim;

    private void Start()
    {
        //rend = GetComponent<MeshRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger")
        {
            anim.SetTrigger("Buyutme");                                            //rend.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trigger")
        {
            anim.SetTrigger("Kucultme");                                       //rend.enabled = false;
        }
    }
}

