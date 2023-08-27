public static class SessionPref 
{
    private static UserData _userData;
    private static DataGamePlay _dataGamePlay;
    public static UserData GetCurrentData()
    {
        return _userData;
    }
    public static void SetCurrentData(UserData userData)
    {
        _userData = userData;
    }

    public static DataGamePlay GetDataGamePlay()
    {
        return _dataGamePlay;
    }

    public static void SetDataGamePlay(DataGamePlay dataGamePlay)
    {
        _dataGamePlay = dataGamePlay;
    }
}
