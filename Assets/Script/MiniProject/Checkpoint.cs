using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int id;

    public int checkpointIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();
            if (respawn != null)
            {
                respawn.SaveLastCheckpoint(checkpointIndex);
                Debug.Log("Reached checkpoint: " + checkpointIndex);
            }
        }
    }
}
