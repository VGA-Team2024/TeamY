using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Bottun : MonoBehaviour, IPointerDownHandler
{
    //これはUIジャできない
    //void OnMouseDown()
    //{
    //    Debug.Log("dekiru");
    //}

    //UIはこっち
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("dekiru");
    }
}
