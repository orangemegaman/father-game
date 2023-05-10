using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    [SerializeField] GameObject _effectPrefab;  
    void OnTriggerEnter(Collider other)
    {
        SoundsManager.Instance.soundsLoader.PlaySounds(1);
        FindObjectOfType<CoinManager>().AddOne();
        gameObject.SetActive(false); 
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
               
    }  
}
