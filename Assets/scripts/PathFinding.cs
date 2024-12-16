using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public int WALKCOST;
    public Vector2 grid = TileManager.TilemapSize;

    public void GridNode(NativeArray<Node> patharray, int2 endpoint)
    {
        for (int i = 0; i < grid.x; i++)
        {
            for (int j = 0; j < grid.y; j++)
            {
                Node node = new Node();
                node.x = i;
                node.y = j;
                node.index = Indexer(new int2(i, j));
                node.gcost = 0;
                node.hcost = Distance(new int2(i, j), endpoint);
                node.Fcost_Cal();
                patharray[node.index] = node;
            }
        }
    }
    public void Path(int2 endpoint)
    {
        NativeList<Node> openlist = new NativeList<Node>(Allocator.Temp);
        NativeList<Node> closedlist = new NativeList<Node>(Allocator.Temp);
        NativeArray<Node> patharray = new NativeArray<Node>();

        GridNode(patharray, endpoint);

        Node startnode = new Node();
        startnode.index = Indexer(new int2(0, 0));
        startnode.gcost = 0;
        startnode.hcost = Distance(new int2(0, 0), endpoint);
        openlist.Add(startnode);

        Node endnode = new Node();
        endnode.index = Indexer(endpoint);
        endnode.hcost = 0;

        Node currentNode = new Node();


        int limitcount = 0;
        while (openlist.Length > 0 || limitcount < 1000)
        {
            if (currentNode.index == endnode.index) break;


            Node tempNode = new Node();
            int2[] neighbours = Neighbours(new int2(currentNode.x, currentNode.y));
            for (int x = 0; x <= neighbours.Length; x++)
            {
                tempNode = patharray[Indexer(neighbours[x])];
                tempNode.last_Nodeindex = currentNode.index;
                closedlist.Add(tempNode);
            }

        }
        openlist.Dispose();
        closedlist.Dispose();
        patharray.Dispose();
    }

    public int2[] Neighbours(int2 offset)
    {
        return new int2[]
           {
            new int2(0,1)+offset,
            new int2(0,-1)+offset,
            new int2(1,0)+offset,
            new int2(-1,0)+offset
           };
    }
    public int Indexer(int2 point)
    {
        return point.x + point.y * 19;
    }
    public int Distance(int2 position, int2 endpos)
    {
        var posx = math.abs(position.x - endpos.x);
        var posy = math.abs(position.y - endpos.y);
        return (posy + posx) * WALKCOST;
    }
    public struct Node
    {
        public int index;
        public int x;
        public int y;
        public int last_Nodeindex;
        public int gcost;
        public int hcost;
        public int fcost;
        public void Fcost_Cal()
        {
            fcost = gcost + hcost;
        }
    }
}
