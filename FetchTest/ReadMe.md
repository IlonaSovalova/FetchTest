# Algorithm Description
1. Open web page http://sdetchallenge.fetch.com/
2. Put bars [0,1,2] on the left bowl.
3. Put bars [3,4,5] on the right bowl.
4. Click 'Weigh'.
5. Wait for result (character other then '?').
6. Depending on result, fake bar will be in the group as follows:
	* '<' - [0,1,3]
	* '>' - [3,4,5]
	* '=' - [6,7,8]
7. Put first and second bar from corresponding group on the left and right bowl.
8. Click 'Weigh'.
9. Wait for result (character other then '?').
10. Depending on result, fake bar will be in the group as follows:
	* '<' - first number in the group
	* '>' - second number in the group
	* '=' - third number in the group


# Requirements to build/run
Test application implemented using C# / NUnit / Playwright frameworks.
Solution requires Microsoft Visual Studio 2022 with .NET 8.
Solution / Project include all required dependencies and those can be restored using Restore NuGet Packages function.
