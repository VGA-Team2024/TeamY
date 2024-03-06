using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>実績を管理するクラス</summary>
public class AchievementManager : MonoBehaviour
{
    /// <summary>実績アイコン</summary>
    [Header("実績のアイコン")]
    [SerializeField] public Sprite[] _achievementIcon;

    /// <summary>実績名</summary>
    [Header("実績の名前")]
    [SerializeField] public string[] _achievementName;

    /// <summary>実績ウィンドウのアイコン</summary>
    [Header("実績ウィンドウのアイコン")] 
    [SerializeField] private Image _windowImage;

    /// <summary>実績ウィンドウのテキスト</summary>
    [Header("実績ウィンドウのテキスト")] 
    [SerializeField] TextMeshProUGUI _windowText;

    /// <summary>実績ウィンドウのオブジェクト</summary>
    [Header("実績ウィンドウ")] 
    [SerializeField] GameObject _achievementWindow;

    /// <summary>インスタンス</summary>
    public static AchievementManager Instance { get; private set; }

    /// <summary>イベント管理クラス</summary>
    EventManager _eventManager = null;

    /// <summary>サウンド管理クラス</summary>
    SoundManager _soundManager = null;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // 実績ウィンドウを無効にする
        _achievementWindow.SetActive(false);
        // 各クラスのインスタンスを取得
        _eventManager = EventManager.Instance;
        _soundManager = SoundManager.Instance;
    }

    /// <summary>実績を達成した際に呼ばれる共通処理</summary>
    /// <param name="num">実績の識別番号</param>
    public void Achieve(int num)
    {
        // 実績ウィンドウを有効にする
        _achievementWindow.SetActive(true);
        // 実績ウィンドウのアイコンを更新する
        _windowImage.sprite = _achievementIcon[num];
        // 実績ウィンドウのテキストを更新する
        _windowText.text = _achievementName[num];
        // 実績ウィンドウを無効にする
        SetInactive();
    }

    /// <summary>実績達成時のSEを再生する</summary>
    public void PlayAchievementSound()
    {
        _soundManager.PlayOtherSound(5);
    }

    /// <summary>実績：「アポカリプス」</summary>
    public void Apocalypse()
    {
        Achieve(0);
        PlayAchievementSound();
    }

    /// <summary>実績：「ババアグッバイ」</summary>
    public void GoodByeGrandma()
    {
        Achieve(1);
        PlayAchievementSound();
    }

    /// <summary>実績：「ラッキー！」</summary>
    public void Lucky()
    {
        Achieve(2);
        PlayAchievementSound();
    }

    /// <summary>実績：「転生者」</summary>
    public void ReLife()
    {
        Achieve(3);
        PlayAchievementSound();
    }

    /// <summary>実績：「世界崩壊」</summary>
    public void WorldEnd()
    {
        Achieve(4);
        PlayAchievementSound();
    }

    /// <summary>実績：「無限ループ」</summary>
    public void InfinityLoop()
    {
        Achieve(5);
        PlayAchievementSound();
    }

    /// <summary>実績：「すべてを知る者」</summary>
    public void Almighty()
    {
        Achieve(6);
        PlayAchievementSound();
    }

    /// <summary>実績：「全クリ」</summary>
    public void Complete()
    {
        Achieve(7);
        PlayAchievementSound();
    }

    /// <summary>実績ウィンドウを無効にする</summary>
    public IEnumerator SetInactive()
    {
        // 5秒待つ
        yield return new WaitForSeconds(5);
        _achievementWindow.SetActive(false);
    }
}
