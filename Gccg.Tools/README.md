## usage

Check out README.md in GitHub repository for basic usage and examples.
https://github.com/cplkimth/Gccg (but not documented yet)

### RowGenerator
```
internal class Program
{
    static void Main(string[] args)
    {
        var config = new RowGeneratorConfig
        {
            Namespace = "Chinook.Data",
            Directory = @"D:\git\Gccg\Examples\Chinook\Chinook.Data\Constants",
            RowGenerators =
            [
                new ConstantGenerator(nameof(Genre),
                    () => Dao.Genre.Get().ConvertAll(x => (object)x),
                    x => ((Genre)x).GenreId,
                    x => ((Genre)x).Name,
                    x => ((Genre)x).GenreId),
                new EnumGenerator(nameof(Genre),
                    () => Dao.Genre.Get().ConvertAll(x => (object)x),
                    x => ((Genre)x).GenreId,
                    x => ((Genre)x).Name,
                    x => ((Genre)x).GenreId)
            ]
        };

        RowGenerator.Run(config);
    }
}
```