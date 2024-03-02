using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>施設クラス</summary>
public class Facility : MonoBehaviour
{
    ///<summary>施設名</summary>
    [Header("施設の名前")]
    [SerializeField] string _name;

    /// <summary>基本クッキー生産量</summary>
    [Header("基本クッキー生産量")]
    [SerializeField] float _baseCpS;

    ///<summary>基本購入金額</summary>
    [Header("基本購入金額")]
    [SerializeField] ulong _basePrice;

    ///<summary>購入ごとの購入金額の上昇倍率</summary>
    const float _priceRate = 1.15f;

    ///<summary>アップグレードによるCpSの上昇倍率</summary>
    const float _upgradeRate = 2f;

    ///<summary>現在の所持数</summary>
    int _currentNum;

    ///<summary>購入ボタン</summary>
    Button _button;

    ///<summary>購入ボタンのイメージ</summary>
    Image _buttonImage;

    ///<summary>施設アイコンのイメージ</summary>
    Image _iconImage;

    ///<summary>テキストのイメージ</summary>
    Image _textImage;

    ///<summary>施設名のテキスト</summary>
    TextMeshProUGUI _nameText;

    ///<summary>施設価格のテキスト</summary>
    TextMeshProUGUI _priceText;

    ///<summary>ゲーム管理クラス</summary>
    GameManager _gameManager;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    ///<summary>データの初期化</summary>
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

    ///<summary>価格テキストを設定</summary>
    void SetPriceText(ulong price)
    {
        _priceText.text = $"{price.UlongToComma()} C";
    }

    ///<summary>施設を購入する</summary>
    void Purchase()
    {

    }

    ///<summary>購入ボタンの表示・非表示を設定する</summary>
    ///<param name="status">設定したいボタンの状態。0 = 非表示, 1 = 表示（半透明）, 2 = 表示（不透明）</param>
    void SetButtonEnablement(int status)
    {
        Color Color = new Color(1, 1, 1, 0);
        switch (status)
        {
            case 0:
                // ボタンを無効化
                _button.enabled = false;
                // 各イメージを透明化
                
                break;

            case 1:

                break;

            case 2:

                break;

            default: 
                break;
        }
    }
}
