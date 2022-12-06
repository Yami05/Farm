using System;

public static class GameEvents
{
	public static Action Start { get; set; }
	public static Action EnemyStarter { get; set; }
	public static Action Cannon { get; set; }
	public static Action Polygon { get; set; }
	public static Action GameOver { get; set; }
	public static Action Win { get; set; }
}
