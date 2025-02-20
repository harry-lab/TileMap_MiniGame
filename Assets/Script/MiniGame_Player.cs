using UnityEngine;

public class MiniGame_Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;
    public bool godMode = false;

    MiniGameManager minigameManager = null;
    bool isGameStarted = false; //  게임 시작 여부 확인 변수

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        minigameManager = MiniGameManager.Instance;

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }

        _rigidbody.velocity = Vector2.zero; // 시작할 때 정지 상태 유지
        _rigidbody.gravityScale = 0; //  게임 시작 전까지 중력 비활성화
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    minigameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (!isGameStarted) //  게임이 아직 시작되지 않았다면
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    isGameStarted = true; //  첫 입력이 들어오면 게임 시작
                    _rigidbody.gravityScale = 1; //  중력 다시 활성화
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    isFlap = true;
                }
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead || !isGameStarted) //  게임 시작 전에는 움직이지 않음
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float targetAngle = Mathf.Clamp(_rigidbody.velocity.y * 10f, -30, 30);
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 5f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        minigameManager.GameOver();
    }
}
