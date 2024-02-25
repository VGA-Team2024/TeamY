using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Refund : MonoBehaviour
{
    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先のイメージ</summary>
    Image _image;

    /// <summary>施設リストのテキスト</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>子オブジェクトのイメージ</summary>
    [SerializeField] Image _childImage;

    /// <summary>リソース管理クラスのインスタンス</summary>
    ResourceManager _resourceManager;

    /// <summary>売却する施設</summary>
    [SerializeField] Facility _facility;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // クリック時のイベントを設定
        _button.onClick.AddListener(RefundUpdate);
    }

    private void Update()
    {
        // 施設の所持数が0の場合、払い戻しボタンを無効化する。
        if(_facility._ownedNum == 0)
        {
            _button.enabled = false;
            _image.color = new Color(1, 1, 1, 0.25f);
            _childImage.color = new Color(1, 1, 1, 0.25f);
            _facilityText.color = new Color(0, 0, 0, 0.25f);
        }
        else
        {
            _button.enabled = true;
            _image.color = new Color(1, 1, 1, 1);
            _childImage.color = new Color(1, 1, 1, 1);
            _facilityText.color = new Color(0, 0, 0, 1);
        }
    }

    void RefundUpdate()
    {
        // 購入金額の3分の2を払戻す
        _resourceManager.AddResource(CalRefundPrice());

        // 購入数を更新
        _facility._ownedNum -= 1;

        // 購入倍率を更新
        _facility._currentMultiplier /= _facility._baseMultiplier;

        // 購入金額を更新
        _facility._currentPrice = (ulong)(_facility._basePrice * _facility._currentMultiplier);

        // テキストを更新
        _facility._priceText.text = $"{_facility._currentPrice} C";
        _facilityText.text = $"{_facility._name}　×{_facility._ownedNum}";

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
