using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private readonly int _hashRForwardAnimation = Animator.StringToHash("RollingForward");
    private readonly int _hashRBackwardsAnimation = Animator.StringToHash("RollingBackwards");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartRolling()
    {
        _animator.SetBool(_hashRForwardAnimation, true);
    }

    public void StopRolling()
    {
        _animator.SetBool(_hashRForwardAnimation, false);
    }

    public void StartRollingBackwards()
    {
        _animator.SetBool(_hashRBackwardsAnimation, true);
    }
    public void StopRollingBackwards()
    {
        _animator.SetBool(_hashRBackwardsAnimation, false);
    }
}
