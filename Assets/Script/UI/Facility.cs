using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Facility : MonoBehaviour
{
    /// <summary>��{���\�[�X���Y��</summary>
    [SerializeField] float _baseRPS = 0;

    /// <summary>���\�[�X���Y��</summary>
    float _rps = 0;

    /// <summary>��{�w�����z</summary>
    [SerializeField] ulong _basePrice = 0;

    /// <summary>���݂̍w�����z</summary>
    ulong _currentPrice = 0;

    /// <summary>��{�w���{��</summary>
    [SerializeField] float _baseMultiplier = 1.15f;

    /// <summary>���݂̍w���{��</summary>
    float _currentMultiplier = 1;

    /// <summary>���݂̍w����</summary>
    public ulong _ownedNum = 0;

    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̃C���[�W</summary>
    Image _image;

    /// <summary>�A�^�b�`��̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _shopText;

    /// <summary>�{�݃��X�g�̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>�A�C�e���̖��O</summary>
    [SerializeField] string _name;

    /// <summary>�A�b�v�O���[�h�̔���</summary>
    [SerializeField] public bool _isUpGraded = false;

    /// <summary>�^�C�}�[�ϐ�</summary>
    float _timer = 0;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    ResourceManager _resourceManager;

    void Start()
    {
        // �w�����z��������
        _currentPrice = _basePrice;
        _resourceManager = ResourceManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // �e�L�X�g��������
        _shopText.text = $"{_name}�@{_currentPrice}G";
        _facilityText.text = $"{_name}�@�~{_ownedNum}";

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpdatePrice);
    }

    void Update()
    {
        // ���\�[�X�ʂ����݂̍w�����z�ɖ����Ȃ��ꍇ
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
        // 1�b���ƂɃ��\�[�X����
        _timer += Time.deltaTime;

        if(_timer > 1)
        {
            _timer = 0;
            _resourceManager.AddResource(CalTotalRPS());
        }
    }

    /// <summary>RPS�̑��ʂ��v�Z���郁�\�b�h</summary>
    ulong CalTotalRPS()
    {
        if(_isUpGraded)
        {
            _rps = _baseRPS * 2;
        }
        else
        {
            _rps = _baseRPS * 1;
        }
        return (ulong)(_rps * _ownedNum);
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

    /// <summary>���݂̍w�����z���X�V���A�w�����z�����\�[�X�����炷���\�b�h</summary>
    void UpdatePrice()
    {
        // �w�����𑝉�
        AddOwnedNum();

        // ���݂̍w�����z�������\�[�X������
        _resourceManager.SubtractResource(_currentPrice);

        // �w���{�����X�V
        CalNextMultiplier();

        // �w�����z���X�V
        CalCurrentPrice();

        // �e�L�X�g���X�V
        _shopText.text = $"{_name}�@{_currentPrice}G";
        _facilityText.text = $"{_name}�@�~{_ownedNum}";
    }
}
