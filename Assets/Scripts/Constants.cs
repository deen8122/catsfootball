using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public static class Constants
    {
		//Тип игры друг против друга
		public static readonly int GAME_MODE_PVP = 1;
		//Тип игры один против смартфона
		public static readonly int GAME_MODE_PVS = 0;
		//Блокировка игроков
		public static readonly int ALL_CATS_DISACTIVATE = 2;
		//Мин скорость , при которой считать что обьект остановлен
        public static readonly float MinVelocity = 0.05f;

		public static readonly string PlayerTag = "player_cats";
		public static readonly string EnemyTag = "enemy_cats";
		public static readonly string BallTag = "ball";

		public static readonly string NextLevelName = "NextLevelName";
		public static readonly string CurrentLevelName = "CurrentLevelName";


        public static readonly float BirdColliderRadiusNormal = 0.235f;
        public static readonly float BirdColliderRadiusBig = 0.5f;
		public static readonly float minCameraX = 0;

		public static readonly int BOX_TYPE_BLOCK = 0;
		public static readonly int BOX_TYPE_ICE = 1;
		public static readonly int BOX_TYPE_PALKA_BOX = 3;
		public static readonly int BOX_TYPE_PALKA_ICE = 4;
	}
}
