using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void OnDestroy()
    {
        CleanUp();
    }

    public abstract void Initialize();
    public abstract void CleanUp();
}
