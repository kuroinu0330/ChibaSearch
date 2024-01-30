using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMg : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _PopUpImage = new List<Sprite>();
    [SerializeField]
    private Image nowImage;
    void Start()
    {
        nowImage = GetComponent<Image>();
    }
    public void PopUpImageChange(int i)
    {
        nowImage.sprite = _PopUpImage[i];
    }

}
