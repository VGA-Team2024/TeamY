using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    /// <summary>リソースを表示するテキスト</summary>
    [SerializeField] TextMeshProUGUI _resourceText;

    /// <summary>ショップオブジェクト</summary>
    [SerializeField] GameObject _cursor;
    [SerializeField] GameObject _grandma;
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject _ring;
    [SerializeField] GameObject _sword;

    /// <summary>有効化用変数</summary>
    bool _isCursorEnabled = false;
    bool _isGrandmaEnabled = false;
    bool _isGunEnabled = false;
    bool _isRingEnabled = false;
    bool _isSwordEnabled = false;

    /// <summary>リソース</summary>
    private ulong _currentResource = 0;

    /// <summary>リソース管理クラス</summary>
    ResourceManager _resourceManager = null;

    EventManager _eventManager = null;
    AchievementManager _achievementManager = null;
    UpgradeManager _upgradeManager = null;

    bool _isFirstGrandma = false;

    // 転生アイテム
    public int _heavenlyCookie = 0;

    [SerializeField] Facility[] _facilities = null;

    [SerializeField] GameObject _relifeButton;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _achievementManager = AchievementManager.Instance;
        _resourceManager = ResourceManager.Instance;
        _eventManager = EventManager.Instance;
        _upgradeManager = UpgradeManager.Instance;
    }
    void Update()
    {
        // リソースを同期
        SynchronizeResource();
        // テキストを更新
        SetText();
        // ショップを有効化
        Activate();
        // ストーリー1をチェック
        CheckFirstGrandmaBuy();
    }

    /// <summary>リソースを同期させるメソッド</summary>
    void SynchronizeResource()
    {
        _currentResource = _resourceManager.GetResource();
    }

    /// <summary>テキストを設定するメソッド</summary>
    void SetText()
    {
        _resourceText.text = $"{_currentResource.UlongToComma()} C";
    }

    /// <summary>ショップを有効化するメソッド</summary>
    void Activate()
    {
        if (_cursor.GetComponent<Facility>()._basePrice <= _resourceManager.GetResource() && _isCursorEnabled == false)
        {
            _isCursorEnabled = true;
            _cursor.SetActive(true);
            _cursor.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_grandma.GetComponent<Facility>()._basePrice <= _resourceManager.GetResource() && _isGrandmaEnabled == false)
        {
            _isGrandmaEnabled = true;
            _grandma.SetActive(true);
            _grandma.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_gun.GetComponent<Facility>()._basePrice <= _resourceManager.GetResource() && _isGunEnabled == false)
        {
            _isGunEnabled = true;
            _gun.SetActive(true);
            _gun.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_ring.GetComponent<Facility>()._basePrice <= _resourceManager.GetResource() && _isRingEnabled == false)
        {
            _isRingEnabled = true;
            _ring.SetActive(true);
            _ring.GetComponent<Facility>()._ownedFacility.SetActive(true);
        }
        if (_sword.GetComponent<Facility>()._basePrice <= _resourceManager.GetResource() && _isSwordEnabled == false)
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

    public void AddHC(int hc)
    {
        _heavenlyCookie += hc;
    }

    public void SubtractCookie(int c)
    {
        _resourceManager.SubtractResource((ulong)c);
    }

    public void ReLife()
    {
        if(_resourceManager.GetResource() >= 100000000)
        {
            _heavenlyCookie++;
        }
        _achievementManager.ReincarnatedPerson();
        _eventManager._isAchievedRelife = true;

        _resourceManager.SetResource(0);

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
            facility._ownedPriceText.text = "×0";
            facility._priceList.Clear();
            facility._priceText.text = $"{facility._currentPrice} C";
        }

        _relifeButton.SetActive(false);
    }
}
