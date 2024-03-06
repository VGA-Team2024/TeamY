using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>基本クッキー生産量</summary>
    [Header("基本クッキー生産量")]
    [SerializeField] float _baseCpS;

    /// <summary>アップグレードによるCpSの上昇倍率</summary>
    const float _upgradeRate = 2f;

    /// <summary>現在のアップグレード所持数</summary>
    int _upgradeNum;

    /// <summary>ゲーム管理クラス</summary>
    GameManager _gameManager;

    /// <summary>オーディオ管理クラス</summary>
    SoundManager _soundManager = null;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _soundManager = SoundManager.Instance;
    }

    /// <summary>カーソルが上に来た時の処理</summary>
    public void OnEnter()
    {
        this.gameObject.transform.localScale = new Vector3(5f, 5f, 5f);
        _soundManager.PlayOtherSound(1);
    }

    /// <summary>カーソルが離れた時の処理</summary>
    public void OnExit()
    {
        this.gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
    }

    /// <summary>クリック時の処理</summary>
    void OnClick()
    {
        _gameManager.AddCookie(CalCpS());
        _soundManager.PlayOtherSound(0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    /// <summary>アップグレード倍率を乗算したCpSを計算する</summary>
    /// <returns>現在のCpS</returns>
    ulong CalCpS()
    {
        // アップグレードによるCpSの上昇倍率
        float upgradeBuff;
        // アップグレードを購入していない場合1にする
        if (_upgradeNum == 0)
        {
            upgradeBuff = 1;
        }
        else
        {
            upgradeBuff = _upgradeRate * _upgradeNum;
        }
        return (ulong)(_baseCpS * upgradeBuff);
    }
}
