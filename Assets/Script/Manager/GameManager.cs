using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
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

    bool _isFirstGrandma = false;
    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _eventManager = EventManager.Instance;
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
            _eventManager.EnableStoryButton(0);
        }
    }
}
