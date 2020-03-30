# Task 3

## Prerequisites:
Read Chapter 6 of .NET Book Zero and [How to parse strings using String.Split](https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split)

## Description:
The city of Montpellier has equipped its streets with defibrillators to help save victims of cardiac arrests. 
The data corresponding [to the position of all defibrillators](http://data.montpellier3m.fr/dataset/defibrillateurs-de-montpellier) is available online.
For this task this data was parsed into array of strings task.DefibliratorStorages.
Based on the data provided in the task, write a program that will allow user to find the defibrillator nearest to his/her location using mobile phone.

## Goal:
Based on the longitude and latitude of the user, show the name and address of the place with defibrillator nearest to his/her location.

## Example input: 
[task.DefibliratorStorages[0]] = "Service surveillance voie publique (ASVP);8 Avenue Louis Blanc;3,879648142759082;43,614497120868634"  
[task.DefibliratorStorages[1]] = "Poste de police Ecusson Centre ville;19 bis Rue durand;3,878607492700567;43,60501747702074"  
[task.DefibliratorStorages[2]] = "Plateau sportif de Grammont Terrain 9, 10, 11;Avenue Albert Einstein;3,935283626753695;43,614140050141465"  
...

[task.UserLongitude] = "3,878607492700568"  
[task.UserLatitude] = "43,60501747702075"   

## Example output:
"Name: Service surveillance voie publique (ASVP); Address: 8 Avenue Louis Blanc"

## Task clarifications:
The distance should be calculated using [Harvesine Formula](http://www.movable-type.co.uk/scripts/latlong.html)  
![x=(longitudeB-longitudeA)\times cos(\frac{latitudeA+latitudeB}{2})](https://render.githubusercontent.com/render/math?math=x%3D(longitudeB-longitudeA)%5Ctimes%20cos(%5Cfrac%7BlatitudeA%2BlatitudeB%7D%7B2%7D))  
![y=(latitudeB-latitudeA)](https://render.githubusercontent.com/render/math?math=y%3D(latitudeB-latitudeA))  
![d=\sqrt{x^2+y^2}\times 6371](https://render.githubusercontent.com/render/math?math=d%3D%5Csqrt%7Bx%5E2%2By%5E2%7D%5Ctimes%206371)  
_Note_: In this formula, the latitudes and longitudes are expressed in radians. 6371 corresponds to the radius of the earth in km.

The input data you require for your program is provided in text format.  
This data is comprised of lines, each of which represents a defibrillator storage. Each defibrillator storage is represented by the following fields:  
- Name  
- Address  
- Longitude (degrees)
- Latitude (degrees)
These fields are separated by a semicolon (;).
_Note_: The numbers in the text use the comma (,) as decimal separator. Remember to turn the comma (,) into dot (.) in order to use the data in your program.  

Input variables that contains only numbers should be parsed to _floats_.  
Use _floats_ in all your floating-point calculations.  
Don't round any intermediate results.  
Numbers, if needed, should be rounded by Math.Truncate().  

## Credits:
Original idea of the task was taken from CodinGames - [link](https://www.codingame.com/ide/puzzle/defibrillators)     
