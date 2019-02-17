using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace.MapGeneration
{
	public class MapGeneration : MonoBehaviour
	{
		public GameObject cell;
		public int cellHeight = 32;

		public int cellWidth = 32;

		public int mapHeight;
		public int mapWidth;

		public int minHeight = 10;
		public int minWidth = 10;

		private Random rand = new Random((uint) DateTime.Now.Ticks);
		public List<Room> rooms = new List<Room>();
		public int roomsCount;


		private void Next(int2 xy)
		{
			var room = new Room
			{
				x = xy.x,
				y = xy.y,
				w = minWidth + rand.NextInt(cellWidth),
				h = minWidth + rand.NextInt(cellWidth)
			};
			rooms.Add(room);
			roomsCount--;
			rand.NextInt2(-1, 1);
			if (roomsCount >= 0)
				Next(xy + rand.NextInt2(new int2(-1, 1), new int2(-1, 1)) * new int2(room.w, room.h));
		}

		private void Start()
		{
			Next(new int2());
			foreach (var room in rooms)
				for (var i = 0; i < room.w; i++)
				for (var j = 0; j < room.h; j++)
				{
					var gm = Instantiate(cell, new Vector3(room.x + i, room.y + j), Quaternion.identity);
				}
		}
	}
}