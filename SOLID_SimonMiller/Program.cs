// See https://aka.ms/new-console-template for more information


using SOLID_SimonMiller._4_I.After;

Console.WriteLine("Hello, World!");

var services = new ServiceCollection();

var inst = new Repository();

services.AddTransient<IUserRepositoryQuery>(svcs => inst); 



var app = builder.Build();