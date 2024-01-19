/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDrag : MonoBehaviour
{
    
    //�I�u�W�F�N�g���N���b�N���ăh���b�O��Ԃɂ���ԌĂяo�����֐��iUnity�̃}�E�X�C�x���g�j
    void OnMouseDrag()
    {
        //�}�E�X�J�[�\���y�уI�u�W�F�N�g�̃X�N���[�����W���擾
        Vector3 objectScreenPoint =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100);

        //�X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);

        //�I�u�W�F�N�g�̍��W��ύX����
        transform.position = objectWorldPoint;
    }
    

}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObj : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    private Vector2 prevPos; //�ۑ����Ă�������position
    public RectTransform rectTransform; // �ړ��������I�u�W�F�N�g��RectTransform
    private RectTransform parentRectTransform; // �ړ��������I�u�W�F�N�g�̐e(Panel)��RectTransform


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = rectTransform.parent as RectTransform;
    }


    // �h���b�O�J�n���̏���
    public void OnBeginDrag(PointerEventData eventData)
    {
        // �h���b�O�O�̈ʒu���L�����Ă���
        // RectTransform�̏ꍇ��position�ł͂Ȃ�anchoredPosition���g��
        prevPos = rectTransform.anchoredPosition;

    }

    // �h���b�O���̏���
    public void OnDrag(PointerEventData eventData)
    {
        // eventData.position����A�e�ɏ]��localPosition�ւ̕ϊ����s��
        // �I�u�W�F�N�g�̈ʒu��localPosition�ɕύX����

        Vector2 localPosition = GetLocalPosition(eventData.position);
        rectTransform.anchoredPosition = localPosition;
    }

    // �h���b�O�I�����̏���
    public void OnEndDrag(PointerEventData eventData)
    {
        // �I�u�W�F�N�g���h���b�O�O�̈ʒu�ɖ߂�
        //rectTransform.anchoredPosition = prevPos;
    }

    // ScreenPosition����localPosition�ւ̕ϊ��֐�
    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;

        // screenPosition��e�̍��W�n(parentRectTransform)�ɑΉ�����悤�ϊ�����.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, screenPosition, Camera.main, out result);

        return result;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Button>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.GetComponent<Button>().enabled = false;
    }
}
