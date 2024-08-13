using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class A_Star
    {
        static public int huCost = 10;
                  //상 하 좌 우
        static int[] dx = {0,0,-1,1 };
        static int[] dy = {-1,1,0,0 };



        private class ASNode
        {
            public Point point;     // 현재 정점
            public Point parent;    // 이 정점을 탐색한 정점


            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;           // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;           // f(x) = g(x) + h(x);

            public ASNode(Point point, Point parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }

        public static bool PathFinding(in int[,] tileMap, in Point start, in Point end, out List<Point> path)
        {

            ASNode[,] nodes = new ASNode[Map.height, Map.width];
            bool[,] visited = new bool[Map.height, Map.width];

            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            //시작 정점
            ASNode startNode = new ASNode(start, new Point(), 0, Heuristic(start, end));

            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                ASNode nextNode = nextPointPQ.Dequeue();

                visited[nextNode.point.y, nextNode.point.x] = true;

                //도착하면 parent에 저장 된 위치 하나씩 꺼내서 삽입 후 reverse 정렬
                if (nextNode.point.x == end.x && nextNode.point.y == end.y)
                {
                    path = new List<Point>();

                    Point point = end;
                    while ((point.x == start.x && point.y == start.y) == false)
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parent;
                    }
                    path.Add(start);

                   
                    path.Reverse();
                    return true;
                }

                for (int i = 0; i < dx.Length; i++)
                {
                    int x = nextNode.point.x + dx[i];
                    int y = nextNode.point.y + dy[i];


                    if (x < 0 || x >= Map.width || y < 0 || y >= Map.height)
                        continue;
                    else if (tileMap[y, x] == PixelType.WALL || tileMap[y, x] == PixelType.USERSPACE)
                        continue;
                    else if (visited[y, x])
                        continue;


                    int g = nextNode.g + huCost;
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                  
                    if (nodes[y, x] == null ||     
                        nodes[y, x].f > newNode.f) 
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }

        private static int Heuristic(Point start, Point end)
        {
            int xSize = Math.Abs(start.x - end.x);  
            int ySize = Math.Abs(start.y - end.y);

            return huCost * (xSize + ySize);

        }
    }
}
