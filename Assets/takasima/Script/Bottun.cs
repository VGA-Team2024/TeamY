using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Bottun : MonoBehaviour, IPointerDownHandler
{
    //�����UI�W���ł��Ȃ�
    //void OnMouseDown()
    //{
    //    Debug.Log("dekiru");
    //}

    //UI�͂�����
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("dekiru");
    }
}
