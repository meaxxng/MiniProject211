using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Simple PlayerPrefs-based save (expandable)
    public void SavePlayerData(Player player)
    {
        if (player == null || player.wallet == null) return;

        PlayerPrefs.SetInt("wallet_coin", player.wallet.Coin);
        PlayerPrefs.SetInt("wallet_gem", player.wallet.Gem);
        PlayerPrefs.SetInt("wallet_star", player.wallet.Star);
        PlayerPrefs.Save();
    }


    public void LoadPlayerData(Player player)
    {
        if (player == null || player.wallet == null) return;

        int coin = PlayerPrefs.GetInt("wallet_coin", player.wallet.Coin);
        int gem = PlayerPrefs.GetInt("wallet_gem", player.wallet.Gem);
        int star = PlayerPrefs.GetInt("wallet_star", player.wallet.Star);

        player.wallet.SetCurrency(coin, gem, star);
    }



    public void SaveCheckpoint(Checkpoint cp)
    {
        if (cp == null) return;
        PlayerPrefs.SetFloat("checkpoint_x", cp.transform.position.x);
        PlayerPrefs.SetFloat("checkpoint_y", cp.transform.position.y);
        PlayerPrefs.SetFloat("checkpoint_z", cp.transform.position.z);
        PlayerPrefs.Save();
    }


    public Vector3 LoadCheckpointPosition(Vector3 defaultPos)
    {
        if (!PlayerPrefs.HasKey("checkpoint_x")) return defaultPos;
        float x = PlayerPrefs.GetFloat("checkpoint_x");
        float y = PlayerPrefs.GetFloat("checkpoint_y");
        float z = PlayerPrefs.GetFloat("checkpoint_z");
        return new Vector3(x, y, z);
    }
}
