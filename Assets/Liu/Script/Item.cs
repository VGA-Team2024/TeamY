using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    [Header("名前"),SerializeField] 
    bool _name ; // アイテムの名前
    // アイテムの名前

    // アイテムの価格
    [Header("価格")] public int Price; // アイテムの価格

    // アイテムの攻撃力
    [Header("攻撃力")] public float ATK; // アイテムの攻撃力

    // アイテムのクールダウン時間
}