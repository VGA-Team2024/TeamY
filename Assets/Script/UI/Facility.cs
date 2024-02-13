using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Facility : MonoBehaviour
{
    /// <summary>基本リソース生産量</summary>
    [SerializeField] float _baseRPS = 0;

    /// <summary>リソース生産量</summary>
    float _rps = 0;

    /// <summary>基本購入金額</summary>
    [SerializeField] ulong _basePrice = 0;

    /// <summary>現在の購入金額</summary>
    ulong _currentPrice = 0;

    /// <summary>基本購入倍率</summary>
    [SerializeField] float _baseMultiplier = 1.15f;

    /// <summary>現在の購入倍率</summary>
    float _currentMultiplier = 1;

    /// <summary>現在の購入数</summary>
    public ulong _ownedNum = 0;

    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先のイメージ</summary>
    Image _image;

    /// <summary>アタッチ先のテキスト</summary>
    [SerializeField] TextMeshProUGUI _shopText;

    /// <summary>施設リストのテキスト</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>アイテムの名前</summary>
    [SerializeField] string _name;

    /// <summary>アップグレードの判定</summary>
    [SerializeField] public bool _isUpGraded = false;

    /// <summary>タイマー変数</summary>
    float _timer = 0;

    /// <summary>リソース管理クラスのインスタンス</summary>
    ResourceManager _resourceManager;

    void Start()
    {
        // 購入金額を初期化
        _currentPrice = _basePrice;
        _resourceManager = ResourceManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // テキストを初期化
        _shopText.text = $"{_name}　{_currentPrice}G";
        _facilityText.text = $"{_name}　×{_ownedNum}";

        // クリック時のイベントを設定
        _button.onClick.AddListener(UpdatePrice);
    }

    void Update()
    {
        // リソース量が現在の購入金額に満たない場合
        if(_resourceManager.GetResource() < _currentPrice)
        {
            _button.enabled = false;
            _image.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            _button.enabled = true;
            _image.color = new Color(1, 1, 1, 1);
        }
        // 1秒ごとにリソース増加
        _timer += Time.deltaTime;

        if(_timer > 1)
        {
            _timer = 0;
            _resourceManager.AddResource(CalTotalRPS());
        }
    }

    /// <summary>RPSの総量を計算するメソッド</summary>
    ulong CalTotalRPS()
    {
        if(_isUpGraded)
        {
            _rps = _baseRPS * 2;
        }
        else
        {
            _rps = _baseRPS * 1;
        }
        return (ulong)(_rps * _ownedNum);
    }

    /// <summary>購入数を増加させるメソッド</summary>
    void AddOwnedNum()
    {
        _ownedNum++;
    }

    /// <summary>次の購入倍率を計算するメソッド</summary>
    void CalNextMultiplier()
    {
        _currentMultiplier *= _baseMultiplier;
    }

    /// <summary>現在の購入金額を計算するメソッド</summary>
    void CalCurrentPrice()
    {
        _currentPrice = (ulong)(_basePrice * _currentMultiplier);
    }

    /// <summary>現在の購入金額を更新し、購入金額分リソースを減らすメソッド</summary>
    void UpdatePrice()
    {
        // 購入数を増加
        AddOwnedNum();

        // 現在の購入金額だけリソースを減少
        _resourceManager.SubtractResource(_currentPrice);

        // 購入倍率を更新
        CalNextMultiplier();

        // 購入金額を更新
        CalCurrentPrice();

        // テキストを更新
        _shopText.text = $"{_name}　{_currentPrice}G";
        _facilityText.text = $"{_name}　×{_ownedNum}";
    }
}
