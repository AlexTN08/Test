using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(CapsuleCollider))]
public class Enemy : MonoBehaviour
{
    private Animator _animator;
    public Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
            return _animator;
        }
    }

    public bool attack = false;

    [SerializeField]
    private Transform _player;
    private float _dist;
    private float _howClose = 3f;

    private int _attackHash = Animator.StringToHash("Attack");
    private int _deathHash = Animator.StringToHash("Death");

    void Update()
    {
        bool down = Input.GetKeyDown(KeyCode.Space);

        _dist = Vector3.Distance(_player.position, transform.position);
        if (_dist <= _howClose)
        {
            if (down)
            {
                attack = true;
            }
            transform.LookAt(_player);
            Animator.SetBool(_attackHash, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Weapons weapons = other.GetComponent<Weapons>();
        if ((weapons != null) && (attack == true))
        {
            Animator.SetBool(_attackHash, false);
            Animator.SetBool(_deathHash, attack);
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}