using Steamworks;
using UnityEngine;

public class SteamAchievementHandler : MonoBehaviour
{
    public void FirstSecret()
    {
        Debug.Log("Called");
        if (SteamManager.Initialized)
        {
            Steamworks.SteamUserStats.GetAchievement("ACH_YOU_ALWAYS_REMEMBER", out bool achievementCompleted);

            Debug.Log(achievementCompleted);

            if (!achievementCompleted)
            {
                SteamUserStats.SetAchievement("ACH_YOU_ALWAYS_REMEMBER");
                SteamUserStats.StoreStats();
                Debug.Log("Done");
            }
        }
    }
}
