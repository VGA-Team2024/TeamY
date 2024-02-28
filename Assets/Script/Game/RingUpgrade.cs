using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;
public class RingUpgrade : MonoBehaviour
{
    /// <summary>購入金額</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>アタッチ先のボタン</summary>
    Button _button;

    /// <summary>アタッチ先の価格テキスト</summary>
    [SerializeField] TextMeshProUGUI _priceText;

    /// <summary>アップグレードする施設</summary>
    [SerializeField] Facility _facility;

    /// <summary>リソース管理クラスのインスタンス</summary>
    ResourceManager _resourceManager;

    /// <summary>アップグレード管理クラスのインスタンス</summary>
    UpgradeManager _upgradeManager;

    /// <summary>変更元のイメージ</summary>
    [SerializeField] Image _facilityImage;

    /// <summary>変更元のイメージ</summary>
    [SerializeField] Image _listImage;

    /// <summary>変更先のイメージ</summary>
    [SerializeField] Sprite _newSprite;

    /// <summary>変更元のテキスト</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>変更元のテキスト</summary>
    [SerializeField] TextMeshProUGUI _listText;

    /// <summary>変更先のテキスト</summary>
    [SerializeField] string _newText;

    [SerializeField] TextMeshProUGUI _thisNameText;

    [SerializeField] Image _thisIcon;

    [SerializeField] Image _thisTextImage;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _upgradeManager = UpgradeManager.Instance;
        _button = gameObject.GetComponent<Button>();

        // テキストを更新
        _priceText.text = $"{_price} C";

        // クリック時のイベントを設定
        _button.onClick.AddListener(UpgradeFacility);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        // リソース量が現在の購入金額に満たない場合、ボタンを半透明化する。
        if (_resourceManager.GetResource() < _price)
        {
            // ボタン
            _button.enabled = false;
            // ボタンイメージ
            GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
            // 名前テキスト
            _priceText.color = new Color(0, 0, 0, 0.25f);
            // 価格テキスト
            _thisNameText.color = new Color(0, 0, 0, 0.25f);
            // アイコン
            _thisIcon.color = new Color(1, 1, 1, 0.25f);
            // テキストイメージ
            _thisTextImage.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            // ボタン
            _button.enabled = true;
            // ボタンイメージ
            GetComponent<Image>().color = new Color(1, 1, 1, 1);
            // 名前テキスト
            _priceText.color = new Color(0, 0, 0, 1);
            // 価格テキスト
            _thisNameText.color = new Color(0, 0, 0, 1);
            // アイコン
            _thisIcon.color = new Color(1f, 1f, 1f, 1f);
            // テキストイメージ
            _thisTextImage.color = new Color(1, 1, 1, 1);
        }
    }

    void UpgradeFacility()
    {
        // 施設をアップグレード
        if (_facility)
            _facility._currentUpgradeFactor *= 2;

        // アイコンを更新
        _facilityImage.sprite = _newSprite;
        _listImage.sprite = _newSprite;

        // テキストを更新
        _facilityText.text = _newText;
        _listText.text = _newText;

        // 購入金額だけリソースを減少
        _resourceManager.SubtractResource(_price);

        if (_upgradeManager._ringUpgradeNum <= 3)
        {
            _upgradeManager._ringUpgradeNum++;
        }

        _upgradeManager._isRingUGAllowed = false;

        // ボタンを消去
        gameObject.SetActive(false);
    }
}