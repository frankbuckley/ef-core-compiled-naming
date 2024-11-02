# EF Core compiled model naming conflict repro

To reproduce:

- Delete the `CompiledModels` folder
- Run the app
- App correctly prints `Hello, World!`
- In EfCoreCompiledModelNaming folder, run `dotnet ef dbcontext optimize`
- Run the app
- NullReferenceException is thrown `at Microsoft.EntityFrameworkCore.Metadata.RuntimeProperty.<>c.<GetValueComparer>b__47_0(RuntimeProperty property)`

Issue is at [line 35 in SentenceEntityType](./EfCoreCompiledModelNaming/CompiledModels/SentenceEntityType.cs#L35) - `Sentence` is no qualkified to refer to `AnotherNamespace.Sentence`



