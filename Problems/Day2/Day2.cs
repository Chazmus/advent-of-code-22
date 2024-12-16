using Godot;
using System.Threading.Tasks;

public partial class Day2 : Node2D
{
    [Export] private Sprite2D _left;

    [Export] private Sprite2D _right;

    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        var lines = getSampleInput();

        foreach (var line in lines)
        {
            await PlayGame(line);
        }
    }

    private async Task PlayGame(string line)
    {
        var parts = line.Split(' ');

        Tween tween = GetNode<Tween>(_left);

        var shake = 5;
        var interval = 10;

        tween.TweenProperty(_left, "position", _left.Position + new Vector2(shake, 0), interval);
        tween.TweenCallback(Callable.From(() => { }));

        await tween.ToSignal(tween, "finished");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private string[] getSampleInput()
    {
        return @"A Y
B X
C Z".Split('\n');
    }
}
