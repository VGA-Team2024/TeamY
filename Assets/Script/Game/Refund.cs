using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Refund : MonoBehaviour
{
    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̃C���[�W</summary>
    Image _image;

    /// <summary>�{�݃��X�g�̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _facilityText;

    /// <summary>�q�I�u�W�F�N�g�̃C���[�W</summary>
    [SerializeField] Image _childImage;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    ResourceManager _resourceManager;

    /// <summary>���p����{��</summary>
    [SerializeField] Facility _facility;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        
        _button = gameObject.GetComponent<Button>();
        _image = gameObject.GetComponent<Image>();

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(RefundUpdate);
    }

    private void Update()
    {
        // �{�݂̏�������0�̏ꍇ�A�����߂��{�^���𖳌�������B
        if(_facility._ownedNum == 0)
        {
            _button.enabled = false;
            _image.color = new Color(1, 1, 1, 0.25f);
            _childImage.color = new Color(1, 1, 1, 0.25f);
            _facilityText.color = new Color(0, 0, 0, 0.25f);
        }
        else
        {
            _button.enabled = true;
            _image.color = new Color(1, 1, 1, 1);
            _childImage.color = new Color(1, 1, 1, 1);
            _facilityText.color = new Color(0, 0, 0, 1);
        }
    }

    void RefundUpdate()
    {
        // �w�����z��3����2�𕥖߂�
        _resourceManager.AddResource(CalRefundPrice());

        // �w�������X�V
        _facility._ownedNum -= 1;

        // �w���{�����X�V
        _facility._currentMultiplier /= _facility._baseMultiplier;

        // �w�����z���X�V
        _facility._currentPrice = (ulong)(_facility._basePrice * _facility._currentMultiplier);

        // �e�L�X�g���X�V
        _facility._priceText.text = $"{_facility._currentPrice} C";
        _facilityText.text = $"{_facility._name}�@�~{_facility._ownedNum}";

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
