using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace DefaultNamespace.MapGeneration
{
	public class MapGeneration2 : MonoBehaviour
	{
		public GameObject cell;
		public int innerBoundSize;

		public int2 map;
		public int outerBoundSize;
		public List<int2> points;
		public int triangleCount;
		public List<Triangle> triangles;

		private void Update()
		{
			if (Input.GetKey(KeyCode.R)) Application.LoadLevel(0);
		}

		private void Start()
		{
			for (var i = 0; i < innerBoundSize; i++) PlotBound(i, map - i);

			for (var i = 0; i < outerBoundSize; i++) PlotBound(-i, map + i);
			var rand = new Random((uint) DateTime.Now.Ticks);

			for (var i = 0; i < triangleCount * 3; i++) points.Add(rand.NextInt2(map));

			//triangles.Sort((x, y) => math.length(x).CompareTo(math.length(y)));


//			for (var i = 0; i < points.Count; i++)
//			{
//				Instantiate(point, new Vector3(points[i].x, points[i].y, -1), quaternion.identity);
//			}
//			
			for (var i = 0; i < points.Count; i++)
			{
				var point = points[0];
				points.Sort((x, y) => math.distance(x, point).CompareTo(math.distance(y, point)));
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
				var triangle = triangles[i];
				triangle.Sort();
				DrawLine4(triangle.p1, triangle.p2);
				DrawLine4(triangle.p1, triangle.p3);
				DrawLine4(triangle.p2, triangle.p3);

				//Fill(triangle.p1, triangle.p2, triangle.p3);
				for (var x = triangle.p1.x; x <= triangle.p2.x; x++)
				for (var y = triangle.p1.y; y <= triangle.p2.y; y++)
					DrawLine4(new int2(x, y), triangle.p3);
			}
		}

		private void Fill(int2 A, int2 B, int2 C)
		{
			var S = int2.zero;
			var E = int2.zero;
			var P = int2.zero;
			int dx1 = 0, dx2 = 0, dx3 = 0;
			if (B.y - A.y > 0) dx1 = (B.x - A.x) / (B.y - A.y);


			if (C.y - A.y > 0) dx2 = (C.x - A.x) / (C.y - A.y);

			if (C.y - B.y > 0) dx3 = (C.x - B.x) / (C.y - B.y);

			S = A;
			E = A;
			if (dx1 > dx2)
			{
				for (; S.y <= B.y; S.y++, E.y++)
				{
					P = S;
					for (; P.x < E.x; P.x++) Plot(P);
					S.x += dx2;
					E.x += dx1;
				}

				E = B;
				for (; S.y <= C.y; S.y++, E.y++)
				{
					P = S;
					for (; P.x < E.x; P.x++) Plot(P);
					S.x += dx2;
					E.x += dx3;
				}
			}
			else
			{
				for (; S.y <= B.y; S.y++, E.y++)
				{
					P = S;
					for (; P.x < E.x; P.x++) Plot(P);
					S.x += dx1;
					E.x += dx2;
				}

				S = B;
				for (; S.y <= C.y; S.y++, E.y++)
				{
					P = S;
					for (; P.x < E.x; P.x++) Plot(P);
					S.x += dx3;
					E.x += dx2;
				}
			}
		}

		private void DrawLine(int2 a, int2 b)
		{
			b += 1;
			var xDistance = math.abs(a.x - b.x);
			var yDistance = math.abs(a.y - b.y);

			var minDistance = math.min(xDistance, yDistance);
			var maxDistance = math.max(xDistance, yDistance);

			var step = maxDistance / minDistance;
			var firstStep = step + maxDistance % minDistance;
			for (var i = 0; i < firstStep; i++)
			{
				var point = a + new int2(i, 0);
				Instantiate(cell, new Vector2(point.x, point.y), quaternion.identity);
			}

			for (var i = 1; i < minDistance; i++)
			for (var j = 0; j < step; j++)
			{
				var point = a + new int2(i, j);
				Instantiate(cell, new Vector2(point.x, point.y), quaternion.identity);
			}
		}

		private void DrawLine2(int2 a, int2 b)
		{
			var dx = b.x - a.x;
			var dy = b.y - a.y;
			for (var x = a.x; x < b.x; x++)
			{
				var y = a.y + dy * (x - b.y) / dx;
				Instantiate(cell, new Vector2(x, y), quaternion.identity);
			}
		}

		private void DrawLine3(int2 a, int2 b)
		{
			var dx = b.x - a.x;
			var dy = b.y - a.y;
			var D = 2 * dy - dx;
			var y = a.y;

			for (var x = a.x; x < b.x; x++)
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

		private void DrawLine4(int2 a, int2 b)
		{
			var abs = math.abs(b - a);
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
					PlotLineHigh(a, b);
			}
		}

		private void Plot(int2 p)
		{
			Plot(p.x, p.y);
		}

		private void Plot(int x, int y)
		{
			Instantiate(cell, new Vector2(x, y), quaternion.identity);
		}

		private void PlotBound(int2 a, int2 b)
		{
			PlotLineLow(a, new int2(b.x, a.y));
			PlotLineLow(new int2(a.x, b.y), b);
			PlotLineHigh(a, new int2(a.x, b.y));
			PlotLineHigh(new int2(b.x, a.y), b);
		}

		private void PlotLineLow(int2 a, int2 b)
		{
			var dx = b.x - a.x;
			var dy = b.y - a.y;
			var yi = 1;
			if (dy < 0)
			{
				yi = -1;
				dy = -dy;
			}

			var D = 2 * dy - dx;
			var y = a.y;

			for (var x = a.x; x < b.x; x++)
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
			var dx = b.x - a.x;
			var dy = b.y - a.y;
			var xi = 1;
			if (dx < 0)
			{
				xi = -1;
				dx = -dx;
			}

			var D = 2 * dx - dy;
			var x = a.x;

			for (var y = a.y; y < b.y; y++)
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