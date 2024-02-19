using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public float _autoSaveTime = 60f;
    float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _autoSaveTime)
        {
            SaveManager.instance.Save();
            _timer = 0;
        }
    }
}
