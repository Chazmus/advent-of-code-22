using Godot;

namespace AdventOfCode22.Problems.Day1;

public partial class ElfScript : Sprite2D
{
    [Export] private RichTextLabel label;

    public void setText(string text) => label.Text = text;
}
