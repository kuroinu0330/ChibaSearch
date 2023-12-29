using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuruBuruMove : MonoBehaviour
{
    public Transform _aaa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(Time.time * 10);
        new Vector3(sin, sin, 0);
    }
}
