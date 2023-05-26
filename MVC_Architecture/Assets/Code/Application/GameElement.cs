using UnityEngine;

public class GameElement : MonoBehaviour
{
    protected GameApplication App => _app ? _app : _app = FindObjectOfType<GameApplication>();
    GameApplication _app;
}
