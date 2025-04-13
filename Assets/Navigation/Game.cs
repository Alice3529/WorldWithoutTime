using Dialogue;

public class Game 
{
    public static Game Instance = default;

    public Navigation Navigation { get; private set; }
    public DialogueSystem DialogueSystem { get; private set; }
    public GearSystem GearSystem { get; private set; }

    public Game()
    {
        Navigation = new Navigation();
        DialogueSystem = new DialogueSystem();
        GearSystem = new GearSystem();
        Instance = this;
    }
}
