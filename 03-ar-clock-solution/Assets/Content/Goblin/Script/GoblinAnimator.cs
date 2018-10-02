using UnityEngine;

public class GoblinAnimator : MonoBehaviour
{
    private Animator anim;
    private bool walk;
    private bool attack;
    private bool stumble;
    private bool die;
    private bool dead;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Idle()
    {
        walk = false;
    }

    public void Walk()
    {
        walk = true;
    }

    public void Attack()
    {
        attack = true;
    }

    public void Stumble()
    {
        stumble = true;
    }

    public void Die()
    {
        die = true;
    }

    void Update()
    {
        if (dead)
        {
            anim.SetInteger("state", 0);
            return;
        }

        if (walk)
        {
            anim.SetInteger("state", 2);
        }
        else
        {
            anim.SetInteger("state", 0);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") && attack)
        {
            if (Random.Range(0, 2) == 0)
            {
                anim.SetInteger("state", 3);
            }
            else
            {
                anim.SetInteger("state", 4);
            }
        }

        if (Input.GetKeyDown("m")) //power attack
        {
            anim.SetInteger("state", 6);
        }

        if (stumble)
        {
            if (Random.Range(0, 2) == 0)
            {
                anim.SetInteger("state", 10);
            }
            else
            {
                anim.SetInteger("state", 11);
            }

            stumble = false;
        }

        if (die && !dead)
        {
            if (Random.Range(0, 2) == 0)
            {
                anim.SetInteger("state", 12);
            }
            else
            {
                anim.SetInteger("state", 13);
            }

            dead = true;

            foreach (var col in GetComponentsInChildren<Collider>())
            {
                col.enabled = false;
            }

            Destroy(gameObject, 5);
        }
    }

    public bool IsIdle()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("idle");
    }

    public bool IsWalking()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("run") || anim.GetNextAnimatorStateInfo(0).IsName("run");
    }
}