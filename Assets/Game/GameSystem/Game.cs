using Dialogue;
using GearSytem;
using NavigationSystem;

public class Game 
{
    public static Game Instance = default;
    public Navigation Navigation { get; private set; }
    public DialogueSystem DialogueSystem { get; private set; }
    public GearSystem GearSystem { get; private set; }

    public Game()
    {
        this.Navigation = new Navigation();
        this.DialogueSystem = new DialogueSystem();
        this.GearSystem = new GearSystem();
        Instance = this;
    }
}
