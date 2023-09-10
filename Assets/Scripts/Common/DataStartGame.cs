using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStartGame : MonoBehaviour
{
    protected UserData userData;
    protected DataGamePlay dataGamePlay;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(GameConst.USER_DATA))
        {
            UserData userData = new();
            userData.IdPackageBlock = 1;
            userData.Id = 1;

            Commons.SetUserData(userData);
        }
        else
        {
            userData = Commons.GetUserData();
        }

        if (!PlayerPrefs.HasKey(GameConst.GAMEPLAY_DATA))
        {
            DataGamePlay dataGamePlay = new();
            dataGamePlay.Id = 1;
            dataGamePlay.HightScore = 0;

            Commons.SetGamePlayData(dataGamePlay);
        }
        else
        {
            dataGamePlay = Commons.GetDataGamePlay();
        }
    }
    //private void OnDisable()
    //{
    //     Commons.SetGamePlayData(dataGamePlay);
    //}
}
