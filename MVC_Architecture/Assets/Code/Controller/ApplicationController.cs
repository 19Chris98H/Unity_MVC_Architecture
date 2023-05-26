public class ApplicationController : GameElement
{
    //Add your scene controller here
    //You can nest just locally used controller inside the scene controller to keep this class thin
    public TemplateController templateController { get; set; }
}