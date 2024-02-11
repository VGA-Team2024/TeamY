using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIPoint : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    // Start is called before the first frame update
    private void Start()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
  

    void FixedUpdate()
    {
        _textMeshProUGUI.SetText(GameManager.Instance.GetPointAsString());
    }

    
}
