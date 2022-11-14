using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour {

    private static GameAssets _I;

    public static GameAssets Instance {
        get{
            if (_I == null) _I = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _I;
        }
    }

    public Transform pfTextPopUp;
    
    
}
