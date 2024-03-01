using TMPro;
using UnityEngine;

/// <summary>�Q�[���S�̂��Ǘ�����N���X</summary>
public class GameManager : MonoBehaviour
{
    /// <summary>�C���X�^���X</summary>
    public static GameManager Instance { get; set; }

    /// <summary>���\�[�X��\������e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _resourceText;

    /// <summary>�V���b�v�I�u�W�F�N�g</summary>
    [SerializeField] GameObject _cursor;
    [SerializeField] GameObject _grandma;
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject _ring;
    [SerializeField] GameObject _sword;

    /// <summary>�L�����p�ϐ�</summary>
    bool _isCursorEnabled = false;
    bool _isGrandmaEnabled = false;
    bool _isGunEnabled = false;
    bool _isRingEnabled = false;
    bool _isSwordEnabled = false;

    /// <summary>���݂̃��\�[�X��</summary>
    private ulong _resource = 10000000000;

    /// <summary>�C�x���g�Ǘ��N���X</summary>
    EventManager _eventManager = null;
    /// <summary>���ъǗ��N���X</summary>
    AchievementManager _achievementManager = null;
    /// <summary>�A�b�v�O���[�h�Ǘ��N���X</summary>
    UpgradeManager _upgradeManager = null;

    bool _isFirstGrandma = false;

    /// <summary>�]���A�C�e����</summary>
    public int _currentHC = 0;

    [SerializeField] Facility[] _facilities = null;

    [SerializeField] GameObject _relifeButton;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _achievementManager = AchievementManager.Instance;
        _eventManager = EventManager.Instance;
        _upgradeManager = UpgradeManager.Instance;
    }
    void Update()
    {
        // �V���b�v��L����
        Activate();
        // �X�g�[���[1���`�F�b�N
        CheckFirstGrandmaBuy();
    }

    /// <summary>���\�[�X���擾����</summary>
    public ulong GetResource()
    {
        return _resource;
    }

    /// <summary>���\�[�X��ݒ肷�郁�\�b�h</summary>
    /// <param name="value">�ݒ��̃��\�[�X��</param>
    public void SetResource(ulong value)
    {
        _resource = value;
    }

    /// <summary>���\�[�X�𑝉�������</summary>
    /// <param name="value">������</param>
    public void AddResource(ulong value)
    {
        //if (_isFever)
        //{
        //    SetResource(GetResource() + value * 7);
        //}
        SetResource(GetResource() + value);
        // �e�L�X�g���X�V
        UpdateResourceText();
    }

    /// <summary>���\�[�X������������</summary>
    /// <param name="value">������</param>
    public void SubtractResource(ulong value)
    {
        SetResource(GetResource() - value);
        // �e�L�X�g���X�V
        UpdateResourceText();
    }

/// <summary>���\�[�X��\������e�L�X�g�𓯊�����</summary>
    void UpdateResourceText()
    {
        _resourceText.text = $"{_resource.UlongToComma()} C";
    }

    /// <summary>�V���b�v��L�������郁�\�b�h</summary>
    void Activate()
    {
        if (_cursor.GetComponent<Facility>()._basePrice <= GetResource() && _isCursorEnabled == false)
        {
            _isCursorEnabled = true;
            _cursor.SetActive(true);
            _cursor.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_grandma.GetComponent<Facility>()._basePrice <= GetResource() && _isGrandmaEnabled == false)
        {
            _isGrandmaEnabled = true;
            _grandma.SetActive(true);
            _grandma.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_gun.GetComponent<Facility>()._basePrice <= GetResource() && _isGunEnabled == false)
        {
            _isGunEnabled = true;
            _gun.SetActive(true);
            _gun.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_ring.GetComponent<Facility>()._basePrice <= GetResource() && _isRingEnabled == false)
        {
            _isRingEnabled = true;
            _ring.SetActive(true);
            _ring.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_sword.GetComponent<Facility>()._basePrice <= GetResource() && _isSwordEnabled == false)
        {
            _isSwordEnabled = true;
            _sword.SetActive(true);
            _sword.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
    }
    public void CheckFirstGrandmaBuy()
    {
        if (_isFirstGrandma) return;

        if (_grandma.GetComponent<Facility>()._ownedNum == 1 && !_isFirstGrandma)
        {
            _isFirstGrandma = true;
            _eventManager._isPlayedStory1 = true;
            _eventManager.EnableStoryButton(0);
        }
    }

    public void ReLife()
    {
        if(GetResource() >= 100000000)
        {
            _currentHC++;
        }
        _achievementManager.ReincarnatedPerson();
        _eventManager._isAchievedRelife = true;

        SetResource(0);

        _upgradeManager._cursorUpgradeNum = 0;
        _upgradeManager._grandmaUpgradeNum = 0;
        _upgradeManager._gunUpgradeNum = 0;
        _upgradeManager._ringUpgradeNum = 0;
        _upgradeManager._swordUpgradeNum = 0;

        foreach(var facility in _facilities)
        {
            facility._ownedNum = 0;
            facility._currentPrice = facility._basePrice;
            facility._currentMultiplier = facility._baseMultiplier;
            facility._currentUpgradeFactor = 1;
            facility._ownedNum = 0;
            facility._ownedPriceText.text = "�~0";
            facility._priceList.Clear();
            facility._priceText.text = $"{facility._currentPrice} C";
        }

        _relifeButton.SetActive(false);
    }
}
