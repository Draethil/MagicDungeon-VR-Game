using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Silver_Key"))
        {
            anim.SetTrigger("OpenChest");
            Destroy(other.gameObject);
        }
    }

    void pauseanimation(){
        anim.enabled = false;
    }
}
