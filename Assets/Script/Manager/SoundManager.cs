using UnityEngine;

// AudioSourceをアタッチ
[RequireComponent(typeof(AudioSource))]

/// <summary>SE・BGMを管理するクラス</summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>施設の購入ボタンで再生するSE</summary>
    [Header("施設")]
    [SerializeField] AudioClip[] _facilitySound = null;

    /// <summary>アップグレードの購入ボタンで再生するSE</summary>
    [Header("アップグレード")]
    [SerializeField] AudioClip[] _upgradeSound = null;

    /// <summary>その他のボタンで再生するSE</summary>
    [Header("その他")]
    [SerializeField] AudioClip[] _otherSound = null;

    /// <summary>オーディオソース</summary>
    AudioSource _audioSource;

    /// <summary>インスタンス</summary>
    public static SoundManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>施設ボタンのSEを再生するメソッド。各ボタンから呼び出される。</summary>
    /// <param name="soundNum">AudioClip配列のインデックス。 0 = カーソル, 1 = グランマ, 2 = 銃, 3 = 指輪, 4 = 剣</param>
    public void PlayFacilitySound(int soundNum)
    {
        _audioSource.PlayOneShot(_facilitySound[soundNum]);
    }

    /// <summary>アップグレードボタンのSEを再生するメソッド。各ボタンから呼び出される。</summary>
    /// <param name="soundNum">AudioClip配列のインデックス。 0 = カーソル, 1 = グランマ, 2 = 銃, 3 = 指輪, 4 = 剣</param>
    public void PlayUpgradeSound(int soundNum)
    {
        _audioSource.PlayOneShot(_upgradeSound[soundNum]);
    }

    /// <summary>その他のSEを再生するメソッド。各ボタンから呼び出される。</summary>
    /// <param name="soundNum">AudioClip配列のインデックス。 0 = クリッカー（クリック）, 1 = クリッカー（マウスオーバー）, 2 = パネル切り替え, 3 = ストーリー進行, 4 = 転生, 5 = 実績</param>
    public void PlayOtherSound(int soundNum)
    {
        _audioSource.PlayOneShot(_otherSound[soundNum]);
    }
}
