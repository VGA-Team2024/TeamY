using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>��{���\�[�X���Y��</summary>
    [SerializeField] float _baseCPS = 0;

    /// <summary>���\�[�X���Y��</summary>
    float _cps = 0;

    /// <summary>���݂̃A�b�v�O���[�h�{��</summary>
    public ulong _currentUpgradeFactor = 1;

    /// <summary>���\�[�X�Ǘ��N���X</summary>
    ResourceManager _resourceManager = null;

    /// <summary>�I�[�f�B�I�Ǘ��N���X</summary>
    SoundManager _soundManager = null;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _soundManager = SoundManager.Instance;
    }
    /// <summary>�N���b�N���̏���</summary>
    void OnClick()
    {
        _resourceManager.AddResource(CalCpS());
        _soundManager.PlayOtherSound(0);
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
    /// <summary>RPS���v�Z���郁�\�b�h</summary>
    ulong CalCpS()
    {
        _cps = _baseCPS * _currentUpgradeFactor;
        return (ulong)_cps;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
