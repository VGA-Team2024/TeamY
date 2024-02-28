using UnityEngine;

public class SwitchPanels : MonoBehaviour
{
    /// <summary>施設</summary>
    [SerializeField] GameObject _facilityPanel;
    /// <summary>アップグレード</summary>
    [SerializeField] GameObject _upgradePanel;
    /// <summary>切り替え用の変数</summary>
    bool _isUpgradePanelEnabled = false;
    void Start()
    {
        // アップグレードパネルを無効化
        _upgradePanel.SetActive(false);
        _facilityPanel.SetActive(true);
    }

    public void Switch()
    {
        // 施設パネルが有効化されている場合
        if(!_isUpgradePanelEnabled)
        {   
            _isUpgradePanelEnabled = true;
            _facilityPanel.SetActive(false);
            _upgradePanel.SetActive(true);
        }
        // アップグレードパネルが有効化されている場合
        else
        {
            _isUpgradePanelEnabled = false;
            _facilityPanel.SetActive(true);
            _upgradePanel.SetActive(false);
        }
    }
}
