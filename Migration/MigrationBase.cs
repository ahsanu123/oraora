using FluentMigrator;

namespace LearnRazor.InternalMigration;

public interface IMigrationBase
{
    public abstract void MigrationUp(Migration migration);
    public abstract void MigrationDown(Migration migration);
    public abstract void GenerateForeignKey(Migration migration);
}
