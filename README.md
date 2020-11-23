# Elekta

# Pet Reporting re-factor project
I have refactored the project and provided 3 possible solutions. My prefered solution is to use the visitor pattern as it doesn't require the use of reflection.

I have retained the original project (PetReporting) and annotated it with TODO comments indicating the issues I would highlight to the programmer about the code. 

**Elekta\PetReporting.Dynamic** dotnet run

Or run the **PetReporting.Dynamic.ConsoleApp** project in the VS solution.

## Report achieved using a polymorphic visitor pattern

**Owners name,Date Joined Practice,Number Of Visits,Number of Lives**
Jim Rogers, 23/11/2020 21:46:35, 5,
Tony Smith, 13/07/1985 00:00:00, 10,
Steve Roberts, 06/05/2002 00:00:00, 20, 9

## Report achieved using the DynamicObject

 >> to file: PetsReport.csv

## Report achieved using the DynamicObject

**Owners name,Date Joined Practice,Number Of Visits,Number of Lives**
Jim Rogers, 23/11/2020 21:46:35, 5,
Tony Smith, 13/07/1985 00:00:00, 10,
Steve Roberts, 06/05/2002 00:00:00, 20, 9

## Report achieved using a direct a direct Reflection implementation

**Owners name,Date Joined Practice,Number Of Visits,Number of Lives**
Jim Rogers, 23/11/2020 21:46:35, 5,
Tony Smith, 13/07/1985 00:00:00, 10,
Steve Roberts, 06/05/2002 00:00:00, 20, 9
