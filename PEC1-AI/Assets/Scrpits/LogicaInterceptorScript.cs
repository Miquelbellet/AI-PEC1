using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaInterceptorScript : MonoBehaviour
{
    public GameObject agente;
    private NavMeshAgent navMesh;
    void Start()
    {
        //Agafem el component NavMeshAgent del objecte d'aquest scrpit
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Fer que intercepti al agent trobant la posició amb la funció "steeringTarget"
        navMesh.destination = agente.GetComponent<NavMeshAgent>().steeringTarget;
    }
}
