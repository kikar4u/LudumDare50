using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourmetBehaviours : MonoBehaviour
{
    public static GourmetBehaviours instance;

    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : GourmetBehaviours");
        else
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
