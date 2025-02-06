namespace Entities;
public class Favorite
{
    public int Id { get;  set; }
    public DateTime Date {get;set;}
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public Favorite(){
    }
}