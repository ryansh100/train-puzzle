#Train Challenge

Series of challenges to solve regarding trips on trains.

## Explanation

My approach to the problem involves parsing a route code to origin, destination and distance.
All individual lines are held in a service collection to be evaluated as needed.

The Route service does the heavy lifting by using recursion from a single origin to walk the possible
routes until a route condition is met.

In most situations, the recursive walk can single-handly find the method with only
a few modifications in Linq to narrow down results to the specific request.

I assumed per document that a single line from one city to another could not exist twice or with a different
distance. I also assumed that cities are always represented by a single character and followed the format of
character 1 = origin, character 2 = destination.

I also assume that the NET Core 2.1.0 SDK and relatively new browser is installed.

## Run Challenge

1. Clone Repository
2. Navigate to `src` folder
3. `dotnet restore`
4. `dotnet run`
5. Navigate to `localhost:5000` in a browser (tested with Chrome).

## Run Tests

1. Clone Repository
2. Navigate to `test` folder
3. `dotnet restore`
4. `dotnet test`
