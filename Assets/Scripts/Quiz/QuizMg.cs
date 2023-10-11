using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizMg: MonoBehaviour
{
    public static QuizMg instance;

    public List<GameObject> badge = new List<GameObject>();
    public List<GameObject> Bookbadge = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            // ƒVƒ“ƒOƒ‹ƒgƒ“ˆ—
            instance = this;
        }
    }
}
