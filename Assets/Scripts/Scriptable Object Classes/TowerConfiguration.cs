using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfiguration.asset",
    menuName = "TowerDefense/Tower Configuration",
    order = 2)
]
public class TowerConfiguration : ScriptableObject {
    public Sprite TowerImage;
    public int Price;
    public GameObject TowerPrefab;
}
