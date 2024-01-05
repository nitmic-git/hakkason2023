using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour {
    public EnemyDataBase enemyDataBase;
    public Dictionary<string, object> flagDictionary = new Dictionary<string, object>();
    public List<bool> IsActiveCodex = new List<bool> {true, true, true, false, true, true, true, false, true, true, true, true, true};
}
