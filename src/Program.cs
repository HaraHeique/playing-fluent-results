using FluentResults;
using FluentResultTests.Fakers;
using FluentResultTests.Models;
using FluentResultTests.Models.Validations;
using System.Text.Json;


//Execution.RunFirst();
//Execution.RunSecond();
//Execution.RunThird();
//Execution.RunFourth();
Execution.RunFifth();

public static class Execution
{
    private readonly static ProdutoValidation _validator = new();
    private readonly static List<Result> _results = new();

    public static void RunFirst()
    {
        var itens = GenerateProducts();

        foreach (var item in itens)
        {
            var validationResult = _validator.Validate(item);

            if (!validationResult.IsValid)
            {
                var resultsErrors = validationResult.Errors.Select(vf => Result.Fail(vf.ErrorMessage));
                _results.Add(Result.Merge(resultsErrors.ToArray()));
            }
        }

        var mergedResult = _results.Merge();
        ShowMessages(mergedResult);
    }
    
    public static void RunSecond()
    {
        var itens = GenerateProducts();

        foreach (var item in itens)
        {
            var validationResult = _validator.Validate(item);

            if (!validationResult.IsValid)
            {
                var resultsErrors = validationResult.Errors.Select(vf => Result.Fail(vf.ErrorMessage));
                _results.AddRange(resultsErrors);
            }
        }

        var mergedResult = _results.Merge();
        ShowMessages(mergedResult);
    }

    public static void RunThird()
    {
        var itens = GenerateProducts();

        foreach (var item in itens)
        {
            var validationResult = _validator.Validate(item);

            if (!validationResult.IsValid)
            {
                var resultsErrors = validationResult.Errors.Select(
                    vf => Result.Fail(new Error(vf.ErrorMessage).WithMetadata("statusCode", vf.ErrorCode))
                );
                _results.Add(Result.Merge(resultsErrors.ToArray()));
            }
        }

        var mergedResult = _results.Merge();
        ShowMessages(mergedResult);
    }
    
    public static void RunFourth()
    {
        var itens = GenerateProducts();
        var result = new Result();
        //var result = Result.Ok(); // Equivalente ao de cima

        foreach (var item in itens)
        {
            var validationResult = _validator.Validate(item);

            if (!validationResult.IsValid)
                result.WithErrors(validationResult.Errors.Select(vf => vf.ErrorMessage));
        }

        ShowMessages(result);
    }
    
    public static void RunFifth()
    {
        var itens = GenerateProducts();

        foreach (var item in itens)
        {
            var validationResult = _validator.Validate(item);

            _results.Add(
                Result.FailIf(!validationResult.IsValid, $"Ocorreu um erro no produto {item.Id} com nome {item.Nome}")
            );
        }

        ShowMessages(_results.Merge());
    }

    private static IList<Produto> GenerateProducts()
    {
        var item1 = new ProdutoFaker().Generate(); // Valido
        var item2 = new ProdutoFaker().ComNome(string.Empty).Generate(); // Invalido

        return new List<Produto>() { item1, item2 };
    }

    private static void ShowMessages(object result)
    {
        var jsonValue = JsonSerializer.Serialize(result);

        Console.WriteLine("Acabou aqui!");
        Console.WriteLine(jsonValue);
    }
}

