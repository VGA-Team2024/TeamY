using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>基本リソース生産量</summary>
    [SerializeField] float _baseCpS = 0;

    /// <summary>リソース生産量</summary>
    float _cps = 0;

    /// <summary>現在のアップグレード倍率</summary>
    public ulong _currentUpgradeFactor = 1;

    /// <summary>リソース管理クラス</summary>
    ResourceManager _resourceManager = null;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }
    /// <summary>クリック時の処理</summary>
    void OnClick()
    {
        _resourceManager.AddResource(CalCpS());
    }

    /// <summary>RPSを計算するメソッド</summary>
    ulong CalCpS()
    {
        _cps = _baseCpS * _currentUpgradeFactor;
        return (ulong)_cps;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
