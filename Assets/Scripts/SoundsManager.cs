using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance;
    // [HideInInspector] public MusicLoader musicLoader;
    [HideInInspector] public SoundsLoader soundsLoader;

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
        //  musicLoader = GetComponentInChildren<MusicLoader>();
        //  musicLoader.Init();
         soundsLoader = GetComponentInChildren<SoundsLoader>();
         soundsLoader.Init();
    }
}
