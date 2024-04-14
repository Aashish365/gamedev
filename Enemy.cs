using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform player;
    Health enemyHealth, playerHealth;
    Animator animator;
    bool died = false;
    private NavMeshAgent navMeshAgent;
    float distance;

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<Health>();
        playerHealth = player.GetComponent<Health>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (enemyHealth.isDead())
        {
            animator.SetBool("Dead", true);
            navMeshAgent.updatePosition = false;
            // Freeze rotation when dead
            navMeshAgent.updateRotation = false;

            if (!died)
            {
                player.GetComponent<Player>().KillCount++;
                died = true;
            }
        }

        // Check if the player is not null (added for safety)
        if (distance <= 10f)
        {
            if (enemyHealth.health > 0)
            {
                navMeshAgent.SetDestination(player.position);
                animator.SetBool("playerInRange", true);

                if (distance <= 2.5f)
                {
                    animator.SetBool("playerInAttackRange", true);
                    player.GetComponent<Health>().takeDamage(0.1f);
                }
                else
                {
                    animator.SetBool("playerInAttackRange", false);
                }

                navMeshAgent.updatePosition = true;
            }
        }
        else
        {
            animator.SetBool("playerInRange", false);
            animator.SetBool("playerInAttackRange", false);
            navMeshAgent.updatePosition = true;
        }
    }
}
