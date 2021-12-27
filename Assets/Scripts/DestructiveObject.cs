using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class DestructiveObject : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private AudioClip _damageAudioClip;
    [SerializeField] private AudioClip _destructionAudioClip;

    private SpriteRenderer _renderer;
    private Animator _animator;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;
    private int _currentIndexSprite;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();

        _currentIndexSprite = 0;
    }

    public void ApplyDamage()
    {
        SetAudioAndPlay(_damageAudioClip);
        ChangeSprite();
        _health--;

        if (_health <= 0)
            Destruction();
    }

    private void ChangeSprite()
    {
        if(_currentIndexSprite < _sprites.Count)
            _renderer.sprite = _sprites[_currentIndexSprite];
        _currentIndexSprite++;
    }

    public void Destruction()
    {
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        _animator.Play("Bang");
        SetAudioAndPlay(_destructionAudioClip);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }

    public void SetAudioAndPlay(AudioClip clip)
    {
        _audioSource.clip = clip;
        PlayAudio();
    }

    private void PlayAudio()
    {
        _audioSource.Play();
    }
}
