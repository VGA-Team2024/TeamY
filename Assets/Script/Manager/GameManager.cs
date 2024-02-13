using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    /// <summary>リソースを表示するテキスト</summary>
    [SerializeField] TextMeshProUGUI _resourceText;

    /// <summary>リソース</summary>
    private ulong _currentResource = 0;

    /// <summary>リソース管理クラス</summary>
    ResourceManager _resourceManager = null;
    void Start()
    {
        _resourceManager = ResourceManager.Instance;
    }
    void Update()
    {
        // リソースを同期
        SynchronizeResource();
        // テキストを更新
        SetText();
    }

    /// <summary>リソースを同期させるメソッド</summary>
    void SynchronizeResource()
    {
        _currentResource = _resourceManager.GetResource();
    }

    /// <summary>テキストを設定するメソッド</summary>
    void SetText()
    {
        _resourceText.text = $"{_currentResource.UlongToComma()} G";
    }
}
