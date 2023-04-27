using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAi : MonoBehaviour
{
    public enum State { idle, tracking };
    public State state = State.idle;

    [SerializeField] private float idleRadius;
    [SerializeField] private float maxRangeDistance;
    [SerializeField] private LayerMask playerMask;

    private StatManager statManager;
    NavMeshAgent agent;
    GameObject player;

    Vector3 lastDestination;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");

        statManager = FindObjectOfType<StatManager>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.autoTraverseOffMeshLink = true;
        agent.updateRotation = true;
    }

    private void Update()
    {
        EnemyState();
        PlayerHurt();
    }

    private void EnemyState()
    {
        Vector3 center = transform.position;
        Vector3 dir = player.transform.position - transform.position;
        if (PlayerCheck(center, dir, maxRangeDistance))
        {
            state = State.tracking;
            TrackingMovement();
        }
        else
        {
            state = State.idle;
            IdleMovement();
        }
    }

    private bool PlayerCheck(Vector3 org, Vector3 direction, float maxDistance)
    {
        Ray ray = new Ray(org, direction);
        bool range = Physics.Raycast(ray, maxDistance, playerMask);
        return range;
    }

    private void IdleMovement()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= 0.5f)
            agent.destination = RandomPos();

        if (agent.destination == lastDestination)
            return;
        agent.destination = RandomPos();
        lastDestination = agent.destination;
    }

    private void TrackingMovement()
    {
        agent.destination = player.transform.position;
    }

    private Vector3 RandomPos()
    {
        Vector3 randomDirection = Random.insideUnitSphere * idleRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, idleRadius, NavMesh.AllAreas);
        return hit.position;
    }

    void PlayerHurt()
    {
        float dieDistance = Vector3.Distance(transform.position, player.transform.position);
        if (dieDistance <= 0.9f)
        {
            state = State.idle;

            statManager.willPower -= 20;

            while (dieDistance < 10)
            {
                transform.position = RandomPos();
                dieDistance = Vector3.Distance(transform.position, player.transform.position);
            }
        }
    }
}
