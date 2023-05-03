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
        Debug.Log(agent.destination);
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
        if (Vector3.Distance(transform.position, agent.destination) <= 3f)
        {
            Debug.Log("ReSetting");
            agent.destination = RandomPos();
        }

        if (agent.destination == lastDestination)
            return;

        Debug.Log("Setting");
        agent.destination = RandomPos();
        lastDestination = agent.destination;
    }

    private void TrackingMovement()
    {
        agent.destination = player.transform.position;
    }

    public Vector3 RandomPos()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-80f, 80f), Random.Range(-8f, 8f), Random.Range(-8f, 8f));   
        randomDirection += transform.position;
        Debug.Log(randomDirection);
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
                Debug.Log("Catch");
                transform.position = RandomPos();
                dieDistance = Vector3.Distance(transform.position, player.transform.position);
            }
        }
    }
}
