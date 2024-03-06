using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy: MonoBehaviour
{
    public NavMeshAgent meshAgent;

    public List<GameObject> waypoints;

    private GameObject player;

    private float velocity = 4, index, distance, radius = 20;

    [Range(0, 360)]
    public float angle;

    private Vector3 next_pos, destination, rotation;

    public bool chasing = false, onpath = true, canSeePlayer = false, editing = false;

    public LayerMask targetMask, obstructionMask; //Layermsks som används för att visa vad som är vad. Alltså vad som är en vägg och vad som är en player.

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1"); // Sätter player variabeln till ett gameobject med taggen "Player1"
        StartCoroutine(FOVRoutine()); //Startar cooldown metoden.
        // OnSceneGUI();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(rotation); //Använder rotation variabeln för att visa positionen som enemyn ska kolla på.

        if (canSeePlayer == true) // Om enemyn kan se playern så börjar den jaga. 
            chasing = true;

        else // om den inte kan se så jagar den inte
            chasing = false;

        if (chasing == false)
        {
            if (onpath == false)
            {

                meshAgent.SetDestination(destination); // Om enemyn inte är inne på pathen med waypoints som den använder för att patrullera runt mappen så
                                                       // sätts meshagentens destination till den senaste punkten enemyn var på innan den började jaga playern
                if (transform.position.x == destination.x && transform.position.z == destination.z) 
                {
                    onpath = true; // Om enemyn är på senaste waypointen så sätts onpath till true och den fortsätter patrullera
                }    
            }
            else if (onpath == true)
            {
                meshAgent.ResetPath(); // Resettar enemyns meshagebts path.

                // Rotation variablerna används för att sätta vilket håll enemyn ska vara roterad mot.
                rotation.x = destination.x;
                rotation.z = destination.z;
                rotation.y = transform.position.y;

                destination = waypoints[(int)index].transform.position; // Sätter destinations transform.position till nästa waypoints transform.position

                next_pos = Vector3.MoveTowards(transform.position, destination, velocity * Time.deltaTime); //Sätter nextpos till den positonen enemyn ska gå

                transform.position = next_pos; // sätter enemyns position till nextpos position

                distance = Vector3.Distance(transform.position, destination); // Räknar ut distans mellan enemyn och waypointen den ska till
                if (distance <= 0.5)
                {
                    if (index < waypoints.Count - 1)
                        index++; 

                    else
                        index = 0;
                }
            }
        }

        else if (chasing == true)
        {
            meshAgent.SetDestination(player.transform.position); //Om enemyn ser playern sätts meshagentens destination till playerns destination.

            // Rotationen sätts till playerns kordinater.
            rotation.x = player.transform.position.x;
            rotation.z = player.transform.position.z;
            rotation.y = transform.position.y; // Behåller y rotationen som enemyn har för att inte enemyn ska vrida sig.

            onpath = false;
        }
    }
    private IEnumerator FOVRoutine() // En cooldown metod som används till playerns syn.
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck(); // Kör field of view metode efter 0,2 sekunder.
        }
    }

    private void FieldOfViewCheck() //Metod som används för att enemyn ska kunna se.
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask); //Gör den radien som enemyn kan se. Alltså hur långt den kan se.
                         
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform; // Sätter target variabelns transform till rangechecks transform.
            Vector3 directionToTarget = (target.position - transform.position).normalized; // Räknar ut vilket håll playern är från enemyn.

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) //Räknar ut vilken vinkel som enemyn kan se i. 
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); // Räknar ut distansen till targeten.

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    //Skickar ut rays för att se om det är något mellan enemyn och playern som blockar dens syn som tillexempel en vägg. 
                    canSeePlayer = true; //Om det inte finns något mellan enemyn och playern så kan den se playern
                else
                    canSeePlayer = false; //Om det är något mellan enemyn och playern så kan den inte se playern.
            }
            else
                canSeePlayer = false;
        }

        else if (canSeePlayer == true)
            canSeePlayer = false; // Om playern kommer utanför enemyns syn så kan inte enemyn se playern längre. 


    }

   /* private void OnSceneGUI() // En metod som skulle rita ut fältet som enemyn kunde se. Funkade inte i slutändan.
    {
        if (editing == true)
        {
            Handles.color = Color.white;
            Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, radius);
        }
    } */
}