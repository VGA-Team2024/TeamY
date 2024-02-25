using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    /// <summary>�w�����z</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̉��i�e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _priceText;

    /// <summary>�A�b�v�O���[�h����{��</summary>
    [SerializeField] Facility _facility;

    /// <summary>�A�b�v�O���[�h����N���b�J�[</summary>
    [SerializeField] Clicker _clicker;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    ResourceManager _resourceManager;

    /// <summary>�ύX���̃C���[�W</summary>
    [SerializeField] Image _facilityImage;

    /// <summary>�ύX��̃C���[�W</summary>
    [SerializeField] Sprite _newSprite;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _button = gameObject.GetComponent<Button>();

        // �e�L�X�g���X�V
        _priceText.text = $"{_price} C";

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpgradeFacility);
    }

    void UpgradeFacility()
    {
        // �{�݂��A�b�v�O���[�h
        if(_facility)
        _facility._currentUpgradeFactor *= 2;

        // �N���b�J�[���A�b�v�O���[�h
        if(_clicker)
        _clicker._currentUpgradeFactor *= 2;

        // �A�C�R�����X�V
        _facilityImage.sprite = _newSprite;

        // �w�����z�������\�[�X������
        _resourceManager.SubtractResource(_price);

        // �{�^��������
        Destroy(gameObject);
    }
}