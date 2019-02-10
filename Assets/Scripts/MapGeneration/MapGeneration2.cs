using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace.MapGeneration
{
	public class MapGeneration2 : MonoBehaviour
	{
		public GameObject cell;
		public GameObject point;
		public List<int2> points;
		public List<Triangle> triangles;
		
		public int2 map;
		public int pointCount;

		private void Update()
		{
			if(Input.GetKey(KeyCode.R)) Application.LoadLevel(0);
		}

		private void Start()
		{
			PlotLineLow(new int2(0,map.y),new int2(map.x,map.y));
			PlotLineLow(new int2(0,0),new int2(map.x,0));
			PlotLineHigh(new int2(0, 0),new int2(0,map.y));
			PlotLineHigh(new int2(map.x,0),new int2(map.x, map.y));
			
			Random rand = new Random((uint) System.DateTime.Now.Ticks);

			for (int i = 0; i < pointCount; i++)
			{
				points.Add(rand.NextInt2(map));
			}

			//triangles.Sort((x, y) => math.length(x).CompareTo(math.length(y)));

			
//			for (var i = 0; i < points.Count; i++)
//			{
//				Instantiate(point, new Vector3(points[i].x, points[i].y, -1), quaternion.identity);
//			}
//			
			for (int i = 0; i < points.Count; i++)
			{
				int2 point = points[0];
				points.Sort((x,y)=>math.distance(x,point).CompareTo(math.distance(y, point)));
				Triangle triangle;
				triangle.p1 = points[0];
				triangle.p2 = points[1];
				triangle.p3 = points[2];
				i = 0;
				points.RemoveRange(0, 3);
				triangles.Add(triangle);
			}

			DrawTriangles();
		}

		private void DrawTriangles()
		{
			for (var i = 0; i < triangles.Count; i++)
			{
				Triangle triangle = triangles[i];
				DrawLine4(triangle.p1, triangle.p2);
				DrawLine4(triangle.p1, triangle.p3);
				DrawLine4(triangle.p2, triangle.p3);
				Debug.Log("tr");
			}

//			for (int i = 1; i < points.Count - 1; i += 3)
//			{
//				List<int2> triangle = new List<int2>();
//				triangle.Add(points[i - 1]);
//				triangle.Add(points[i]);
//				triangle.Add(points[i + 1]);
//				triangle.Sort((a, b) => a.x.CompareTo(b.x));
//				foreach (int2 int2 in triangle)
//				{
//					Debug.Log(int2 + " ");
//				}
//
//				DrawLine4(triangle[0], triangle[1]);
//				DrawLine4(triangle[0], triangle[2]);
//				DrawLine4(triangle[1], triangle[2]);
//			}
		}

		private void DrawLine(int2 a, int2 b)
		{
			b += 1;
			int xDistance = math.abs(a.x - b.x);
			int yDistance = math.abs(a.y - b.y);

			int minDistance = math.min(xDistance, yDistance);
			int maxDistance = math.max(xDistance, yDistance);

			int step = maxDistance / minDistance;
			int firstStep = step + maxDistance % minDistance;
			for (int i = 0; i < firstStep; i++)
			{
				int2 point = a + new int2(i, 0);
				Instantiate(cell, new Vector2(point.x, point.y), quaternion.identity);
			}

			for (int i = 1; i < minDistance; i++)
			{
				for (int j = 0; j < step; j++)
				{
					int2 point = a + new int2(i, j);
					Instantiate(cell, new Vector2(point.x, point.y), quaternion.identity);
				}
			}
		}

		private void DrawLine2(int2 a, int2 b)
		{
			int dx = b.x - a.x;
			int dy = b.y - a.y;
			for (int x = a.x; x < b.x; x++)
			{
				int y = a.y + dy * (x - b.y) / dx;
				Instantiate(cell, new Vector2(x, y), quaternion.identity);
			}
		}

		private void DrawLine3(int2 a, int2 b)
		{
			int dx = b.x - a.x;
			int dy = b.y - a.y;
			int D = 2 * dy - dx;
			int y = a.y;

			for (int x = a.x; x < b.x; x++)
			{
				Instantiate(cell, new Vector2(x, y), quaternion.identity);
				if (D > 0)
				{
					y++;
					D -= 2 * dx;
				}

				D = D + 2 * dy;
			}
		}

		private void DrawLine4(int2 a,int2 b)
		{
			int2 abs = math.abs(b - a);
			if (abs.y < abs.x)
			{
				if (a.x > b.x)
					PlotLineLow(b, a);
				else
					PlotLineLow(a, b);
			}
			else
			{
				if (a.y > b.y)
					PlotLineHigh(b, a);
				else
					PlotLineHigh(a,b);
			}
		}
		private void Plot(int x, int y)
		{
			Instantiate(cell, new Vector2(x, y), quaternion.identity);
		}

		private void PlotLineLow(int2 a, int2 b)
		{
			int dx = b.x - a.x;
			int dy = b.y - a.y;
			int yi = 1;
			if (dy < 0)
			{
				yi = -1;
				dy = -dy;
			}

			int D = 2 * dy - dx;
			int y = a.y;

			for (int x = a.x; x < b.x; x++)
			{
				Plot(x, y);
				if (D > 0)
				{
					y += yi;
					D -= 2 * dx;
				}

				D += 2 * dy;
			}
		}

		private void PlotLineHigh(int2 a, int2 b)
		{
			int dx = b.x - a.x;
			int dy = b.y - a.y;
			int xi = 1;
			if (dx < 0)
			{
				xi = -1;
				dx = -dx;
			}

			int D = 2 * dx - dy;
			int x = a.x;

			for (int y = a.y; y < b.y; y++)
			{
				Plot(x, y);
				if (D > 0)
				{
					x += xi;
					D -= 2 * dy;
				}

				D += 2 * dx;
			}
		}
	}
}