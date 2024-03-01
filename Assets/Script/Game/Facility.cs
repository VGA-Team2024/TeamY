using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Facility : MonoBehaviour
{
    /// <summary>基本リソース生産量</summary>
    [SerializeField] float _baseCPS = 0;

    /// <summary>リソース生産量</summary>
    float _cps = 0;

    /// <summary>基本購入金額</summary>
    [SerializeField] public ulong _basePrice = 0;

    /// <summary>現在の購入金額</summary>
    public ulong _currentPrice = 0;

    /// <summary>基本購入倍率</summary>
    [SerializeField] public  float _baseMultiplier = 1.15f;

    /// <summary>現在の購入倍率</summary>
    public float _currentMultiplier = 1;

    /// <summary>現在のアップグレード倍率</summary>
    public ulong _currentUpgradeFactor = 1;

    /// <summary>現在の購入数</summary>
    public ulong _ownedNum = 0;

    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先のイメージ</summary>
    Image _image;

    /// <summary>アイコンのイメージ</summary>
    [SerializeField] Image _iconImage;

    /// <summary>テキストのイメージ</summary>
    [SerializeField] Image _textImage;

    /// <summary>アタッチ先の価格テキスト</summary>
    [SerializeField] public TextMeshProUGUI _priceText;

    /// <summary>アタッチ先の名前テキスト</summary>
    [SerializeField] public TextMeshProUGUI _nameText;

    /// <summary>施設リストのオブジェクト</summary>
    [SerializeField] public GameObject _ownedFacility;

    /// <summary>アタッチ先の名前テキスト</summary>
    [SerializeField] public TextMeshProUGUI _ownedPriceText;

    /// <summary>施設の名前</summary>
    [SerializeField] public string _name;

    /// <summary>タイマー変数</summary>
    float _timer = 0;

    /// <summary>桁表記用変数</summary>
    string _PS;

    /// <summary>リソース管理クラスのインスタンス</summary>
    GameManager _gameManager;

    /// <summary>値段記録用のリスト</summary>
    public List<ulong> _priceList = new List<ulong>();

    void Start()
    {
        // 現在の購入金額を基本購入金額に初期化
        _currentPrice = _basePrice;

        _gameManager = GameManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // テキストを初期化
        _priceText.text = $"{_currentPrice} C";

        // クリック時のイベントを設定
        _button.onClick.AddListener(UpdatePrice);

        // 所持施設リストを非表示にする。
        _ownedFacility.SetActive(false);

        // 最初は無効化
        gameObject.SetActive(false);
    }

    void Update()
    {
        // リソース量が現在の購入金額に満たない場合、ボタンを半透明化する。
        if(_gameManager.GetResource() < _currentPrice)
        {
            // ボタン
            _button.enabled = false;
            // ボタンイメージ
            _image.color = new Color(1, 1, 1, 0.25f);
            // 名前テキスト
            _priceText.color = new Color(0, 0, 0, 0.25f);
            // 価格テキスト
            _nameText.color = new Color(0, 0, 0, 0.25f);
            // アイコン
            _iconImage.color = new Color(1, 1, 1, 0.25f); 
            // テキストイメージ
            _textImage.color = new Color(1, 1, 1, 0.25f); 
        }
        else
        {
            // ボタン
            _button.enabled = true;
            // ボタンイメージ
            _image.color = new Color(1, 1, 1, 1);
            // 名前テキスト
            _priceText.color = new Color(0, 0, 0, 1);
            // 価格テキスト
            _nameText.color = new Color(0, 0, 0, 1);
            // アイコン
            _iconImage.color = new Color(1, 1, 1, 1);
            // テキストイメージ
            _textImage.color = new Color(1, 1, 1, 1);
        }

        // 1秒ごとにリソースを増加させる
        _timer += Time.deltaTime;

        if (_timer >= 1.0f)
        {
            _timer = 0;
            _gameManager.AddResource(CalTotalCpS());
        }
    }

    /// <summary>CpSの総量を計算するメソッド</summary>
    ulong CalTotalCpS()
    {
        _cps = _baseCPS * _currentUpgradeFactor;
        return (ulong)(_cps * _ownedNum);
    }

    /// <summary>購入数を増加させるメソッド</summary>
    void AddOwnedNum()
    {
        if(_ownedNum == 0 )
        {
            _ownedFacility.SetActive(true);
        }
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

    /// <summary>購入金額を更新するメソッド。購入処理後に金額を更新している。</summary>
    void UpdatePrice()
    {
        // 購入数を増加
        AddOwnedNum();

        // 売却用に値段を記録
        _priceList.Add(_currentPrice);

        // 現在の購入金額だけリソースを減少
        _gameManager.SubtractResource(_currentPrice);

        // 購入倍率を更新
        CalNextMultiplier();

        // 購入金額を更新
        CalCurrentPrice();

        // 施設リストのテキストを更新
        _ownedPriceText.text = $"×{_ownedNum}";

        // ショップの値段テキストを更新
        if(_currentPrice > 1000000000)
        {
            _PS = _currentPrice.ToString();
            _priceText.text = $"10億{_PS[2]}{_PS[3]}{_PS[4]}{_PS[5]}万 C";
        }
        else if(_currentPrice > 1000000000000)
        {
            _PS = _currentPrice.ToString();
            _priceText.text = $"1兆{_PS[1]}{_PS[2]}{_PS[3]}{_PS[4]}億 C";
        }
        else
        {
            _priceText.text = $"{_currentPrice} C";
        }
    }
}
