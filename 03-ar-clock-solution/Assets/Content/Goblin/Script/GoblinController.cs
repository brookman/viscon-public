using UnityEngine;

public class GoblinController : MonoBehaviour, InteractionController.Interactable
{
    public float speed = 0.21f;
    public Transform target;
    public GameController gameController;
    public float health = 100;
    public ParticleSystem hitEffect;

    private GoblinAnimator anim;

    void Start()
    {
        anim = GetComponent<GoblinAnimator>();
    }

    void Update()
    {
        var goblinPos = transform.position;
        var targetPos = target.position;

        var isWalking = false;
        var inRange = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(targetPos.x, targetPos.z)) < 0.08f;

        if (inRange)
        {
            if (anim.IsIdle())
            {
                anim.Attack();
            }
            else
            {
                anim.Idle();
            }
        }
        else
        {
            isWalking = true;
            anim.Walk();
        }

        transform.rotation = Quaternion.LookRotation(targetPos - goblinPos);

        var currentSpeed = anim.IsWalking() && isWalking ? speed : 0;
        var moveDirection = transform.forward * currentSpeed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + moveDirection.x, target.transform.position.y,
            transform.position.z + moveDirection.z);
    }

    public void Touched(Vector3 point)
    {
        Damage(Random.Range(20f, 50f));
    }

    public void Damage(float damage)
    {
        if (hitEffect)
        {
            hitEffect.Play();
        }

        anim.Stumble();
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            anim.Die();
        }
    }

    public void Attack()
    {
        gameController.AddTime(Random.Range(1f, 5f));
    }
}