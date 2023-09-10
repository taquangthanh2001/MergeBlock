using UnityEngine;
using Newtonsoft.Json;
public static class Commons
{
    public static void SetUserData(UserData userData)
    {
        SessionPref.SetUserData(userData);
        PlayerPrefs.SetString(GameConst.USER_DATA, JsonConvert.SerializeObject(userData));
    }
    public static void SetGamePlayData(DataGamePlay dataGamePlay)
    {
        SessionPref.SetDataGamePlay(dataGamePlay);
        PlayerPrefs.SetString(GameConst.GAMEPLAY_DATA, JsonConvert.SerializeObject(dataGamePlay));
    }
    public static UserData GetUserData()
    {
        return SessionPref.GetUserData() ?? JsonConvert.DeserializeObject<UserData>(PlayerPrefs.GetString(GameConst.USER_DATA));
    }
    public static DataGamePlay GetDataGamePlay()
    {
        return SessionPref.GetDataGamePlay() ?? JsonConvert.DeserializeObject<DataGamePlay>(PlayerPrefs.GetString(GameConst.GAMEPLAY_DATA));
    }
    public static void CalculateAngleByTargetDirection(Transform transform, Vector3 targetPos)
    {
        Vector3 relative = transform.InverseTransformPoint(targetPos);
        float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
        transform.Rotate(0, angle, 0);
    }
    public static float CalculateSpeed(float speed)
    {
        return speed / 2 * Time.deltaTime;
    }
}
