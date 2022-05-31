using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieGraphics : MonoBehaviour
{
    Animator animator;
    [SerializeField] AIPath aiPath;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isRunning", ZombieHasHorizontalSpeed());

        FlipSprite();
    }

    void FlipSprite() {
        if(ZombieHasHorizontalSpeed()) {
            transform.localScale = new Vector2(Mathf.Sign(aiPath.desiredVelocity.x), 1f);
        }
    }

    private bool ZombieHasHorizontalSpeed() {
        return Mathf.Abs(aiPath.desiredVelocity.x) > Mathf.Epsilon;
    }
}
