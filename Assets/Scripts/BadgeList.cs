using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> myList = new List<GameObject>();
    [SerializeField]
    private List<Badge> _Badge = new List<Badge>();
    //[SerializeField]
    //Badge[] BadgeArray;
    public enum Badge
    {
        UnDone,
        Done,
    }
}
