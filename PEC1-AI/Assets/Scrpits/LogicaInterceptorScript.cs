using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaInterceptorScript : MonoBehaviour
{
    public GameObject agente;
    private NavMeshAgent navMesh, agentNavMesh;
    void Start()
    {
        //Agafem el component NavMeshAgent del objecte d'aquest scrpit
        navMesh = GetComponent<NavMeshAgent>();
        agentNavMesh = agente.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Fer que intercepti al agent trobant la posició amb la funció "steeringTarget"
        //navMesh.destination = agente.GetComponent<NavMeshAgent>().steeringTarget;

        //Trobar el punt per interceptar a l'agent amb la formula Va = Vb + (Pb-Pa)/t
        float t = 3;
        Vector3 posDiff = agente.transform.position - transform.position;
        Vector3 division = new Vector3(posDiff.x / t, 0, posDiff.z / t);
        Vector3 velocityAgent = new Vector3(division.x + agentNavMesh.velocity.x, 0, division.z + agentNavMesh.velocity.z);

        //i despres amb la formula Px = t * Va + Pa trobem al punt al que ha d'anar l'agent A per interceptar l'agent B
        Vector3 velTime = new Vector3(velocityAgent.x * t, 0, velocityAgent.z * t);
        Vector3 interPosition = new Vector3(velTime.x + transform.position.x, transform.position.y, velTime.z + transform.position.z);

        //fem que aquest agent vagi a aquest punt per interceptar
        navMesh.destination = interPosition;
    }
}
