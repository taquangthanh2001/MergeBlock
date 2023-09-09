public class TextSpawner : Spawner
{
    protected static TextSpawner instance;
    public static TextSpawner Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
