using System.Reflection;
using FluentMigrator;

namespace LearnRazor.InternalMigration;

[Migration(
    MigrationApplicationBuilder.MIGRATION_VERSION,
    MigrationApplicationBuilder.MIGRATION_DESCRIPTION
)]
public class MainMigration : Migration
{
    IEnumerable<Type> listMigration = Assembly
        .GetAssembly(typeof(IMigrationBase))
        .GetTypes()
        .Where(type =>
            type.IsClass && !type.IsAbstract && typeof(IMigrationBase).IsAssignableFrom(type)
        );

    List<IMigrationBase> GetMigrationBaseInheritedClass()
    {
        List<IMigrationBase> list = new List<IMigrationBase>();

        foreach (var item in listMigration)
        {
            // if (System.Attribute.GetCustomAttributes(item).Length == 0)
            // {
            list.Add((IMigrationBase)Activator.CreateInstance(item));
            // }
        }
        return list;
    }

    public override void Down()
    {
        foreach (var item in GetMigrationBaseInheritedClass())
        {
            item.MigrationDown(this);
        }
    }

    public override void Up()
    {
        if (!MigrationApplicationBuilder.UpdateForeignKey)
        {
            foreach (var item in GetMigrationBaseInheritedClass())
            {
                item.MigrationUp(this);
            }
        }

        if (MigrationApplicationBuilder.UpdateForeignKey)
        {
            foreach (var item in GetMigrationBaseInheritedClass())
            {
                item.GenerateForeignKey(this);
            }
        }
    }
}
