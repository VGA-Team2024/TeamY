using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>��{�N�b�L�[���Y��</summary>
    [Header("��{�N�b�L�[���Y��")]
    [SerializeField] float _baseCpS;

    /// <summary>�A�b�v�O���[�h�ɂ��CpS�̏㏸�{��</summary>
    const float _upgradeRate = 2f;

    /// <summary>���݂̃A�b�v�O���[�h������</summary>
    int _upgradeNum;

    /// <summary>�Q�[���Ǘ��N���X</summary>
    GameManager _gameManager;

    /// <summary>�I�[�f�B�I�Ǘ��N���X</summary>
    SoundManager _soundManager = null;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _soundManager = SoundManager.Instance;
    }

    /// <summary>�J�[�\������ɗ������̏���</summary>
    public void OnEnter()
    {
        this.gameObject.transform.localScale = new Vector3(5f, 5f, 5f);
        _soundManager.PlayOtherSound(1);
    }

    /// <summary>�J�[�\�������ꂽ���̏���</summary>
    public void OnExit()
    {
        this.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
    }

    /// <summary>�N���b�N���̏���</summary>
    void OnClick()
    {
        _gameManager.AddCookie(CalCpS());
        _soundManager.PlayOtherSound(0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    /// <summary>�A�b�v�O���[�h�{������Z����CpS���v�Z����</summary>
    /// <returns>���݂�CpS</returns>
    ulong CalCpS()
    {
        // �A�b�v�O���[�h�ɂ��CpS�̏㏸�{��
        float upgradeBuff;
        // �A�b�v�O���[�h���w�����Ă��Ȃ��ꍇ1�ɂ���
        if (_upgradeNum == 0)
        {
            upgradeBuff = 1;
        }
        else
        {
            upgradeBuff = _upgradeRate * _upgradeNum;
        }
        return (ulong)(_baseCpS * upgradeBuff);
    }
}
