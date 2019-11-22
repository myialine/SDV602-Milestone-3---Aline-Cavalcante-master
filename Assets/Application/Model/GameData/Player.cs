using SQLite4Unity3d;

public class Player  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	[Unique]
	public string PlayerName { get; set; }
	public string PlayerPassword { get; set; }
	public string PlayerEmail {get;  set; }	
	public string currentRoom {get; set;}

	public override string ToString ()
	{
		return string.Format ("[Player: Id={0}, PlayerName={1},  PlayerPassword={2}, PlayerEmail={3}, currentRoom={4}]", Id, PlayerName, PlayerPassword, PlayerEmail, currentRoom);
	}

	public Player(){

	}
}
