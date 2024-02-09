using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptUIpoint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _pointText;
    private void Start()
    {
        UpdateText();
    }
    private void UpdateText()
    {
       
        _pointText.SetText(GameManager.Instance.GetPoint().ToString());
        

    }
    private void OnEnable()
    {
      GameManager.Instance.OnPointChanged += UpdateText;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnPointChanged -= UpdateText;
    }
}
