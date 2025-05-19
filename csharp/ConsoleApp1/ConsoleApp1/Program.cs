using ConsoleApp1.Models;

try
{
    Player ures = new Player("", "vanemailem");
}
catch(Exception e)
{ 
    Console.WriteLine(e.Message); 
}

try
{
    Player ures2 = new Player("vannevem", "vanemailem");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Player ures3 = new Player("vannevem", "vanemailem@gmail.hu");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Player jatekos = new Player("vanNevem", "vanemailem@gmail.hu", 100, 22);

Console.WriteLine("Van összege? "+jatekos.HasAmount());
Console.WriteLine("Jelenlegi összege: "+jatekos.GetAmount());
jatekos.AddAmount(1000);
Console.WriteLine("Jelenlegi összege hozzáadás után: " + jatekos.GetAmount());