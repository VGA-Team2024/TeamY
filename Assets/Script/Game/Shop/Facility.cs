using UnityEngine;

/// <summary>�{�݃N���X</summary>
public class Facility : MonoBehaviour
{
    /// <summary>��{�N�b�L�[���Y��</summary>
    [Header("��{�N�b�L�[���Y��")]
    [SerializeField] float _baseCpS;

    ///<summary>���݂̃N�b�L�[���Y��</summary>
    float _currentCpS;

    ///<summary>��{�w�����z</summary>
    [Header("��{�w�����z")]
    [SerializeField] ulong _basePrice;

    ///<summary>���݂̍w�����z</summary>
    ulong _currentPrice;

    ///<summary>�w�����Ƃ̍w�����z�̏㏸�{��</summary>
    const float _priceRate = 1.15f;

    ///<summary>�A�b�v�O���[�h�ɂ��CpS�̏㏸�{��</summary>
    const float _upgradeRate = 2f;

    ///<summary>���݂̏�����</summary>
    int _facilityNum;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
