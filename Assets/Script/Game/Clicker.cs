using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>��{���\�[�X���Y��</summary>
    [SerializeField] float _baseRPS = 0;

    /// <summary>���\�[�X���Y��</summary>
    float _rps = 0;

    /// <summary>�A�b�v�O���[�h���ꂽ���ۂ��̔���</summary>
    [SerializeField] public bool _isUpGraded = false;

    /// <summary>���\�[�X�Ǘ��N���X</summary>
    ResourceManager _resourceManager = null;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }
    /// <summary>�N���b�N���̏���</summary>
    void OnClick()
    {
        _resourceManager.AddResource(CalRPS());
    }

    /// <summary>RPS���v�Z���郁�\�b�h</summary>
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
