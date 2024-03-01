using UnityEngine;

/// <summary>施設クラス</summary>
public class Facility : MonoBehaviour
{
    /// <summary>基本クッキー生産量</summary>
    [Header("基本クッキー生産量")]
    [SerializeField] float _baseCpS;

    ///<summary>現在のクッキー生産量</summary>
    float _currentCpS;

    ///<summary>基本購入金額</summary>
    [Header("基本購入金額")]
    [SerializeField] ulong _basePrice;

    ///<summary>現在の購入金額</summary>
    ulong _currentPrice;

    ///<summary>購入ごとの購入金額の上昇倍率</summary>
    const float _priceRate = 1.15f;

    ///<summary>アップグレードによるCpSの上昇倍率</summary>
    const float _upgradeRate = 2f;

    ///<summary>現在の所持数</summary>
    int _facilityNum;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
