namespace JacksonVeroneze.NET.Pagination.Util.Builders;

[ExcludeFromCodeCoverage]
public static class UserBuilder
{
    public static User BuildSingle()
    {
        return Factory().Generate();
    }

    public static ICollection<User> BuildMany(int total)
    {
        return Factory().Generate(total);
    }

    private static Faker<User> Factory()
    {
        return new Faker<User>("pt_BR")
            .RuleFor(f => f.Id, s => s.Random.Int())
            .RuleFor(f => f.Name, s => s.Person.FullName);
    }
}