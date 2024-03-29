using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>施設クラス</summary>
public class Facility : MonoBehaviour
{
    /// <summary>施設名</summary>
    [Header("施設の名前")]
    [SerializeField] public string _name;

    /// <summary>基本クッキー生産量</summary>
    [Header("基本クッキー生産量")]
    [SerializeField] float _baseCpS;

    /// <summary>基本購入金額</summary>
    [Header("基本購入金額")]
    [SerializeField] public ulong _basePrice;

    /// <summary>購入ごとの購入金額の上昇倍率</summary>
    const float _priceRate = 1.15f;

    /// <summary>アップグレードによるCpSの上昇倍率</summary>
    const float _upgradeRate = 2f;

    /// <summary>現在の施設所持数</summary>
    int _facilityNum;

    /// <summary>現在のアップグレード所持数</summary>
    int _upgradeNum;

    /// <summary>購入ボタン</summary>
    Button _button;

    /// <summary>購入ボタンのイメージ</summary>
    Image _buttonImage;

    /// <summary>施設アイコンのイメージ</summary>
    [SerializeField] public Image _iconImage;

    /// <summary>テキストのイメージ</summary>
    [SerializeField] private Image _textImage;

    /// <summary>施設名のテキスト</summary>
    [SerializeField] private TextMeshProUGUI _nameText;

    /// <summary>施設価格のテキスト</summary>
    [SerializeField] private TextMeshProUGUI _priceText;

    /// <summary>アイコンのスプライト</summary>
    [SerializeField] Sprite _iconSprite;

    /// <summary>最初にボタンを有効化する際のフラグ</summary>
    bool _isEnabld = false;

    /// <summary>ゲーム管理クラス</summary>
    GameManager _gameManager;
    void Start()
    {
        // 初期化
        SetUp();
        // クッキーを増加させるコルーチンの呼び出し
        StartCoroutine(GenerateCookie());
    }
    void Update()
    {
        if(_gameManager.GetCookie() >= _basePrice && _isEnabld == false)
        {
            // 有効化フラグを切り替える
            _isEnabld = true;
            SetButtonEnablement(2);
        }
        if(_gameManager.GetCookie() < CalPrice())
        {
            SetButtonEnablement(1);
        }
    }

    /// <summary>Start()で呼ばれる初期設定</summary>
    void SetUp()
    {
        // ゲーム管理クラスのインスタンスを取得
        _gameManager = GameManager.Instance;
        // ボタンUI
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        // テキストUI
        _nameText.text = _name;
        SetPriceText(_basePrice);
        // ボタンのイベント登録
        _button.onClick.AddListener(Purchase);
        // ボタンを非表示にする
        SetButtonEnablement(0);
    }

    /// <summary>価格テキストを設定</summary>
    void SetPriceText(ulong price)
    {
        _priceText.text = $"{price.UlongToComma()} C";
    }

    /// <summary>施設の購入時に呼ばれる処理</summary>
    void Purchase()
    {
        // 施設の購入金額分のクッキーを減少させる
        Payment();
        // 施設の所持数を増加させる
        _facilityNum++;
        // 価格テキストを"次の値段"に更新
        SetPriceText(CalPrice());
    }

    /// <summary>施設の売却時に呼ばれる処理</summary>
    public void Sell()
    {
        // 施設の所持数を減少させる
        _facilityNum--;
        // 施設の値段の2/3だけ所持クッキー量を増加させる
        PayBack();
    }

    /// <summary>購入ボタンの表示・非表示を設定する</summary>
    /// <param name="status">設定したいボタンの状態。0 = 非表示, 1 = 表示（半透明）, 2 = 表示（不透明）</param>
    void SetButtonEnablement(int status)
    {
        switch (status)
        {
            case 0:
                // イメージとテキストの色
                Color invisibleColor = new Color(1, 1, 1, 0);
                // ボタンを無効化
                _button.enabled = false;
                // 各イメージを非表示にする
                _buttonImage.color = invisibleColor;
                _iconImage.color = invisibleColor;
                _textImage.color = invisibleColor;
                // 各テキストを非表示にする
                _nameText.color = invisibleColor;
                _priceText.color = invisibleColor;

                break;

            case 1:
                // イメージとテキストの色
                Color translucentImageColor = new Color(1, 1, 1, 0.25f);
                Color translucentTextColor = new Color(0, 0, 0, 0.25f);
                // ボタンを無効化
                _button.enabled = false;
                // 各イメージを非表示にする
                _buttonImage.color = translucentImageColor;
                _iconImage.color = translucentImageColor;
                _textImage.color = translucentImageColor;
                // 各テキストを非表示にする
                _nameText.color = translucentTextColor;
                _priceText.color = translucentTextColor;

                break;

            case 2:
                // イメージとテキストの色
                Color opaqueImageColor = new Color(1, 1, 1, 1);
                Color opaqueTextColor = new Color(0, 0, 0, 1);
                // ボタンを無効化
                _button.enabled = true;
                // 各イメージを非表示にする
                _buttonImage.color = opaqueImageColor;
                _iconImage.color = opaqueImageColor;
                _textImage.color = opaqueImageColor;
                // 各テキストを非表示にする
                _nameText.color = opaqueTextColor;
                _priceText.color = opaqueTextColor;

                break;
        }
    }
    /// <summary>アップグレード倍率を乗算したCpSを計算する</summary>
    /// <returns>現在のCpS</returns>
    ulong CalCpS()
    {
        // 施設のみのCpS
        float facilityCpS;
        // アップグレードによるCpSの上昇倍率
        float upgradeBuff;

        facilityCpS = _baseCpS * _facilityNum;
        // アップグレードを購入していない場合1にする
        if (_upgradeNum == 0)
        {
            upgradeBuff = 1;
        }
        else
        {
            upgradeBuff = _upgradeRate * _upgradeNum;
        }
        return (ulong)(facilityCpS * upgradeBuff);
    }

    /// <summary>1秒ごとにCpS分だけクッキーを増加させる</summary>
    IEnumerator GenerateCookie()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _gameManager.AddCookie(CalCpS());
            Debug.Log("AddCookie Called");
        }
    }

    /// <summary>施設の値段を計算する</summary>
    ulong CalPrice()
    {
        return (ulong)(_basePrice * Mathf.Pow(_priceRate, _facilityNum));
    }

    /// <summary>施設の値段だけクッキーを減少させる</summary>
    void Payment()
    {
        _gameManager.SubtractCookie(CalPrice());
    }

    /// <summary>施設の売却時に呼ばれる処理</summary>
    public void PayBack()
    {
        // 施設の値段の2/3だけクッキーを払い戻す
        _gameManager.AddCookie(CalPrice() * 2 / 3);
    }

    /// <summary>転生時に呼ばれる処理</summary>
    public void Reset()
    {
        // 施設の所持数を初期化
        _facilityNum = 0;
        // アップグレードの所持数を初期化
        _upgradeNum = 0;
        // 施設アイコンを初期化
        _iconImage.sprite = _iconSprite;
        // 価格テキストを初期化
        SetPriceText(_basePrice);
        // 有効化フラグの初期化
        _isEnabld = false;
    }

    /// <summary>施設の所持数を返す</summary>
    public int GetFacilityNum()
    {
        return _facilityNum;
    }

    /// <summary>アップグレードの所持数を返す</summary>
    public int GetUpgradeNum()
    {
        return _upgradeNum;
    }

    /// <summary>アップグレードの所持数を1つ増やす</summary>
    public void AddUpgradeNum()
    {
        _upgradeNum++;
    }
}
