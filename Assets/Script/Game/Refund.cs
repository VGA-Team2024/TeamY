using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Refund : MonoBehaviour
{
    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先のイメージ</summary>
    Image _buttonImage;

    /// <summary>施設リストのテキスト</summary>
    [SerializeField] TextMeshProUGUI _nameText;

    /// <summary>施設リストのテキスト</summary>
    [SerializeField] TextMeshProUGUI _priceText;

    /// <summary>アイコンのイメージ</summary>
    [SerializeField] Image _iconImage;

    /// <summary>テキストのイメージ</summary>
    [SerializeField] Image _textImage;

    /// <summary>リソース管理クラスのインスタンス</summary>
    GameManager _gameManager;

    /// <summary>売却する施設</summary>
    [SerializeField] Facility _facility;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _buttonImage = gameObject.GetComponent<Image>();

        // クリック時のイベントを設定
        _button.onClick.AddListener(RefundUpdate);
    }
    private void OnEnable()
    {
        _priceText.text = $"×{_facility._ownedNum}";
    }

    private void Update()
    {
        // 施設の所持数が0の場合、払い戻しボタンを無効化する。
        if(_facility._ownedNum == 0)
        {
            // ボタン
            _button.enabled = false;
            // ボタンイメージ
            _buttonImage.color = new Color(1, 1, 1, 0.25f);
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
            _buttonImage.color = new Color(1, 1, 1, 1);
            // 名前テキスト
            _priceText.color = new Color(0, 0, 0, 1);
            // 価格テキスト
            _nameText.color = new Color(0, 0, 0, 1);
            // アイコン
            _iconImage.color = new Color(1, 1, 1, 1);
            // テキストイメージ
            _textImage.color = new Color(1, 1, 1, 1);
        }
    }

    void RefundUpdate()
    {
        // 購入金額の3分の2を払戻す
        _gameManager.AddResource(CalRefundPrice());

        // 購入数を更新
        _facility._ownedNum -= 1;

        // 購入倍率を更新
        _facility._currentMultiplier /= _facility._baseMultiplier;

        // 購入金額を更新
        _facility._currentPrice = (ulong)(_facility._basePrice * _facility._currentMultiplier);

        // テキストを更新
        _facility._priceText.text = $"{_facility._currentPrice} C";
        _priceText.text = $"×{_facility._ownedNum}";

        // 購入金額リストを更新
        _facility._priceList.RemoveAt(_facility._priceList.Count - 1);
    }

    ulong CalRefundPrice()
    {
        ulong currentPrice = _facility._priceList[_facility._priceList.Count - 1];
        ulong refundPrice = currentPrice * 2 / 3;
        return refundPrice;
    }
}
