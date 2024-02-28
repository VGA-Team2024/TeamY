using UnityEngine;

public class SwitchPanels : MonoBehaviour
{
    /// <summary>�{��</summary>
    [SerializeField] GameObject _facilityPanel;
    /// <summary>�A�b�v�O���[�h</summary>
    [SerializeField] GameObject _upgradePanel;
    /// <summary>�؂�ւ��p�̕ϐ�</summary>
    bool _isUpgradePanelEnabled = false;
    void Start()
    {
        // �A�b�v�O���[�h�p�l���𖳌���
        _upgradePanel.SetActive(false);
        _facilityPanel.SetActive(true);
    }

    public void Switch()
    {
        // �{�݃p�l�����L��������Ă���ꍇ
        if(!_isUpgradePanelEnabled)
        {   
            _isUpgradePanelEnabled = true;
            _facilityPanel.SetActive(false);
            _upgradePanel.SetActive(true);
        }
        // �A�b�v�O���[�h�p�l�����L��������Ă���ꍇ
        else
        {
            _isUpgradePanelEnabled = false;
            _facilityPanel.SetActive(true);
            _upgradePanel.SetActive(false);
        }
    }
}
