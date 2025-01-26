using FluentMigrator;
using Oraora.Models;

namespace Oraora.InternalMigration;

public class ModelMigrationList : IMigrationBase
{
    private readonly List<Type> listModel = new List<Type> { typeof(Product) };

    public static List<string> listExcludedType = new List<string> { nameof(System.Collections) };

    public void MigrationDown(Migration migration)
    {
        listModel.ForEach((type) => migration.DeleteTableIfExists(type));
    }

    public void MigrationUp(Migration migration)
    {
        listModel.ForEach((type) => migration.ConvertModelToMigration(type, listExcludedType));
    }

    public void GenerateForeignKey(Migration migration)
    {
        listModel.ForEach((type) => migration.GenerateForeignKey(type));
    }
}
