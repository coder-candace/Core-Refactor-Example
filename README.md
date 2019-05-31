# Core-Refactor-Example

### Initial Setup
1. Separate code into different layers. Each "layer" is a project that makes this strategy flow better.
2. Upgrade each project to at least Framework 4.7.2.
3. Move the class library code, in this example that's the Business and Data projects, into Shared Projects. This is where the code will live until the migration is complete.
4. Make the Framework projects reference the Shared projects.

### Migrate to Standard
1. Create a new solution that will hold all the Standard projects.
2. Create a project that targets .NET Standard that corresponds to each Framework project EXCEPT for the Web project which contains all the controllers. There is no Standard WebAPI project, only Core or Framework.
3. Make the Standard projects reference the Shared projects. This is where you may have to start refactoring.
4. Ensure that both the Framework solution and the Standard solution still build as you're refactoring code to Standard.

### Migrate to Core
1. Create a new solution that will hold all the Core projects.
2. Create a project that targets .NET Core that corresponds to each Standard project EXCEPT for the Web project. The Web project will be handled later.
3. Make the Core projects reference the Shared projects. This is where you may now have to refactor the code to support Core but it will be less, if any at all, since the code has already been refactored to Standard.
4. Ensure that all 3 solutions still build as you refactor.
5. After all code has been refactored to Core in the class library projects, create a Core WebAPI project and move the controllers into it, refactoring those as you go. This will not be easy because you're going from Framework 4.7.2 to Core.
6. After refactoring of the WebAPI project is complete, move all the code in the shared projects into their respective projects in the Core solution.
7. Delete all the intermediary projects.

This strategy is good candidate because it will allow us to continue development without too much interference (and merge conflicts....) in our more active projects. It also allows us to do things incrementally with as little friction between Framework and Core as possible. AND it will allow us to take as long as we need to complete the migration.

The only difference in development flow while all this is going on is people will need to make their changes in the Shared projects instead of directly in the original Framework project as we have always done. Note that CodeLens, Find all references, and Go to implementation, etc. still work as they normally would even though it's a Shared project. I was super excited when I figure that out. It was the main thing that I was worried about that might have interrupted our general work flow.
