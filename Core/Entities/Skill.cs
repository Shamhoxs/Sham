namespace Core.Entities;

public class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? IconUrl { get; set; }

    public IReadOnlyList<ProjectSkill> ProjectSkills { get; set; }
        = new List<ProjectSkill>();
}