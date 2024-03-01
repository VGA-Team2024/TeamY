using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Refund : MonoBehaviour
{
    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̃C���[�W</summary>
    Image _buttonImage;

    /// <summary>�{�݃��X�g�̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _nameText;

    /// <summary>�{�݃��X�g�̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _priceText;

    /// <summary>�A�C�R���̃C���[�W</summary>
    [SerializeField] Image _iconImage;

    /// <summary>�e�L�X�g�̃C���[�W</summary>
    [SerializeField] Image _textImage;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    GameManager _gameManager;

    /// <summary>���p����{��</summary>
    [SerializeField] Facility _facility;

    void Start()
    {
        _gameManager = GameManager.Instance;
        _button = gameObject.GetComponent<Button>();
        _buttonImage = gameObject.GetComponent<Image>();

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(RefundUpdate);
    }
    private void OnEnable()
    {
        _priceText.text = $"�~{_facility._ownedNum}";
    }

    private void Update()
    {
        // �{�݂̏�������0�̏ꍇ�A�����߂��{�^���𖳌�������B
        if(_facility._ownedNum == 0)
        {
            // �{�^��
            _button.enabled = false;
            // �{�^���C���[�W
            _buttonImage.color = new Color(1, 1, 1, 0.25f);
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
            _buttonImage.color = new Color(1, 1, 1, 1);
            // ���O�e�L�X�g
            _priceText.color = new Color(0, 0, 0, 1);
            // ���i�e�L�X�g
            _nameText.color = new Color(0, 0, 0, 1);
            // �A�C�R��
            _iconImage.color = new Color(1, 1, 1, 1);
            // �e�L�X�g�C���[�W
            _textImage.color = new Color(1, 1, 1, 1);
        }
    }

    void RefundUpdate()
    {
        // �w�����z��3����2�𕥖߂�
        _gameManager.AddResource(CalRefundPrice());

        // �w�������X�V
        _facility._ownedNum -= 1;

        // �w���{�����X�V
        _facility._currentMultiplier /= _facility._baseMultiplier;

        // �w�����z���X�V
        _facility._currentPrice = (ulong)(_facility._basePrice * _facility._currentMultiplier);

        // �e�L�X�g���X�V
        _facility._priceText.text = $"{_facility._currentPrice} C";
        _priceText.text = $"�~{_facility._ownedNum}";

        // �w�����z���X�g���X�V
        _facility._priceList.RemoveAt(_facility._priceList.Count - 1);
    }

    ulong CalRefundPrice()
    {
        ulong currentPrice = _facility._priceList[_facility._priceList.Count - 1];
        ulong refundPrice = currentPrice * 2 / 3;
        return refundPrice;
    }
}
