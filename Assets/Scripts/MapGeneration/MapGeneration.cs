using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace.MapGeneration
{
	public class MapGeneration : MonoBehaviour
	{
		public int roomsCount;
		public List<Room> rooms = new List<Room>();
		
		public int mapHeight;
		public int mapWidth;
		
		public int minHeight = 10;
		public int minWidth = 10;
		
		public int cellWidth = 32;
		public int cellHeight = 32;

		public GameObject cell;

		Random rand = new Random( (uint)System.DateTime.Now.Ticks);
		
		
		private void Next(int2 xy)
		{
			Room room = new Room
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
				Next(xy+rand.NextInt2(new int2(-1, 1),new int2(-1, 1))* new int2(room.w,room.h));
		}
		private void Start()
		{
			Next(new int2());
			foreach (Room room in rooms)
			{
				for (int i = 0; i < room.w; i++)
				{
					for (int j = 0; j < room.h; j++)
					{
						GameObject gm = Instantiate(cell, new Vector3(room.x+i, room.y+j), Quaternion.identity);
					}
				}
			}
		}
	}
}