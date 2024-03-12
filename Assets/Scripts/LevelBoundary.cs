using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        ImportantGameplayObjects obj = other.GetComponent<ImportantGameplayObjects>();

        if (obj != null)
        {
            obj.ResetPosition();
        }
    }
}