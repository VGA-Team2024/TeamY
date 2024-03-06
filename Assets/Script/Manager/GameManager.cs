using TMPro;
using UnityEngine;

/// <summary>�Q�[���S�̂��Ǘ�����N���X</summary>
public class GameManager : MonoBehaviour
{
    /// <summary>�C���X�^���X</summary>
    public static GameManager Instance { get; set; }

    /// <summary>���݂̃N�b�L�[�ʂ�\������e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _cookieText;

    /// <summary>���݂̃��\�[�X��</summary>
    private ulong _resource = 10000000000;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>���\�[�X���擾����</summary>
    public ulong GetCookie()
    {
        return _resource;
    }

    /// <summary>���\�[�X��ݒ肷�郁�\�b�h</summary>
    /// <param name="value">�ݒ��̃��\�[�X��</param>
    public void SetCookie(ulong value)
    {
        _resource = value;
    }

    /// <summary>�N�b�L�[�𑝉�������</summary>
    /// <param name="value">����������N�b�L�[�̗�</param>
    public void AddCookie(ulong value)
    {
        SetCookie(GetCookie() + value);
        // �e�L�X�g���X�V
        _cookieText.text = $"{_resource.UlongToComma()} C";
    }

    /// <summary>�N�b�L�[������������</summary>
    /// <param name="value">����������N�b�L�[�̗�</param>
    public void SubtractCookie(ulong value)
    {
        SetCookie(GetCookie() - value);
        // �e�L�X�g���X�V
        _cookieText.text = $"{_resource.UlongToComma()} C";
    }
}
