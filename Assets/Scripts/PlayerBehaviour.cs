using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] public RoadGenerator RoadGenerator;
    [SerializeField] public PlayerController PlayerController;
    [SerializeField] public GameManager GameManager;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _effectPrefab;


    public void StartFatalCollision()
    {
        SoundsManager.Instance.soundsLoader.StopMusic();
        GameManager.isMusic = false;
        _animator.SetTrigger("Drunk Idle");
        SoundsManager.Instance.soundsLoader.PlaySounds(2);// YouLose
        RoadGenerator.currentSpeed = 0;
        Instantiate(_effectPrefab, transform.position, transform.rotation);
        StartCoroutine(StopFallingCoroutine());
    }

    IEnumerator StopFallingCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.DecrementLifesPlayer();
    }
}
