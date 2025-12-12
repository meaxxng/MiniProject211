using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    public PlayerRespawn player;
    public Transform[] checkpoints; // ใส่ Checkpoint_1 ถึง Checkpoint_10

    public void TeleportToCheckpoint(int id)
    {
        if (id >= 0 && id < checkpoints.Length)
        {
            player.TeleportTo(checkpoints[id].position);
        }
    }
}
