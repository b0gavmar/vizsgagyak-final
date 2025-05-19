using ConsoleApp1.Models;
using ConsoleApp1.Repos;

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

PlayerRepo repo = new PlayerRepo();
Console.WriteLine("Az összes összeg: "+repo.GetSumOfAllAmount());
Player p2 = new Player("penztelen", "penztelen@gmail.hu",0,22);
try
{
    repo.AddPlayer(p2);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

foreach(Player p in repo.GetNumberOfPlayersWithAmount())
{
    Console.WriteLine(p.Name+"\n");
}