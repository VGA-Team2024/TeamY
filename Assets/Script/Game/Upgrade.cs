using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    /// <summary>購入金額</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先の価格テキスト</summary>
    [SerializeField] TextMeshProUGUI _priceText;

    /// <summary>アイテムの名前</summary>
    [SerializeField] string _name;

    /// <summary>アップグレードする施設</summary>
    [SerializeField] Facility _facility;

    /// <summary>アップグレードするクリッカー</summary>
    [SerializeField] Clicker _clicker;

    /// <summary>リソース管理クラスのインスタンス</summary>
    ResourceManager _resourceManager;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _button = gameObject.GetComponent<Button>();

        // テキストを更新
        _priceText.text = $"{_price} C";

        // クリック時のイベントを設定
        _button.onClick.AddListener(UpgradeFacility);
    }

    void UpgradeFacility()
    {
        // 施設をアップグレード
        _facility._currentUpgradeFactor *= 2;

        // クリッカーをアップグレード
        _clicker._currentUpgradeFactor *= 2;

        // 購入金額だけリソースを減少
        _resourceManager.SubtractResource(_price);

        // ボタンを消去
        Destroy(gameObject);
    }
}