using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour { 

    // public class Node {

    //     public Node parent;
    //     public coordinate position;
    //     private int g, h, f;

    //     public Node(Node par, coordinate pos) {
    //         g = 0;
    //         h = 0;
    //         f = 0;

    //         parent = par;
    //         position = pos;
    //     }

    //     public Node(coordinate pos) {
    //         g = 0;
    //         h = 0;
    //         f = 0;

    //         parent = null;
    //         position = pos;
    //     }

    //     public int getG() { return g; }
    //     public int getH() { return h; }
    //     public int getF() { return f; }

    //     public void setG(int i) { g = i; }
    //     public void setH(int i) { h = i; }
    //     public void setF(int i) { f = i; }

    //     public bool isSame(Node n) {
    //         if (n.getG() == g && n.getH() == h && n.getF() == f) return true;
    //         else return false;
    //     }

    //     public bool eq(Node n) {
    //         if (n.position.isEq(this.position)) return true;
    //         else return false;
    //     }

    // }

    // static int[,] maze = new int[20,20] {{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1},
    //                                      {1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
    //                                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
    //                                      {1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0},
    //                                      {1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
    //                                      {1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
    //                                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
    //                                      {1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
    //                                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1},
    //                                      {1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1},
    //                                      {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1},
    //                                      {1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1},
    //                                      {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
    //                                      {1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
    //                                      {1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
    //                                      {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1},
    //                                      {1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1},
    //                                      {1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
    //                                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1},
    //                                      {1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};



    // public static coordinate[] aStar(coordinate start, coordinate end) {

    //     // Create start and end node
    //     Node start_node = new Node(start);
    //     start_node.setG(0);
    //     start_node.setH(0);
    //     start_node.setF(0);
    //     Node end_node = new Node(end);
    //     end_node.setG(0);
    //     end_node.setH(0);
    //     end_node.setF(0);

    //     // Initialize both open and closed list
    //     List<Node> open_list = new List<Node>();
    //     List<Node> closed_list = new List<Node>();

    //     // Add the start node
    //     open_list.Add(start_node);
    //     Debug.Log(start_node.position.getX() + " " + start_node.position.getY());

    //     // Loop until you find the end
    //     while (open_list.Count > 0) {
    //         Debug.Log(open_list.Count);

    //         // Get the current node
    //         Node current_node = open_list[0];
    //         int current_index = 0;
    //         for (int i = 0; i < open_list.Count; i++) {
    //             Debug.Log(i);
    //             if (open_list[i].getF() < current_node.getF()) {
    //                 current_node = open_list[i];
    //                 current_index = i;
    //             }
    //         }
    //         Debug.Log("current_node = " + current_node.position.getX() + " " + current_node.position.getY());

    //         // Pop current off open list, add to closed list
    //         open_list.RemoveAt(current_index);
    //         closed_list.Add(current_node);

    //         // Found the goal
    //         if (current_node.eq(end_node)) {
    //             List<coordinate> path = new List<coordinate>();
    //             Node current = current_node;
    //             while (current != null) {
    //                 path.Add(current.position);
    //                 current = current.parent;
    //             }
    //             path.Reverse();
    //             return path.ToArray();
    //         }

    //         // Generate children
    //         List<Node> children = new List<Node>();
    //         coordinate[] adjacent = {new coordinate(0, -1),
    //                                  new coordinate(0, 1),
    //                                  new coordinate(-1, 0),
    //                                  new coordinate(1, 0)};
    //         foreach (coordinate new_position in adjacent) {
    //             Debug.Log("trying... " + new_position.getX() + " " + new_position.getY());
                
    //             // Get node position
    //             coordinate node_position = new coordinate((current_node.position.getX() + new_position.getX()), 
    //                                                       (current_node.position.getY() + new_position.getY()));
                
    //             // Make sure within range
    //             if ( (node_position.getX() > 19) || (node_position.getX() < 0) || 
    //                  (node_position.getY() > 19) || (node_position.getY() < 0) ) {
    //                 continue;
    //             }

    //             // Make sure walkable terrain
    //             if (maze[node_position.getX(), node_position.getY()] != 0) {
    //                 continue;
    //             }

    //             // Create new node
    //             Node new_node = new Node(current_node, node_position);

    //             // Append
    //             children.Add(new_node);
    //         }

    //         // Loop through children
    //         foreach (Node child in children) {
    //             // Child is on the closed list
    //             bool cont1 = true;
    //             foreach (Node closed_child in closed_list) {
    //                 if (child.eq(closed_child)) {
    //                     cont1 = false;
    //                     break;
    //                 }
    //             }

    //             if (cont1) {
    //                 // Create the f, g, and h values
    //                 child.setG(current_node.getG() + 1);
    //                 // H: Manhattan distance to end point
    //                 child.setH(Mathf.Abs(child.position.getX() - end_node.position.getX()) +
    //                            Mathf.Abs(child.position.getY() - end_node.position.getY()));
    //                 child.setF(child.getG() + child.getH());

    //                 // Child is already in the open list
    //                 bool cont2 = true;
    //                 foreach (Node open_node in open_list) {
    //                     // Check if the new path to children is worse or equal to one
    //                     // already in the open_list (by measuring g)
    //                     if (child.eq(open_node) && (child.getG() >= open_node.getG())) {
    //                         cont2 = false;
    //                         break;
    //                     }
    //                 }

    //                 if (cont2) {
    //                     // Add the child to the open list
    //                     open_list.Add(child);
    //                 }

    //             }
    //         }
    //         Debug.Log("End of while loop");
    //     }

    //     return null;
    // }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    

    public List<Vector2> result = new List<Vector2>();
	private string find;
	
	private class _Object {
		public int x {
			get;
			set;
		}
		public int y {
			get;
			set;
		}
		public double f {
			get;
			set;
		}
		public double g {
			get;
			set;
		}
		public int v {
			get;
			set;
		}
		public _Object p {
			get;
			set;
		}
		public _Object (int x, int y) {
			this.x = x;
			this.y = y;
		}
	}
	
	private _Object[] diagonalSuccessors (bool xN, bool xS, bool xE, bool xW, int N, int S, int E, int W, int[][] grid, int rows, int cols, _Object[] result, int i) {
		if (xN) {
			if (xE && grid[N][E] == 0) {
				result[i++] = new _Object(E, N);
			}
			if (xW && grid[N][W] == 0) {
				result[i++] = new _Object(W, N);
			}
		}
		if (xS) {
			if (xE && grid[S][E] == 0) {
				result[i++] = new _Object(E, S);
			}
			if (xW && grid[S][W] == 0) {
				result[i++] = new _Object(W, S);
			}
		}
		return result;
	}
	
	private _Object[] diagonalSuccessorsFree (bool xN, bool xS, bool xE, bool xW, int N, int S, int E, int W, int[][] grid, int rows, int cols, _Object[] result, int i) {
		xN = N > -1;
		xS = S < rows;
		xE = E < cols;
		xW = W > -1;
		
		if (xE) {
			if (xN && grid[N][E] == 0) {
				result[i++] = new _Object(E, N);
			}
			if (xS && grid[S][E] == 0) {
				result[i++] = new _Object(E, S);
			}
		}
		if (xW) {
			if (xN && grid[N][W] == 0) {
				result[i++] = new _Object(W, N);
			}
			if (xS && grid[S][W] == 0) {
				result[i++] = new _Object(W, S);
			}
		}
		return result;
	}
	
	private _Object[] nothingToDo (bool xN, bool xS, bool xE, bool xW, int N, int S, int E, int W, int[][] grid, int rows, int cols, _Object[] result, int i) {
		return result;
	}
	
	private _Object[] successors (int x, int y, int[][] grid, int rows, int cols) {
		int N = y - 1;	
		int S = y + 1;
		int E = x + 1;
		int W = x - 1;
		
		bool xN = N > -1 && grid[N][x] == 0;
		bool xS = S < rows && grid[S][x] == 0;
		bool xE = E < cols && grid[y][E] == 0;
		bool xW = W > -1 && grid[y][W] == 0;
		
		int i = 0;
		
		_Object[] result = new _Object[8];
		
		if (xN) {
			result[i++] = new _Object(x, N);
		}
		if (xE) {
			result[i++] = new _Object(E, y);
		}
		if (xS) {
			result[i++] = new _Object(x, S);
		}
		if (xW) {
			result[i++] = new _Object(W, y);
		}
		
		_Object[] obj = 
			(this.find == "Diagonal"	|| this.find == "Euclidean")	?	diagonalSuccessors		(xN, xS, xE, xW, N, S, E, W, grid, rows, cols, result, i):
			(this.find == "DiagonalFree"|| this.find == "EuclideanFree")?	diagonalSuccessorsFree	(xN, xS, xE, xW, N, S, E, W, grid, rows, cols, result, i):
																			 		nothingToDo		(xN, xS, xE, xW, N, S, E, W, grid, rows, cols, result, i);
		
		return obj;
	}
	
	private double diagonal (_Object start, _Object end) {
		return Mathf.Max(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
	}
	
	private double euclidean(_Object start, _Object end) {
		var x = start.x - end.x;
		var y = start.y - end.y;
		
		return Mathf.Sqrt(x * x + y * y);
	}

	private double manhattan(_Object start, _Object end) {
		return Mathf.Abs(start.x - end.x) + Mathf.Abs(start.y - end.y);
	}
	
	public Pathfinder (int[][] grid, int[] s, int[] e, string f)
	{
		this.find = (f == null) ? "Diagonal" : f;
		
		int cols 	= grid[0].Length;
		int rows 	= grid.Length;
		int limit 	= cols * rows;
		int length 	= 1;
		
		List<_Object> open = new List<_Object>();
		open.Add(new _Object(s[0], s[1]));
		open[0].f = 0;
		open[0].g = 0;
		open[0].v = s[0]+s[1]*cols;
		
		_Object current;
	
		List<int> list = new List<int>();

		double distanceS;
		double distanceE;
		
		int i;
		int j;
		
		double max;
		int min;
		
		_Object[] next;
		_Object adj;
		
		_Object end = new _Object(e[0], e[1]);
		end.v = e[0]+e[1]*cols;
		
		bool inList;
		
		do {
			max = limit;
			min = 0;
			
			for (i = 0; i < length; i++) {
				if (open[i].f < max) {
					max = open[i].f;
					min = i;
				}
			}
			
			current = open[min];
			open.RemoveAt(min);
			
			if (current.v != end.v) {
				--length;
				next = successors(current.x, current.y, grid, rows, cols);
				
				for (i = 0, j = next.Length; i < j; ++i)
				{
					if (next[i] == null) {
						continue;
					}
					
					(adj = next[i]).p = current;
					adj.f = adj.g = 0;
					adj.v = adj.x + adj.y * cols;
					inList = false;
					
					foreach (int key in list) {
						if (adj.v == key) {
							inList = true;
						}
					}
					
					if (!inList) {
						if (this.find == "DiagonalFree" || this.find == "Diagonal") {
							distanceS = diagonal(adj, current);
							distanceE = diagonal(adj, end);
						}
						else if (this.find == "Euclidean" || this.find == "EuclideanFree") {
							distanceS = euclidean(adj, current);
							distanceE = euclidean(adj, end);
						}
						else {
							distanceS = manhattan(adj, current);
							distanceE = manhattan(adj, end);
						}
						
						adj.f = (adj.g = current.g + distanceS) + distanceE;
						open.Add(adj);
						list.Add(adj.v);
						length++;
					}
				}
			}
			else {
				i = length = 0;
				do {
					this.result.Add(new Vector2(current.x, current.y));
				}
				while ((current = current.p) != null);
				result.Reverse();
			}
		}
		while (length != 0);
	}





}
