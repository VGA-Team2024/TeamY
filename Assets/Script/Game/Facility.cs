using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Facility : MonoBehaviour
{
    /// <summary>��{���\�[�X���Y��</summary>
    [SerializeField] float _baseCPS = 0;

    /// <summary>���\�[�X���Y��</summary>
    float _cps = 0;

    /// <summary>��{�w�����z</summary>
    [SerializeField] public ulong _basePrice = 0;

    /// <summary>���݂̍w�����z</summary>
    public ulong _currentPrice = 0;

    /// <summary>��{�w���{��</summary>
    [SerializeField] public  float _baseMultiplier = 1.15f;

    /// <summary>���݂̍w���{��</summary>
    public float _currentMultiplier = 1;

    /// <summary>���݂̃A�b�v�O���[�h�{��</summary>
    public ulong _currentUpgradeFactor = 1;

    /// <summary>���݂̍w����</summary>
    public ulong _ownedNum = 0;

    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̃C���[�W</summary>
    Image _image;

    /// <summary>�A�^�b�`��̃e�L�X�g</summary>
    [SerializeField] public TextMeshProUGUI _priceText;

    /// <summary>�{�݃��X�g�̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>�{�݂̖��O</summary>
    [SerializeField] public string _name;

    /// <summary>�^�C�}�[�ϐ�</summary>
    float _timer = 0;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    ResourceManager _resourceManager;

    /// <summary>�l�i�L�^�p�̃��X�g</summary>
    public List<ulong> _priceList = new List<ulong>();

    void Start()
    {
        // ���݂̍w�����z����{�w�����z�ɏ�����
        _currentPrice = _basePrice;

        _resourceManager = ResourceManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // �e�L�X�g��������
        _priceText.text = $"{_currentPrice} C";
        _facilityText.text = $"{_name}�@�~{_ownedNum}";

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpdatePrice);
    }

    void Update()
    {
        // ���\�[�X�ʂ����݂̍w�����z�ɖ����Ȃ��ꍇ�A�{�^���𔼓���������B
        if(_resourceManager.GetResource() < _currentPrice)
        {
            _button.enabled = false;
            _image.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            _button.enabled = true;
            _image.color = new Color(1, 1, 1, 1);
        }
        // 1�b���ƂɃ��\�[�X�𑝉�������B
        _timer += Time.deltaTime;

        if(_timer > 1)
        {
            _timer = 0;
            _resourceManager.AddResource(CalTotalCpS());
        }
    }

    /// <summary>CpS�̑��ʂ��v�Z���郁�\�b�h</summary>
    ulong CalTotalCpS()
    {
        _cps = _baseCPS * _currentUpgradeFactor;
        return (ulong)(_cps * _ownedNum);
    }

    /// <summary>�w�����𑝉������郁�\�b�h</summary>
    void AddOwnedNum()
    {
        _ownedNum++;
    }

    /// <summary>���̍w���{�����v�Z���郁�\�b�h</summary>
    void CalNextMultiplier()
    {
        _currentMultiplier *= _baseMultiplier;
    }

    /// <summary>���݂̍w�����z���v�Z���郁�\�b�h</summary>
    void CalCurrentPrice()
    {
        _currentPrice = (ulong)(_basePrice * _currentMultiplier);
    }

    /// <summary>�w�����z���X�V���郁�\�b�h�B�w��������ɋ��z���X�V���Ă���B</summary>
    void UpdatePrice()
    {
        // �w�����𑝉�
        AddOwnedNum();

        // ���p�p�ɒl�i���L�^
        _priceList.Add(_currentPrice);

        // ���݂̍w�����z�������\�[�X������
        _resourceManager.SubtractResource(_currentPrice);

        // �w���{�����X�V
        CalNextMultiplier();

        // �w�����z���X�V
        CalCurrentPrice();

        // �e�L�X�g���X�V
        _priceText.text = $"{_currentPrice} C";
        _facilityText.text = $"{_name}�@�~{_ownedNum}";
    }
}