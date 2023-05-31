public interface IGameListener
{

}

public interface IGameStartListener : IGameListener
{
    public void OnGameStart();
}

public interface IGameFinishListener : IGameListener
{
    public void OnGameFinish();
}

public interface IGameRefreshListener : IGameListener
{
    public void OnGamePause();
    public void OnGameResume();
}

public interface IGameUpdateListener : IGameListener
{
    public void OnGameUpdate();
    public void OnGameFixedUpdate();
}