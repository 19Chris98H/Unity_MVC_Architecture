using UnityEngine;

public class GameApplication : MonoBehaviour
{
    public ApplicationModel Model {get; private set;}
    public ApplicationView View {get; private set;}
    public ApplicationController Controller {get; private set;}

    void Awake()
    {
        //Assign MVC classes
        Model = transform.GetComponentInChildren<ApplicationModel>();
        View = transform.GetComponentInChildren<ApplicationView>();
        Controller = transform.GetComponentInChildren<ApplicationController>();
    }

    void Start()
    {
        //Add your start logic here
    }
}
