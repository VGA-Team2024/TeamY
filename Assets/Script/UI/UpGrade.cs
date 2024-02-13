using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpGrade : MonoBehaviour
{
    /// <summary>購入金額</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先のテキスト</summary>
    [SerializeField] TextMeshProUGUI _shopText;

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
        // クリック時のイベントを設定
        _button.onClick.AddListener(UpGradeFacility);
    }

    void Update()
    {
        // テキストを更新
        _shopText.text = $"{_name}　{_price}G";
    }

    void UpGradeFacility()
    {
        // 施設をアップグレード
        _facility._isUpGraded = true;

        // クリッカーをアップグレード
        _clicker._isUpGraded = true;

        // 現在の購入金額だけリソースを減少
        _resourceManager.SubtractResource(_price);

        // ボタンを消去
        Destroy(gameObject);
    }
}