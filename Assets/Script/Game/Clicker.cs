using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>基本リソース生産量</summary>
    [SerializeField] float _baseRPS = 0;

    /// <summary>リソース生産量</summary>
    float _rps = 0;

    /// <summary>アップグレードされたか否かの判定</summary>
    [SerializeField] public bool _isUpGraded = false;

    /// <summary>リソース管理クラス</summary>
    ResourceManager _resourceManager = null;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }
    /// <summary>クリック時の処理</summary>
    void OnClick()
    {
        _resourceManager.AddResource(CalRPS());
    }

    /// <summary>RPSを計算するメソッド</summary>
    ulong CalRPS()
    {
        if (_isUpGraded)
        {
            _rps = _baseRPS * 2;
        }
        else
        {
            _rps = _baseRPS * 1;
        }
        return (ulong)_rps;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
