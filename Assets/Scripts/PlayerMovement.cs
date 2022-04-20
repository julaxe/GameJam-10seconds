using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerAnimation _playerAnimation;

    [SerializeField] private float _speed = 1f;

    private Vector3 _direction;
    private bool _canMove = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (!_canMove) return;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _direction = new Vector3(x, 0f, y);
        if (_direction != Vector3.zero)
        {
            _direction = _direction.normalized;
            var newRot = Quaternion.LookRotation(_direction);
            transform.rotation = newRot;
        }
    }

    private void FixedUpdate()
    {
        if (!_canMove) return;
        var force = _direction * _speed * Time.fixedDeltaTime;
        _rigidbody.AddForce(force);
    }

    public void ActivateMoving()
    {
        _canMove = true;
        _playerAnimation.StartRolling();
    }

    public void DisableMoving()
    {
        _canMove = false;
        _playerAnimation.StopRolling();
    }

}
