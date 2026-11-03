using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProjectSkillConfiguration
    : IEntityTypeConfiguration<ProjectSkill>
{
    public void Configure(EntityTypeBuilder<ProjectSkill> builder)
    {
        builder.ToTable("ProjectSkills");

        builder.HasKey(x => new { x.ProjectId, x.SkillId });

        builder.HasOne(x => x.Project)
            .WithMany(x => x.ProjectSkills)
            .HasForeignKey(x => x.ProjectId);

        builder.HasOne(x => x.Skill)
            .WithMany(x => x.ProjectSkills)
            .HasForeignKey(x => x.SkillId);
    }
}