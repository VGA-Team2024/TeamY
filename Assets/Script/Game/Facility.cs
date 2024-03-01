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

    /// <summary>�A�C�R���̃C���[�W</summary>
    [SerializeField] Image _iconImage;

    /// <summary>�e�L�X�g�̃C���[�W</summary>
    [SerializeField] Image _textImage;

    /// <summary>�A�^�b�`��̉��i�e�L�X�g</summary>
    [SerializeField] public TextMeshProUGUI _priceText;

    /// <summary>�A�^�b�`��̖��O�e�L�X�g</summary>
    [SerializeField] public TextMeshProUGUI _nameText;

    /// <summary>�{�݃��X�g�̃I�u�W�F�N�g</summary>
    [SerializeField] public GameObject _ownedFacility;

    /// <summary>�A�^�b�`��̖��O�e�L�X�g</summary>
    [SerializeField] public TextMeshProUGUI _ownedPriceText;

    /// <summary>�{�݂̖��O</summary>
    [SerializeField] public string _name;

    /// <summary>�^�C�}�[�ϐ�</summary>
    float _timer = 0;

    /// <summary>���\�L�p�ϐ�</summary>
    string _PS;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    GameManager _gameManager;

    /// <summary>�l�i�L�^�p�̃��X�g</summary>
    public List<ulong> _priceList = new List<ulong>();

    void Start()
    {
        // ���݂̍w�����z����{�w�����z�ɏ�����
        _currentPrice = _basePrice;

        _gameManager = GameManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // �e�L�X�g��������
        _priceText.text = $"{_currentPrice} C";

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpdatePrice);

        // �����{�݃��X�g���\���ɂ���B
        _ownedFacility.SetActive(false);

        // �ŏ��͖�����
        gameObject.SetActive(false);
    }

    void Update()
    {
        // ���\�[�X�ʂ����݂̍w�����z�ɖ����Ȃ��ꍇ�A�{�^���𔼓���������B
        if(_gameManager.GetResource() < _currentPrice)
        {
            // �{�^��
            _button.enabled = false;
            // �{�^���C���[�W
            _image.color = new Color(1, 1, 1, 0.25f);
            // ���O�e�L�X�g
            _priceText.color = new Color(0, 0, 0, 0.25f);
            // ���i�e�L�X�g
            _nameText.color = new Color(0, 0, 0, 0.25f);
            // �A�C�R��
            _iconImage.color = new Color(1, 1, 1, 0.25f); 
            // �e�L�X�g�C���[�W
            _textImage.color = new Color(1, 1, 1, 0.25f); 
        }
        else
        {
            // �{�^��
            _button.enabled = true;
            // �{�^���C���[�W
            _image.color = new Color(1, 1, 1, 1);
            // ���O�e�L�X�g
            _priceText.color = new Color(0, 0, 0, 1);
            // ���i�e�L�X�g
            _nameText.color = new Color(0, 0, 0, 1);
            // �A�C�R��
            _iconImage.color = new Color(1, 1, 1, 1);
            // �e�L�X�g�C���[�W
            _textImage.color = new Color(1, 1, 1, 1);
        }

        // 1�b���ƂɃ��\�[�X�𑝉�������
        _timer += Time.deltaTime;

        if (_timer >= 1.0f)
        {
            _timer = 0;
            _gameManager.AddResource(CalTotalCpS());
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
        if(_ownedNum == 0 )
        {
            _ownedFacility.SetActive(true);
        }
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
        _gameManager.SubtractResource(_currentPrice);

        // �w���{�����X�V
        CalNextMultiplier();

        // �w�����z���X�V
        CalCurrentPrice();

        // �{�݃��X�g�̃e�L�X�g���X�V
        _ownedPriceText.text = $"�~{_ownedNum}";

        // �V���b�v�̒l�i�e�L�X�g���X�V
        if(_currentPrice > 1000000000)
        {
            _PS = _currentPrice.ToString();
            _priceText.text = $"10��{_PS[2]}{_PS[3]}{_PS[4]}{_PS[5]}�� C";
        }
        else if(_currentPrice > 1000000000000)
        {
            _PS = _currentPrice.ToString();
            _priceText.text = $"1��{_PS[1]}{_PS[2]}{_PS[3]}{_PS[4]}�� C";
        }
        else
        {
            _priceText.text = $"{_currentPrice} C";
        }
    }
}
