using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;
    [HideInInspector] public SoundLoader soundLoader;

    void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() {
         soundLoader = GetComponentInChildren<SoundLoader>();
         soundLoader.Init();
    }
}
