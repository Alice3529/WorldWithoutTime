using UnityEngine;
using UnityEngine.AI;
using UniRx;
using System;

public class EnemyPlayerController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;     
    public float attackRange = 1.5f;    
    public float wanderRadius = 5f;      
    public float wanderInterval = 3f;    
    public float attackCooldown = 2f;  

    private NavMeshAgent agent;
    private float wanderTimer;
    private Subject<Unit> attackSubject = new Subject<Unit>(); 

    [SerializeField] private Animator animator = default;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateUpAxis = false;
        agent.updateRotation = false;

        wanderTimer = wanderInterval;

        attackSubject
            .ThrottleFirst(TimeSpan.FromSeconds(attackCooldown)) 
            .Subscribe(_ => Attack());  


        attackSubject.Subscribe(_ => Debug.Log("Enemy attacked!"));

        this.animator.SetBool("Walk", true);
    }

    void Update()
    {
        if (this.player == null) { return; }
        this.FlipCharacter();

        float distance = Vector3.Distance(this.transform.position, this.player.position);

        if (distance < detectionRange)
        {
            this.agent.SetDestination(this.player.position);

            if (distance <= attackRange)
            {
                this.Attack();
            }
        }
        else
        {
            this.Patrol(Time.deltaTime);
        }

        this.animator.SetBool("Walk", agent.velocity.sqrMagnitude > 0.01f);
    }

    private void Patrol(float time)
    {
        wanderTimer += time;

        if (this.wanderTimer >= wanderInterval || agent.remainingDistance < 0.5f)
        {
            Vector3 newPos = GetRandomNavMeshPosition(wanderRadius);
            agent.SetDestination(newPos);
            wanderTimer = 0;
        }
    }

    Vector3 GetRandomNavMeshPosition(float radius)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }

    private void FlipCharacter()
    {
        Vector3 velocity = agent.desiredVelocity;

        if (velocity.sqrMagnitude > 0.01f)
        {
            if (velocity.x > 0)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    void Attack()
    {
        this.animator.SetTrigger("Attack");
    }
}
