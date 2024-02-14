using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Bottun : MonoBehaviour, IPointerDownHandler
{
    //‚±‚ê‚ÍUIƒWƒƒ‚Å‚«‚È‚¢
    //void OnMouseDown()
    //{
    //    Debug.Log("dekiru");
    //}

    //UI‚Í‚±‚Á‚¿
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("dekiru");
    }
}
