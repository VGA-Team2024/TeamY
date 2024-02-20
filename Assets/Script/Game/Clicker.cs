using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>��{���\�[�X���Y��</summary>
    [SerializeField] float _baseCpS = 0;

    /// <summary>���\�[�X���Y��</summary>
    float _cps = 0;

    /// <summary>���݂̃A�b�v�O���[�h�{��</summary>
    public ulong _currentUpgradeFactor = 1;

    /// <summary>���\�[�X�Ǘ��N���X</summary>
    ResourceManager _resourceManager = null;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }
    /// <summary>�N���b�N���̏���</summary>
    void OnClick()
    {
        _resourceManager.AddResource(CalCpS());
    }

    /// <summary>RPS���v�Z���郁�\�b�h</summary>
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
