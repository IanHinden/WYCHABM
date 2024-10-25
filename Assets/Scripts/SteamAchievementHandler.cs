//using Steamworks;
using UnityEngine;

public class SteamAchievementHandler : MonoBehaviour
{
    string[] achievements = { "ACH_YOU_ALWAYS_REMEMBER", "ACH_KISS_AND_LIVE", "ACH_IANS_TATTOO", "ACH_AND_YOU", "ACH_AVAS_HAPPY_ENDING", "ACH_DIRTY_WORD", "ACH_ALL_FAIR" };
    /*private void Awake()
    {
        ResetAllAchievements();
    }
    private void ResetAllAchievements()
    {
        if (SteamManager.Initialized)
        {
            Steamworks.SteamUserStats.ResetAllStats(true);
        }
    }*/

    public void UnlockAchievement(int achievementPosition)
    {
        /*if (SteamManager.Initialized)
        {
            Steamworks.SteamUserStats.GetAchievement(achievements[achievementPosition], out bool achievementCompleted);

            if (!achievementCompleted)
            {
                SteamUserStats.SetAchievement(achievements[achievementPosition]);
                SteamUserStats.StoreStats();
            }
        }*/
    }
}
