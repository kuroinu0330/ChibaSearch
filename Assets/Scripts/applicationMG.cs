using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applicationMG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
            Debug.Log("Do something special here");
        
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
