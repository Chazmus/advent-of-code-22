using System.Collections.Generic;
using System.Linq;
using AdventOfCode22.Problems.Day1;
using Godot;

public partial class Day1 : Node2D
{
    PackedScene elfScene = ResourceLoader.Load<PackedScene>("res://Problems/Day1/elf.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var input = getSampleInput();
        var lines = input.Split('\n');

        var elves = new List<Elf>();
        var currentElf = new Elf();
        elves.Add(currentElf);

        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                currentElf = new Elf();
                elves.Add(currentElf);
                continue;
            }

            currentElf.calories.Add(int.Parse(line));
        }

        for (int i = 0; i < elves.Count; i++)
        {
            // Work out position, in a grid formation
            var x = (i % 3) * 200 + 100;
            var y = (i / 3) * 200 + 100;

            var elf = elves[i];
            var elfInstance = elfScene.Instantiate<ElfScript>();
            elfInstance.setText(elf.calories.Sum().ToString());
            AddChild(elfInstance);
            elfInstance.SetPosition(new Vector2(x, y));
        }

        var thing = "banana";
    }

    struct Elf
    {
        public List<int> calories = new();

        public Elf()
        {
        }
    }

    private string getSampleInput()
    {
        return @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
