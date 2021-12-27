using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private StateMachine _stateMachine;
    private Animator _animator;
    private AudioSource _audioSource;

    public Rigidbody2D Rigidbody => _rigidbody;
    public StateMachine StateMachine => _stateMachine;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _stateMachine = GetComponent<StateMachine>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Debug.Log(_stateMachine.CurrentState.GetType());
    }

    public void SetVelocity(Vector3 direction)
    {
        _rigidbody.velocity = _speed * direction;
    }

    public void StartAnimation(string name)
    {
        _animator.Play(name);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void SetClipAndPlay(AudioClip clip) 
    {
        _audioSource.clip = clip;
        PlayAudio();
    }

    private void PlayAudio()
    {
        _audioSource.Play();
    }

}
