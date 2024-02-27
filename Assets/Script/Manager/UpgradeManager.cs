using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    /// <summary>���\�[�X�Ǘ��N���X</summary>
    ResourceManager _resourceManager = null;

    /// <summary>�A�b�v�O���[�h�ꗗ</summary>
    [SerializeField] GameObject[] _cursorUpgrade;
    [SerializeField] GameObject[] _grandmaUpgrade;
    [SerializeField] GameObject[] _gunUpgrade;
    [SerializeField] GameObject[] _ringUpgrade;
    [SerializeField] GameObject[] _swordUpgrade;

    /// <summary>�؂�ւ��p�̕ϐ�</summary>
    public int _cursorUpgradeNum = 0;
    public int _grandmaUpgradeNum = 0;
    public int _gunUpgradeNum = 0;
    public int _ringUpgradeNum = 0;
    public int _swordUpgradeNum = 0;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }

    void Update()
    {
        
    }

    public void ActivateCursorUG()
    {
        _cursorUpgrade[_cursorUpgradeNum].SetActive(true);
        _cursorUpgradeNum++;
    }

    public void ActivateGrandmaUG()
    {
        _grandmaUpgrade[_grandmaUpgradeNum].SetActive(true);
        _grandmaUpgradeNum++;
    }

    public void ActivateGunUG()
    {
        _gunUpgrade[_gunUpgradeNum].SetActive(true);
        _gunUpgradeNum++;
    }

    public void ActivateRingUG()
    {
        _ringUpgrade[_ringUpgradeNum].SetActive(true);
        _ringUpgradeNum++;
    }

    public void ActivateSwordUG()
    {
        _swordUpgrade[_swordUpgradeNum].SetActive(true);
        _swordUpgradeNum++;
    }
}
