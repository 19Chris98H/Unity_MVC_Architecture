using UnityEngine;

public class GameElement : MonoBehaviour
{
    protected GameApplication app => _app ? _app : _app = FindObjectOfType<GameApplication>();
    GameApplication _app;
}
