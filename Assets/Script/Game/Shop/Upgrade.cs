using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>アップグレード</summary>
public class Upgrade : MonoBehaviour
{
    /// <summary>対応する施設クラス</summary>
    [Header("対応する施設クラス")]
    [SerializeField] Facility _facility;

    /// <summary>ゲーム管理クラス</summary>
    GameManager _gameManager;

    /// <summary>基本購入金額</summary>
    ulong _basePrice;

    /// <summary>購入金額の上昇倍率</summary>
    ulong[] _priceRate = { 10, 50, 500, 50000, 5000000 };

    /// <summary>購入条件となる施設の所持数</summary>
    int[] _triggerNum = { 1, 5, 25, 50, 100 };

    /// <summary>購入ボタン</summary>
    Button _button;

    /// <summary>購入ボタンのイメージ</summary>
    Image _buttonImage;

    /// <summary>アップグレードのアイコン</summary>
    [SerializeField] private Image _iconImage;

    /// <summary>テキストのイメージ</summary>
    [SerializeField] private Image _textImage;

    /// <summary>アップグレード名のテキスト</summary>
    [SerializeField] private TextMeshProUGUI _nameText;

    /// <summary>アップグレード金額のテキスト</summary>
    [SerializeField] private TextMeshProUGUI _priceText;

    /// <summary>変更先のスプライト</summary>
    [Header("新しいスプライト")]
    [SerializeField] private Sprite[] _iconSprites;

    void Start()
    {
        // 初期設定
        SetUp();
    }

    void Update()
    {
        // 販売条件の確認
        CheckEnablement();
    }

    /// <summary>初期設定</summary>
    void SetUp()
    {
        // ゲーム管理クラスのインスタンスを登録
        _gameManager = GameManager.Instance;
        // 基本購入金額に対応する施設クラスの基本購入金額を代入する
        _basePrice = _facility._basePrice;
        // ボタンUI
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        // テキストUI
        _nameText.text = $"{_facility._name}アップグレード";
        SetPriceText(_basePrice * _priceRate[0]);
        // アイコン
        _iconImage.sprite = _iconSprites[0];
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

    /// <summary>アップグレードの購入時に呼ばれる処理</summary>
    void Purchase()
    {
        // アップグレード金額分のクッキーを減少させる
        Payment();
        // アップグレードのアイコンを更新
        _iconImage.sprite = _iconSprites[_facility.GetUpgradeNum()];
        // 施設クラスのアイコンを更新
        _facility._iconImage.sprite = _iconSprites[_facility.GetUpgradeNum()];
        // 施設クラスのアップグレード所持数を増加させる
        _facility.AddUpgradeNum();
        // アップグレードを全て購入している場合、アップグレードを無効にする
        if (IsUpgradeCompleted()) gameObject.SetActive(false);
        // 価格テキストを"次の値段"に更新
        _priceText.text = $"{CalPrice()} C";
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

    /// <summary>アップグレードの値段を計算する</summary>
    ulong CalPrice()
    {
        return _basePrice * _priceRate[_facility.GetUpgradeNum()];
    }

    /// <summary>アップグレードの値段だけクッキーを減少させる</summary>
    void Payment()
    {
        _gameManager.SubtractCookie(CalPrice());
    }

    /// <summary>販売条件を満たしているかを確認する</summary>
    void CheckEnablement()
    {
        if (_facility.GetFacilityNum() >= _triggerNum[_facility.GetUpgradeNum()])
        {
            SetButtonEnablement(2);
        }
        else SetButtonEnablement(0);
    }

    /// <summary>アップグレードを全て買いきったどうか</summary>
    bool IsUpgradeCompleted()
    {
        if(_facility.GetUpgradeNum() == 5)
        {
            return true;
        }
        else return false;
    }

    /// <summary>転生時に呼ばれる処理</summary>
    public void Reset()
    {
        // 基本購入金額に施設クラスの基本購入金額を代入
        _basePrice = _facility._basePrice;
        // 施設アイコンを初期化
        _iconImage.sprite = _iconSprites[0];
        // 価格テキストを初期化
        SetPriceText(_basePrice);
    }
}
