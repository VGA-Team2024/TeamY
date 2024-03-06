using TMPro;
using UnityEngine;

/// <summary>ゲーム全体を管理するクラス</summary>
public class GameManager : MonoBehaviour
{
    /// <summary>インスタンス</summary>
    public static GameManager Instance { get; set; }

    /// <summary>現在のクッキー量を表示するテキスト</summary>
    [SerializeField] TextMeshProUGUI _cookieText;

    /// <summary>現在のリソース量</summary>
    private ulong _resource = 10000000000;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>リソースを取得する</summary>
    public ulong GetCookie()
    {
        return _resource;
    }

    /// <summary>リソースを設定するメソッド</summary>
    /// <param name="value">設定後のリソース量</param>
    public void SetCookie(ulong value)
    {
        _resource = value;
    }

    /// <summary>クッキーを増加させる</summary>
    /// <param name="value">増加させるクッキーの量</param>
    public void AddCookie(ulong value)
    {
        SetCookie(GetCookie() + value);
        // テキストを更新
        _cookieText.text = $"{_resource.UlongToComma()} C";
    }

    /// <summary>クッキーを減少させる</summary>
    /// <param name="value">減少させるクッキーの量</param>
    public void SubtractCookie(ulong value)
    {
        SetCookie(GetCookie() - value);
        // テキストを更新
        _cookieText.text = $"{_resource.UlongToComma()} C";
    }
}
