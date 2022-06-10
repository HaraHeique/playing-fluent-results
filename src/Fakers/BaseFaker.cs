using Bogus;

namespace FluentResultTests.Fakers
{
    public abstract class BaseFaker<T> : Faker<T> where T : class
    {
    }
}
