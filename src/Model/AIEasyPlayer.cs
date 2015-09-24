using System;

namespace Battleship
{
	public class AIEasyPlayer: AIPlayer
	{
		public AIEasyPlayer (BattleShipsGame controller): base(controller)
		{
		}

		/// <summary>
		/// Generate a valid, random row and column to shoot at
		/// </summary>
		/// <param name="row">output the row for the next shot</param>
		/// <param name="column">output the column for the next show</param>
		protected override void GenerateCoords (ref int row, ref int column)
		{
			do 
			{
				SearchCoords (ref row, ref column);
			} while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid[row, column] != TileView.Sea));
			//while inside the grid and not a sea tile do the search
		}

		/// <summary>
		/// SearchCoords will randomly generate shots within the grid as long as its not hit that tile already
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="column">Column.</param>
		private void SearchCoords (ref int row, ref int column)
		{
			row = _Random.Next(0, EnemyGrid.Height);
			column = _Random.Next(0, EnemyGrid.Width);
		}

		/// <summary>
		/// Process shot will throw an exception in the case of AI error resulting in a square being hit twice
		/// </summary>
		/// <param name="result">The result of the shot</param>
		/// <param name="row">the row shot</param>
		/// <param name="col">the column shot</param>
		protected override void ProcessShot(int row, int col, AttackResult result)
		{
			if (result.Value == ResultOfAttack.ShotAlready)
			{
				throw new ApplicationException("Error in AI");
			}
		}

	}
}

