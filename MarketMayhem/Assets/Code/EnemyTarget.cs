using UnityEngine;
using Pathfinding;

public class EnemyTarget : MonoBehaviour
{

    [SerializeField] private Pathfinding.AIDestinationSetter aIDestinationSetter;

    private GameObject target;

    public void EnemyTargetsPlayer()
    {

        target = GameObject.FindGameObjectWithTag("Player");

        aIDestinationSetter.target = target.transform;




    }
}
