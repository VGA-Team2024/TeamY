using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    /// <summary>リソース管理クラス</summary>
    ResourceManager _resourceManager = null;

    /// <summary>アップグレード一覧</summary>
    [SerializeField] GameObject[] _cursorUpgrade;
    [SerializeField] GameObject[] _grandmaUpgrade;
    [SerializeField] GameObject[] _gunUpgrade;
    [SerializeField] GameObject[] _ringUpgrade;
    [SerializeField] GameObject[] _swordUpgrade;

    /// <summary>アップグレード販売条件</summary>
    [SerializeField] ulong[] _cursorSNum;
    [SerializeField] ulong[] _grandmaSNum;
    [SerializeField] ulong[] _gunSNum;
    [SerializeField] ulong[] _ringSNum;
    [SerializeField] ulong[] _swordSNum;

    /// <summary>アップグレードに対応する施設</summary>
    [SerializeField] Facility[] _facilities;

    /// <summary>切り替え用の変数</summary>
    public int _cursorUpgradeNum = 0;
    public int _grandmaUpgradeNum = 0;
    public int _gunUpgradeNum = 0;
    public int _ringUpgradeNum = 0;
    public int _swordUpgradeNum = 0;

    public bool _isCursorUGAllowed = false;
    public bool _isGrandmaUGAllowed = false;
    public bool _isGunUGAllowed = false;
    public bool _isRingUGAllowed = false;
    public bool _isSwordUGAllowed = false;

    public static UpgradeManager Instance { get; set; }

    EventManager _eventManager = null;

    [SerializeField] GameObject _relifeButton;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckCursor();
        CheckGrandma();
        CheckGun();
        CheckRing();
        CheckSword();

        CheckGrandmaUpgrade();
        CheckRingUpgrade();
        CheckSwordUpgrade();
    }

    private void FixedUpdate()
    {
        if (_isCursorUGAllowed)
        {
            _isCursorUGAllowed = false;
            ActivateCursorUG();
        }
        if (_isGrandmaUGAllowed)
        {
            _isGrandmaUGAllowed = false;
            ActivateGrandmaUG();
        }
        if (_isGunUGAllowed)
        {
            _isGunUGAllowed = false;
            ActivateGunUG();
        }
        if (_isRingUGAllowed)
        {
            _isRingUGAllowed = false;
            ActivateRingUG();
        }
        if (_isSwordUGAllowed)
        {
            _isSwordUGAllowed = false;
            ActivateSwordUG();
        }
    }
    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _eventManager = EventManager.Instance;
    }

    public void ActivateCursorUG()
    {
        if(_cursorUpgradeNum <= 5) 
        {
            _cursorUpgrade[_cursorUpgradeNum].SetActive(true);
        }
    }

    public void ActivateGrandmaUG()
    {
        if(_grandmaUpgradeNum <= 4)
        {
            _grandmaUpgrade[_grandmaUpgradeNum].SetActive(true);
        }
    }

    public void ActivateGunUG()
    {
        if (_gunUpgradeNum <= 4)
        {
            _gunUpgrade[_gunUpgradeNum].SetActive(true);
        }
    }

    public void ActivateRingUG()
    {
        if (_ringUpgradeNum <= 4)
        {
            _ringUpgrade[_ringUpgradeNum].SetActive(true);
        }
    }

    public void ActivateSwordUG()
    {
        if (_swordUpgradeNum <= 4)
        {
            _swordUpgrade[_swordUpgradeNum].SetActive(true);
        }
    }

    void CheckCursor()
    {
        if (_facilities[0]._ownedNum >= _cursorSNum[_cursorUpgradeNum])
        {
            _isCursorUGAllowed = true;
        }
    }

    void CheckGrandma()
    {
        if (_facilities[1]._ownedNum >= _grandmaSNum[_grandmaUpgradeNum])
        {
            _isGrandmaUGAllowed = true;
        }
    }

    void CheckGun()
    {
        if (_facilities[2]._ownedNum >= _gunSNum[_gunUpgradeNum])
        {
            _isGunUGAllowed = true;
        }
    }

    void CheckRing()
    {
        if (_facilities[3]._ownedNum >= _ringSNum[_ringUpgradeNum])
        {
            _isRingUGAllowed = true;
        }
    }

    void CheckSword()
    {
        if (_facilities[4]._ownedNum >= _swordSNum[_swordUpgradeNum])
        {
            _isSwordUGAllowed = true;
        }
    }

    void CheckGrandmaUpgrade()
    {
        if(_grandmaUpgradeNum == 4 && _eventManager._isObtainAllGrandmaUpgrade == false)
        {
            _eventManager._isObtainAllGrandmaUpgrade = true;
        }
    }

    void CheckRingUpgrade()
    {
        if(_ringUpgradeNum == 4 && _eventManager._isObtainAllRingUpgrade == false)
        {
            _eventManager._isPlayedStory3 = true;
            _eventManager._isObtainAllRingUpgrade = true;
            _eventManager.EnableStoryButton(2);
            _relifeButton.SetActive(true);
        }
    }

    void CheckSwordUpgrade()
    {
        if(_swordUpgradeNum == 4 && _eventManager._isObtainAllSwordUpgrade == false)
        {
            _eventManager._isObtainAllSwordUpgrade = true;
            _eventManager.EnableStoryButton(3);
        }
    }
}
