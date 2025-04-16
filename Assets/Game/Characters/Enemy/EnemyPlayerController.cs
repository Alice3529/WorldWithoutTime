using UnityEngine;
using UnityEngine.AI;
using UniRx;
using System;
using Random = UnityEngine.Random;

namespace Character.EnemyCharacter
{
    public class EnemyPlayerController : MonoBehaviour
    {
        [Header("Settings")]

        public Transform player;
        public float detectionRange = 5f;
        public float attackRange = 1.5f;
        public float wanderRadius = 5f;
        public float wanderInterval = 3f;
        public float attackCooldown = 2f;

        [SerializeField] private Animator animator = default;

        private NavMeshAgent agent;
        private float wanderTimer;
        private Subject<Unit> attackSubject = new Subject<Unit>();

        private void Start()
        {
            this.agent = GetComponent<NavMeshAgent>();

            this.agent.updateUpAxis = false;
            this.agent.updateRotation = false;

            this.wanderTimer = this.wanderInterval;

            this.attackSubject
                .ThrottleFirst(TimeSpan.FromSeconds(this.attackCooldown))
                .Subscribe(_ => this.Attack());
        }

        void Update()
        {
            if (this.player == null) { return; }

            this.FlipCharacter();

            float distance = Vector3.Distance(this.transform.position, this.player.position);

            if (distance < this.detectionRange)
            {
                this.agent.SetDestination(this.player.position);

                if (distance <= this.attackRange)
                {
                    this.attackSubject.OnNext(Unit.Default);
                }
            }
            else
            {
                this.Patrol(Time.deltaTime);
            }

            this.animator.SetBool("Walk", this.agent.velocity.sqrMagnitude > 0.01f);
        }

        private void Patrol(float time)
        {
            this.wanderTimer += time;

            if (this.wanderTimer >= this.wanderInterval || this.agent.remainingDistance < 0.5f)
            {
                Vector3 newPos = GetRandomNavMeshPosition(this.wanderRadius);
                this.agent.SetDestination(newPos);
                this.wanderTimer = 0;
            }
        }

        private Vector3 GetRandomNavMeshPosition(float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += this.transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }
            return this.transform.position;
        }

        private void FlipCharacter()
        {
            Vector3 velocity = this.agent.desiredVelocity;

            if (velocity.sqrMagnitude > 0.01f)
            {
                this.transform.localScale = (velocity.x > 0) ? Vector3.one : new Vector3(-1, 1, 1);
            }
        }

        private void Attack() => this.animator.SetTrigger("Attack");

        private void OnDrawGizmos()
        {
            Collider2D enemyCollider = GetComponent<Collider2D>();
            Gizmos.DrawWireSphere(this.transform.position, this.detectionRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(enemyCollider.bounds.center, this.attackRange);
        }
    }
}
