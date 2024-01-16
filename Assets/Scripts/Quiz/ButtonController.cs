using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        //_button = this.gameObject.GetComponent<Button>();
    }
    public void InteractiveOn()
    {
        _button.interactable = true;
    }
    public void InteractiveOff()
    {
        _button.interactable = false;
    }
}
