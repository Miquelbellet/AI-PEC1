using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaPerseguidorScript : MonoBehaviour
{
    public GameObject agent, interceptor;

    private enum stateMachine { FollowPlayer1, FollowPlayer2 };
    private stateMachine state;
    private NavMeshAgent navMesh;
    void Start()
    {
        //Agafem el component NavMeshAgent del objecte d'aquest scrpit
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Comprobem si l'agent es mou o no
        StartCoroutine(CheckMoving());
        //Amb aquesta máquina d'estats fem que si l'agent es mou vagi cap a ell o sinó vagi cap al interceptor
        stateMachineUpdate();
    }

    private IEnumerator CheckMoving()
    {
        //Ajuda per saber si l'agent es movia extreta d'aquest link: https://answers.unity.com/questions/382270/check-if-object-is-moving.html
        Vector3 startPos = agent.transform.position;
        yield return new WaitForSeconds(.1f);
        Vector3 finalPos = agent.transform.position;
        if (startPos != finalPos) state = stateMachine.FollowPlayer1;
        else state = stateMachine.FollowPlayer2;
    }
    private void stateMachineUpdate()
    {
        switch (state)
        {
            case stateMachine.FollowPlayer1:
                Debug.Log("Player 1");
                followingPlayer1();
                break;
            case stateMachine.FollowPlayer2:
                Debug.Log("Player 2");
                followingPlayer2();
                break;
            default:
                state = stateMachine.FollowPlayer1;
                break;
        }
    }
    private void followingPlayer1()
    {
        //Que segueixi al objecte agent
        navMesh.destination = agent.transform.position;
    }
    private void followingPlayer2()
    {
        //Que seguieixi al interceptor
        navMesh.destination = interceptor.transform.position;
    }
}
