using UnityEngine;

public class badgeGetFalse : MonoBehaviour
{
    [SerializeField]
    private GameObject _obj;
    
    public void Getfalse()
    {
        QuizMg.instance.Getbadge[QuizMg.instance.numGet].SetActive(false);
        _obj.SetActive(false);
        // 移動可能フラグを有効化
        TrackingMousePosition.Instance.UIButtomExit();
    }
}
