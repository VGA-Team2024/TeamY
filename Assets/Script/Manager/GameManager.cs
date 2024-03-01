using TMPro;
using UnityEngine;

/// <summary>ゲーム全体を管理するクラス</summary>
public class GameManager : MonoBehaviour
{
    /// <summary>インスタンス</summary>
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

    /// <summary>現在のリソース量</summary>
    private ulong _resource = 10000000000;

    /// <summary>イベント管理クラス</summary>
    EventManager _eventManager = null;
    /// <summary>実績管理クラス</summary>
    AchievementManager _achievementManager = null;
    /// <summary>アップグレード管理クラス</summary>
    UpgradeManager _upgradeManager = null;

    bool _isFirstGrandma = false;

    /// <summary>転生アイテム量</summary>
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
        // ショップを有効化
        Activate();
        // ストーリー1をチェック
        CheckFirstGrandmaBuy();
    }

    /// <summary>リソースを取得する</summary>
    public ulong GetResource()
    {
        return _resource;
    }

    /// <summary>リソースを設定するメソッド</summary>
    /// <param name="value">設定後のリソース量</param>
    public void SetResource(ulong value)
    {
        _resource = value;
    }

    /// <summary>リソースを増加させる</summary>
    /// <param name="value">増加量</param>
    public void AddResource(ulong value)
    {
        //if (_isFever)
        //{
        //    SetResource(GetResource() + value * 7);
        //}
        SetResource(GetResource() + value);
        // テキストを更新
        UpdateResourceText();
    }

    /// <summary>リソースを減少させる</summary>
    /// <param name="value">減少量</param>
    public void SubtractResource(ulong value)
    {
        SetResource(GetResource() - value);
        // テキストを更新
        UpdateResourceText();
    }

/// <summary>リソースを表示するテキストを同期する</summary>
    void UpdateResourceText()
    {
        _resourceText.text = $"{_resource.UlongToComma()} C";
    }

    /// <summary>ショップを有効化するメソッド</summary>
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
            facility._ownedPriceText.text = "×0";
            facility._priceList.Clear();
            facility._priceText.text = $"{facility._currentPrice} C";
        }

        _relifeButton.SetActive(false);
    }
}
