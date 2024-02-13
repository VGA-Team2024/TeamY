using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    /// <summary>���\�[�X��\������e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _resourceText;

    /// <summary>���\�[�X</summary>
    private ulong _currentResource = 0;

    /// <summary>���\�[�X�Ǘ��N���X</summary>
    ResourceManager _resourceManager = null;
    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }
    void Update()
    {
        // ���\�[�X�𓯊�
        SynchronizeResource();
        // �e�L�X�g���X�V
        SetText();
    }

    /// <summary>���\�[�X�𓯊������郁�\�b�h</summary>
    void SynchronizeResource()
    {
        _currentResource = _resourceManager.GetResource();
    }

    /// <summary>�e�L�X�g��ݒ肷�郁�\�b�h</summary>
    void SetText()
    {
        _resourceText.text = $"{_currentResource.UlongToComma()} G";
    }
}
