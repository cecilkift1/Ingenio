# Ingenio
Cecil Kift - Ingenio code test

Took about an hour to complete.

To solve this I used classes, linked lists, recursion, extension methods, linq and dictionaries.
Did error checking where needed, but I did code for the happy path mostly.
This is not using C# 8.0 nullable types, which introduces nullable reference types and non-nullable reference types that
enable you to make important statements about the properties for reference type variables
https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references

It's a .Net Core console application created in vs Code.
To build and run it:
1) Download the repository
2) Open terminal app in the folder
3) In the terminal app type dotnet build
4) In the terminal app type dotnet run

It should load with a menu that looks like this:

Hello please make your selection:
 Enter '1' for function 1
 Enter '2' for function 2
 Enter 'x' to exit

Selecting 1:

Please enter the categoryId:
Valid Categories are: 100,200,101,102,201,103,202,109

Then if you say enter 102
102
The output should look like this.

Output: ParentCategoryID=100, Name=Taxation, Keywords=Money

Entering invalid values like ddd, the app would return
Please select select a valid option

Selecting 2:
Please enter the category level:
Valid levels are: 1,2,3,4,5,6,7

entering 3, you get
Output: [103,109,202]
