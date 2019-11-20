using SQLite4Unity3d;

public class Player  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Username { get; set; }	
	public string currentRoom {get; set;}
	public int currentScore{get; set;}

	public override string ToString ()
	{
		return string.Format ("[Player: Id={0}, Username={1},  curentRoom={2}, currentScore={3}]", Id, Username, currentRoom);
	}
}
