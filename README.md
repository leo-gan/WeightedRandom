# WeightedRandom
The Random algorithm produces the randomly distributed values. Sometime we need the values randomly distributed across several keys with values produced in different quantities for different keys.
Imagine we have to create a mock service. This service should imitate the payload for our system. This mock will get the predefined data and send it to the system.
The real data provided by source systems on random way. However, some systems produce more data than others do. We need to emulate not only the random behavior but also the system-related payload. Data of one system provided randomly but in bigger quantity than data of other system. Hence the weighted random algorithm. 
Detailed description see here: https://code.msdn.microsoft.com/Weighted-Random-Algorithms-0ce08cd2

NuGet package available on NuGet.org
