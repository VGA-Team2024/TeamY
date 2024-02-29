using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour, IPointerClickHandler
{
    /// <summary>基本リソース生産量</summary>
    [SerializeField] float _baseCPS = 0;

    /// <summary>リソース生産量</summary>
    float _cps = 0;

    /// <summary>現在のアップグレード倍率</summary>
    public ulong _currentUpgradeFactor = 1;

    /// <summary>リソース管理クラス</summary>
    ResourceManager _resourceManager = null;

    /// <summary>オーディオ管理クラス</summary>
    SoundManager _soundManager = null;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _soundManager = SoundManager.Instance;
    }
    /// <summary>クリック時の処理</summary>
    void OnClick()
    {
        _resourceManager.AddResource(CalCpS());
        _soundManager.PlayOtherSound(0);
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
    /// <summary>RPSを計算するメソッド</summary>
    ulong CalCpS()
    {
        _cps = _baseCPS * _currentUpgradeFactor;
        return (ulong)_cps;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
