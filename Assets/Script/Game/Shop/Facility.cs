using UnityEngine;

/// <summary>{ÝNX</summary>
public class Facility : MonoBehaviour
{
    /// <summary>î{NbL[¶YÊ</summary>
    [Header("î{NbL[¶YÊ")]
    [SerializeField] float _baseCpS;

    ///<summary>»ÝÌNbL[¶YÊ</summary>
    float _currentCpS;

    ///<summary>î{wüàz</summary>
    [Header("î{wüàz")]
    [SerializeField] ulong _basePrice;

    ///<summary>»ÝÌwüàz</summary>
    ulong _currentPrice;

    ///<summary>wü²ÆÌwüàzÌã¸{¦</summary>
    const float _priceRate = 1.15f;

    ///<summary>AbvO[hÉæéCpSÌã¸{¦</summary>
    const float _upgradeRate = 2f;

    ///<summary>»ÝÌ</summary>
    int _facilityNum;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
